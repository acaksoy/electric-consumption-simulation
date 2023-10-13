using SimulationClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace EC_Simulation
{
    public partial class DisplayResult : Form
    {

        List<Record> records = new List<Record>();
        Dictionary<int, Record> indexRecordPairs = new Dictionary<int, Record>();

        double yearlyTotalProduction = 0;
        double yearlyTotalConsumption = 0;

        List<Tuple<CheckBox, Series, Record>> chartTupleList = new List<Tuple<CheckBox, Series, Record>>();
        public DisplayResult(List<Record> records)
        {
            InitializeComponent();

            this.records = records;

        }
        private void DisplayResult_Shown(object sender, EventArgs e)
        {
            List<CheckBox> checkboxes = this.Controls.OfType<CheckBox>().ToList();

            for (int i = 0; i < records.Count; i++)
            {
                int index = resultsComboBox.Items.Add(records[i].Name);
                indexRecordPairs.Add(index, records[i]);

                Series series = chart1.Series.Add(records[i].Name);
                series.ChartType = SeriesChartType.Spline;
                series.BorderWidth = 3;
                series.Enabled = false;
                chartTupleList.Add(new Tuple<CheckBox, Series, Record>(checkboxes[i], series, records[i]));
                checkboxes[i].Text = records[i].Name;

            }
            chart1.ChartAreas[0].AxisY.Title = "kW";
            chart1.ChartAreas[0].CursorX.AutoScroll = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
            chart1.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 30);

            Record totalConRec = records.Find(x => x.Name == "Total Elec. Consumption") ?? throw new InvalidOperationException("Record could not be found!");
            foreach (KeyValuePair<DateTime, double> pair in totalConRec.results)
            {
                yearlyTotalConsumption += pair.Value;
            }
            yearlyTotalConsumptionLabel.Text += $" {yearlyTotalConsumption}";
            Record totalProdRec = records.Find(x => x.Name == "Total Elec. Prod. Renewable") ?? throw new InvalidOperationException("Record could not be found!");
            foreach (KeyValuePair<DateTime, double> pair in totalProdRec.results)
            {
                yearlyTotalProduction += pair.Value;
            }
            yearlyTotalProductionLabel.Text += $" {yearlyTotalProduction}";           
        }
        private void CheckBox_Checked(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender ?? throw new InvalidOperationException("checkbox could not be found!"); 
            foreach (Tuple<CheckBox, Series, Record> chartTuple in chartTupleList)
            {
                if (cb == chartTuple.Item1)
                {
                    chartTuple.Item2.Enabled = cb.Checked;
                    chart1.ChartAreas[0].RecalculateAxesScale();
                    return;
                }
            }
        }

        private void ComboBox_Selected(object sender, EventArgs e)
        {
            double sumYearlValue = 0;
            DataGridView1.Columns.Clear();
            DataGridView1.Columns.Add("DateColumn", "Date");
            Record selectedRecord = indexRecordPairs[resultsComboBox.SelectedIndex];
            DataGridView1.Columns.Add("Value1", selectedRecord.Name);
            foreach (KeyValuePair<DateTime, double> result in selectedRecord.results)
            {
                DataGridView1.Rows.Add(result.Key.ToString(), result.Value);
                sumYearlValue += result.Value;
            }
            selectedYearlyTotal.Text = $"{selectedRecord.Name} - Annual Total: {sumYearlValue}";
        }

        private void DrawGraph(object sender, EventArgs e)
        {
            Button button = (Button)sender ?? throw new InvalidOperationException("button could not be found!"); ;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            foreach (Tuple<CheckBox, Series, Record> chartTuple in chartTupleList)
            {
                if (chartTuple.Item1.Enabled)
                {
                    switch (button.Tag)
                    {
                        case "Hourly":
                            if (chartTuple.Item3.Name == "Power Storage") chartTuple.Item2.Name = "Power Storage";

                            chart1.ChartAreas[0].AxisX.Title = "Hours";
                            chartTuple.Item2.ChartType = SeriesChartType.Spline;
                            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
                            chart1.ChartAreas[0].AxisX.Interval = 1;
                            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 24);
                            foreach (KeyValuePair<DateTime, double> result in chartTuple.Item3.results)
                            {
                                chartTuple.Item2.Points.AddXY(result.Key.ToString(), result.Value);
                            }
                            chart1.ChartAreas[0].RecalculateAxesScale();
                            break;

                        case "Daily":

                            chart1.ChartAreas[0].AxisX.Title = "Days";
                            chartTuple.Item2.ChartType = SeriesChartType.Spline;
                            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
                            chart1.ChartAreas[0].AxisX.Interval = 1;
                            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 31);
                            DateTime currentDay = records[0].results.Keys.First<DateTime>();
                            double dailyValue = 0;
                            if (chartTuple.Item3.Name == "Power Storage")
                            {
                                chartTuple.Item2.Name = "Maximum amount of stored power";
   
                                foreach (KeyValuePair<DateTime, double> result in chartTuple.Item3.results)
                                {
                                    if (currentDay.Day == result.Key.Day)
                                    {
                                        dailyValue = Math.Max(dailyValue, result.Value);
                                    }
                                    else
                                    {
                                        chartTuple.Item2.Points.AddXY(currentDay.ToShortDateString(), dailyValue);
                                        currentDay = currentDay.AddDays(1);
                                        dailyValue = result.Value;
                                    }
                                }
                            }
                            else
                            {
                                foreach (KeyValuePair<DateTime, double> result in chartTuple.Item3.results)
                                {
                                    if (currentDay.Day == result.Key.Day)
                                    {
                                        dailyValue += result.Value;
                                    }
                                    else
                                    {
                                        chartTuple.Item2.Points.AddXY(currentDay.ToShortDateString(), dailyValue);
                                        currentDay = currentDay.AddDays(1);
                                        dailyValue = result.Value;
                                    }
                                }
                            }
                            chartTuple.Item2.Points.AddXY(currentDay.ToShortDateString(), dailyValue);
                            chart1.ChartAreas[0].RecalculateAxesScale();
                            break;
                        case "Monthly":
                            chart1.ChartAreas[0].AxisX.Title = "Monthly";
                            chartTuple.Item2.ChartType = SeriesChartType.Column;
                            chart1.ChartAreas[0].AxisX.Interval = 1;
                            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 12);
                            DateTime currentMonth = records[0].results.Keys.First<DateTime>();
                            double monthlyValue = 0;
                            if (chartTuple.Item3.Name == "Power Storage")
                            {
                                chartTuple.Item2.Name = "Maximum amount of stored power";
                                foreach (KeyValuePair<DateTime, double> result in chartTuple.Item3.results)
                                {
                                    if (currentMonth.Month == result.Key.Month)
                                    {
                                        monthlyValue = Math.Max(monthlyValue, result.Value);
                                    }
                                    else
                                    {

                                        chartTuple.Item2.Points.AddXY(currentMonth.ToShortDateString(), monthlyValue);
                                        currentMonth = currentMonth.AddMonths(1);
                                        monthlyValue = result.Value;
                                    }
                                }
                                chartTuple.Item2.Points.AddXY(currentMonth.ToShortDateString(), monthlyValue);
                                chart1.ChartAreas[0].RecalculateAxesScale();
                            }
                            else
                            {
                                foreach (KeyValuePair<DateTime, double> result in chartTuple.Item3.results)
                                {
                                    if (currentMonth.Month == result.Key.Month)
                                    {
                                        monthlyValue += result.Value;
                                    }
                                    else
                                    {

                                        chartTuple.Item2.Points.AddXY(currentMonth.ToShortDateString(), monthlyValue);
                                        currentMonth = currentMonth.AddMonths(1);
                                        monthlyValue = result.Value;
                                    }
                                }
                                chartTuple.Item2.Points.AddXY(currentMonth.ToShortDateString(), monthlyValue);
                                chart1.ChartAreas[0].RecalculateAxesScale();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

        }

    }
   
}

