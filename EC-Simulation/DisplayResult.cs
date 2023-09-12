using SimulationClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        List<Record> productionRecords = null;
        List<Record> consumptionRecords = null;

        Dictionary<int, Record> indexRecordPairs = new Dictionary<int, Record>();
        int totalProductionIndex = 0;
        int totalConsumptionIndex = 0;
        public DisplayResult(List<Record> productionRecords, List<Record> consumptionRecords)
        {
            InitializeComponent();
            this.productionRecords = productionRecords;
            this.consumptionRecords = consumptionRecords;

            foreach (Record record in productionRecords)
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
            totalProductionIndex = resultsComboBox.Items.Add("Total Production");
            resultsComboBox.SelectedItem = 0;

        }

        private void ComboBox_Selected(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Title = "Months";
            chart1.ChartAreas[0].AxisY.Title = "kWh";
            chart1.ChartAreas[0].CursorX.AutoScroll = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 1000);

            chart1.Titles.Clear();
            chart1.Series.Clear();


            List<DateTime> dates = new List<DateTime>(consumptionRecords[0].results.Keys);


            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            DataGridView1.Columns.Clear();
            DataGridView1.Columns.Add("DateColumn", "Date");
            if (resultsComboBox.SelectedIndex == totalConsumptionIndex)
            {
                DataGridView1.Columns.Add("Value1", "Total Consumption");
                chart1.Titles.Add("Total Consumption");
                chart1.Series.Add("Total Consumption");
                chart1.Series["TotalConsumption"].ChartType = SeriesChartType.Area;
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
            /*foreach (KeyValuePair<int, Record> iRPair in indexRecordPairs)
            {
                if (resultsComboBox.SelectedIndex == iRPair.Key)
                {
                    DataGridView1.Columns.Add("Value1", iRPair.Value.Name);
                    foreach (KeyValuePair<DateTime, double> result in iRPair.Value.results)
                    {
                        DataGridView1.Rows.Add(result.Key.ToString(), result.Value);
                        chart1.Series[iRPair.Value.Name].Points.AddXY(result.Key.ToString(), result.Value);
                    }
                }
            }*/
        }


    }
}

/*
 foreach (KeyValuePair<int, Record> iRPair in indexRecordPairs)
            {
                if (resultsComboBox.SelectedIndex == iRPair.Key)
                {
                    DataGridView1.Columns.Add("Value1", iRPair.Value.Name);
                    foreach (KeyValuePair<DateTime, double> result in iRPair.Value.results)
                    {
                        DataGridView1.Rows.Add(result.Key.ToString(), result.Value);
                        chart1.Series[iRPair.Value.Name].Points.AddXY(result.Key.ToString(), result.Value);
                    }
                }
            }
 
 */
