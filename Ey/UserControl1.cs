using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ey
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline; // тут сами поизменяет/повыбирайте тип вывода графика
            int n = dataGridView1.RowCount;
            for (int i = 0; i < n; i++)
            {
                if (dataGridView1[0, i].Value == null || dataGridView1[1, i].Value == null)
                {
                    MessageBox.Show(
                            "Пустое значение в строке " + (i + 1),
                            "Сообщение",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                    continue;
                }
                else
                {
                    try
                    {
                        chart1.Series[0].Points.AddXY(
                            Convert.ToDouble(dataGridView1[0, i].Value),
                            Convert.ToDouble(dataGridView1[1, i].Value));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Неверный ввод в строке " + (i + 1),
                            "Сообщение",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null ||
                !head.Equals((e.RowIndex + 1).ToString()))
                this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value =
                    (e.RowIndex + 1).ToString();
        }
    }
}
