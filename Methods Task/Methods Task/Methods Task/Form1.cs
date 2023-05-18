using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Methods_Task
{
    public partial class Form1 : Form
    {
        public static int numberProject = 0;
        public static int numberCondtion = 0;

        int NumProject;
        int NumCondtion;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textNumProject.Text ))
            {
              
                if (int.TryParse(textNumProject.Text, out NumProject))
                {
                    if(NumProject== 0 || NumProject>10) 
                    {
                        MessageBox.Show("Incorrect Num of Project value!");
                        return;
                    }
                    else
                    {
                        numberProject = NumProject;
                       
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Num of Project value!");
                    return;

                }
            }

            if (!string.IsNullOrEmpty(textNumCondition.Text))
            {

                if (int.TryParse(textNumCondition.Text, out NumCondtion))
                {
                    if (NumProject == 0 || NumProject > 10)
                    {
                        MessageBox.Show("Incorrect Num of Condtion value!");
                        return;

                    }
                    else
                    {
                        numberCondtion = NumCondtion;

                     
                    }

                }
                else
                {
                    MessageBox.Show("Incorrect Num of Condtion value!");
                    return;

                }
            }

            Form2 Fr2 = new Form2();
            Fr2.ShowDialog();

        }
    }
}
