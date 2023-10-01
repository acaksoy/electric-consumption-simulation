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
        //List<Record> productionRecords = null;
        //List<Record> consumptionRecords = null;
        List<Record> records; //=null;
        Dictionary<int, Record> indexRecordPairs = new Dictionary<int, Record>();
        int totalProductionIndex = 0;
        int totalConsumptionIndex = 0;

        double yearlyTotalProduction = 0;
        double yearlyTotalConsumption = 0;

        Dictionary<CheckBox, Series> checkboxSeriesPair = new Dictionary<CheckBox, Series>();
        List<Tuple<CheckBox, Series, Record>> chartTupleList = new List<Tuple<CheckBox, Series, Record>>();
        public DisplayResult(List<Record> records)//List<Record> productionRecords, List<Record> consumptionRecords
        {
            InitializeComponent();
            //this.productionRecords = productionRecords;
            //this.consumptionRecords = consumptionRecords;
            this.records = records;
            Record totalConRec = records.Find(x => x.Name == "Total Elec. Consumption");
            foreach (KeyValuePair<DateTime, double> pair in totalConRec.results)
            {
                yearlyTotalConsumption += pair.Value;
            }
            yearlyTotalConsumptionLabel.Text += $" {yearlyTotalConsumption}";
            Record totalProdRec = records.Find(x => x.Name == "Total Elec. Prod. Renewable");
            foreach (KeyValuePair<DateTime, double> pair in totalProdRec.results)
            {
                yearlyTotalProduction += pair.Value;
            }
            yearlyTotalProductionLabel.Text += $" {yearlyTotalProduction}";
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
                //checkboxSeriesPair.Add(checboxes[i], series);
                checkboxes[i].Text = records[i].Name;

            }
            chart1.ChartAreas[0].AxisY.Title = "kW";
            chart1.ChartAreas[0].CursorX.AutoScroll = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
            chart1.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 10);

            /*for (int i = 0; i < productionRecords.Count; i++)
            {
                int index = resultsComboBox.Items.Add($"Electricity production from {productionRecords[i].Name}");
                indexRecordPairs.Add(index, productionRecords[i]);

                if (checkboxes[i].Tag == "Production")
                {

                    Series series = chart1.Series.Add(productionRecords[i].Name);
                    series.ChartType = SeriesChartType.Line;
                    series.Enabled = false;
                    chartTupleList.Add(new Tuple<CheckBox, Series, Record>(checkboxes[i], series, productionRecords[i]));
                    //checkboxSeriesPair.Add(checboxes[i], series);
                    checkboxes[i].Text = series.Name;
                }
            }
            for (int i = 0; i < consumptionRecords.Count; i++)
            {
                int index = resultsComboBox.Items.Add($"Electricity production from {consumptionRecords[i].Name}");
                indexRecordPairs.Add(index, consumptionRecords[i]);

                if (checkboxes[i].Tag == "Consumption")
                {
                    Series series = chart1.Series.Add(consumptionRecords[i].Name);
                    series.ChartType = SeriesChartType.Area;
                    series.Enabled = false;
                    chartTupleList.Add(new Tuple<CheckBox, Series, Record>(checkboxes[i], series, consumptionRecords[i]));
                    //checkboxSeriesPair.Add(checboxes[i], series);
                    checkboxes[i].Text = series.Name;
                }
            }*/

            /*foreach (Record record in productionRecords)
            {
                int index = resultsComboBox.Items.Add($"Electricity production from {record.Name}");
                indexRecordPairs.Add(index, record);
            }
            foreach (Record record in consumptionRecords)
            {
                int index = resultsComboBox.Items.Add($"Electricity consumption from {record.Name}");
                indexRecordPairs.Add(index, record);
            }

            totalConsumptionIndex = resultsComboBox.Items.Add("Total Consumption");
            totalProductionIndex = resultsComboBox.Items.Add("Total Production");*/



            //chart1.ChartAreas[0].AxisX.Interval = 1;
            //chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

            //chart1.ChartAreas[0].AxisY.Interval = 20;


            //chart1.ChartAreas[0].AxisY.ScaleView.Zoom(0, 500);
        }
        private void CheckBox_Checked(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            foreach (Tuple<CheckBox, Series, Record> chartTuple in chartTupleList)
            {
                if (cb == chartTuple.Item1)
                {
                    chartTuple.Item2.Enabled = cb.Checked;
                    chart1.ChartAreas[0].RecalculateAxesScale();
                    return;
                }
            }
            /*foreach (KeyValuePair<CheckBox, Series> csPair in checkboxSeriesPair)
            {
                if (cb == csPair.Key)
                {
                    csPair.Value.Enabled = cb.Checked;
                    return;
                }
            }*/
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
            Button button = (Button)sender;
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
                            chart1.ChartAreas[0].AxisX.Title = "Hours";
                            chartTuple.Item2.ChartType = SeriesChartType.Spline;
                            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
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
                            DateTime currentDay = records[0].results.Keys.First<DateTime>();
                            double dailyValue = 0;
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
                            chartTuple.Item2.Points.AddXY(currentDay.ToShortDateString(), dailyValue);
                            chart1.ChartAreas[0].RecalculateAxesScale();
                            break;
                        case "Monthly":
                            chart1.ChartAreas[0].AxisX.Title = "Monthly";
                            chartTuple.Item2.ChartType = SeriesChartType.Column;
                            chart1.ChartAreas[0].AxisX.Interval = 1;
                            DateTime currentMonth = records[0].results.Keys.First<DateTime>();
                            double monthlyValue = 0;
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
                            break;
                        default:
                            break;
                    }
                }
            }

        }

    }
    /* 
                 chart1.Titles.Clear();
            chart1.Series.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            List<DateTime> dates = new List<DateTime>(consumptionRecords[0].results.Keys);

            DataGridView1.Columns.Clear();
            DataGridView1.Columns.Add("DateColumn", "Date");
            if (resultsComboBox.SelectedIndex == totalConsumptionIndex)
            {
                DataGridView1.Columns.Add("Value1", "Total Consumption");
                chart1.Titles.Add("Total Consumption");
                chart1.Series.Add("Total Consumption");
                chart1.Series["Total Consumption"].ChartType = SeriesChartType.Area;
                foreach (DateTime date in dates)
                {
                    double totalConsump = 0;
                    foreach (Record record in consumptionRecords)
                    {
                        foreach (KeyValuePair<DateTime, double> result in record.results)
                        {
                            if (result.Key == date)
                            {
                                totalConsump += result.Value;
                                break;
                            }
                        }
                    }
                    DataGridView1.Rows.Add(date.ToString(), totalConsump);
                    chart1.Series["Total Consumption"].Points.AddXY(date.ToString(), totalConsump);
                }
                return;
            }
            if (resultsComboBox.SelectedIndex == totalProductionIndex)
            {
                DataGridView1.Columns.Add("Value1", "Total Production");
                chart1.Titles.Add("Total Production");
                chart1.Series.Add("Total Production");
                chart1.Series["Total Production"].ChartType = SeriesChartType.Area;
                foreach (DateTime date in dates)
                {
                    double totalProduction = 0;
                    foreach (Record record in productionRecords)
                    {
                        foreach (KeyValuePair<DateTime, double> result in record.results)
                        {
                            if (result.Key == date)
                            {
                                totalProduction += result.Value;
                                break;
                            }
                        }
                    }
                    DataGridView1.Rows.Add(date.ToString(), totalProduction);
                    chart1.Series["Total Production"].Points.AddXY(date.ToString(), totalProduction);
                }
                return;
            }
            Record selectedRecord = indexRecordPairs[resultsComboBox.SelectedIndex];
            chart1.Titles.Add(selectedRecord.Name);
            chart1.Series.Add(selectedRecord.Name);
            chart1.Series[selectedRecord.Name].ChartType = SeriesChartType.Area;

            DataGridView1.Columns.Add("Value1", selectedRecord.Name);
            foreach (KeyValuePair<DateTime, double> result in selectedRecord.results)
            {
                DataGridView1.Rows.Add(result.Key.ToString(), result.Value);
                chart1.Series[selectedRecord.Name].Points.AddXY(result.Key.ToString(), result.Value);
            }
        }
     
     */
}

