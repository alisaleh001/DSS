using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Methods_Task
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        int NumProject = Form1.numberProject;
        int NumCondtion = Form1.numberCondtion;
        decimal big = 0;
        decimal big2 = 0;

        decimal numEqually = 0;
        decimal vr = 0;
        decimal numberOfRow;
        decimal Number;


        List<decimal> list = new List<decimal>();
        List<decimal> list2 = new List<decimal>();
        List<decimal> list3 = new List<decimal>();
        List<decimal> list4 = new List<decimal>();



        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;

            for (int j = 1; j < NumCondtion + 1; j++)
            {
                dataGridView1.Columns.Add("Condition" + j, "Condition :>" + j);
            }

            for (int i = 1; i < NumProject + 1; i++)
            {
                dataGridView1.Rows.Add("Project :>" + i);
            }

            for (int j = 1; j < NumCondtion + 1; j++)
            {
                dataGridView3.Columns.Add("Condition" + j, "Condition :>" + j);
            }

            for (int i = 1; i < NumProject + 1; i++)
            {
                dataGridView3.Rows.Add("Project :>" + i);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            groupBox2.Text = "Pick The Max Value For Or Each Alternative";
            dataGridView3.Visible = false;
            label2.Visible = false;

            list.Clear();
            list2.Clear();
            dataGridView2.Rows.Clear();

            dataGridView2.Columns[1].HeaderText = "Max Value";

            for (int k = 0; k < dataGridView1.Rows.Count; k++)
            {
                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                {
                    if (decimal.TryParse(dataGridView1.Rows[k].Cells[i].Value.ToString(), out big))
                    {
                        list.Add(big);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect value!");
                        return;

                    }
                }
                list2.Add(list.Max());

                //dataGridView2.Rows.Add("Project => " + (k + 1) + " -Max Value => " + list.Max());

                dataGridView2.Rows.Add("Project => " + (k+1));
                dataGridView2.Rows[k].Cells[1].Value = list.Max();

                list.Clear();
            }

            label1.Text = "Then Pick The Alternative With Max Payoff := " + list2.Max().ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            groupBox2.Text = "Pick The Min Value For Or Each Alternative";
            dataGridView3.Visible = false;
            label2.Visible = false;
            list.Clear();
            list2.Clear();
            dataGridView2.Rows.Clear();

            dataGridView2.Columns[1].HeaderText = "Min Value";

            for (int k = 0; k < dataGridView1.Rows.Count; k++)
            {
                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                {
                    if (decimal.TryParse(dataGridView1.Rows[k].Cells[i].Value.ToString(), out big))
                    {
                        list.Add(big);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect value!");
                        return;

                    }
                }
                list2.Add(list.Min());

                //dataGridView2.Rows.Add("Project => " + (k + 1) + " -Max Value => " + list.Max());

                dataGridView2.Rows.Add("Project => " + (k + 1));
                dataGridView2.Rows[k].Cells[1].Value = list.Min();

                list.Clear();
            }

            label1.Text = "Then Pick The Alternative With Min Payoff := " + list2.Max().ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Count = 0;
            int Count2 = 1;

            #region
            groupBox2.Text = "Calculate The Maximum For Each Outcome";
            dataGridView3.Visible = true;
            label1.Text = "";
            list.Clear();
            list2.Clear();
            dataGridView2.Rows.Clear();

            dataGridView2.Columns[1].HeaderText = "Maximum Value";

            dataGridView2.Rows.Clear();
            #endregion
            #region
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                for (int k = 0; k < dataGridView1.Rows.Count; k++)
                {
                    if (decimal.TryParse(dataGridView1.Rows[k].Cells[i].Value.ToString(), out big))
                    {
                        list.Add(big);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect value!");
                        return;

                    }

                }

                list2.Add(list.Max());

                dataGridView2.Rows.Add("Economic Condition => " + (i));
                dataGridView2.Rows[i-1].Cells[1].Value = list.Max();

                Number = list.Max();
                Count = 0;
                foreach (decimal number in list)
                {
                    numberOfRow = Number - number;

                    dataGridView3.Rows[Count].Cells[Count2].Value = numberOfRow;
                    Count++;
                }
                Count2++;

                list.Clear();
             

            }
            #endregion

            for (int k = 0; k < dataGridView3.Rows.Count; k++)
            {
                for (int i = 1; i < dataGridView3.Columns.Count; i++)
                {
                    if (decimal.TryParse(dataGridView3.Rows[k].Cells[i].Value.ToString(), out big2))
                    {
                        list3.Add(big2);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect value!");
                        return;

                    }
                }
                list4.Add(list3.Max());


                list3.Clear();
            }

           
                label2.Text = "Pick The Alternative With Minimum regret := " + list4.Min().ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Text = "Equally Likely Criterion";
            dataGridView3.Visible = false;
            label2.Visible = false;

            list.Clear();
            list2.Clear();
            dataGridView2.Rows.Clear();

            dataGridView2.Columns[1].HeaderText = "Average Payoff";

            for (int k = 0; k < dataGridView1.Rows.Count; k++)
            {
                numEqually = 0;

                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                {
                    if (decimal.TryParse(dataGridView1.Rows[k].Cells[i].Value.ToString(), out vr))
                    {
                        numEqually += decimal.Parse(dataGridView1.Rows[k].Cells[i].Value.ToString());

                        list.Add(numEqually / (dataGridView1.Columns.Count - 1));
                    }
                    else
                    {
                        MessageBox.Show("Incorrect value!");
                        return;
                    }

                   
                }
                list2.Add(list.Max());

                //dataGridView2.Rows.Add("Project => " + (k + 1) + " -Max Value => " + list.Max());

                dataGridView2.Rows.Add("Project => " + (k + 1));
                dataGridView2.Rows[k].Cells[1].Value = list.Max();

                list.Clear();
            }

            label1.Text = "Then Pick The Alternative With Max Payoff := " + list2.Max().ToString();
        }
    }
 }

        


