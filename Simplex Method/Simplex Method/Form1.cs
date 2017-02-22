using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simplex_Method
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { double[,] table = new double[6, dataGridView1.ColumnCount];
            try
            {
               

                for (int i = 0; i < 6; i++)
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        if (i != 6 - 1)
                            table[i, j] = Int32.Parse(dataGridView1[j - 1, i].Value.ToString());
                        else
                            table[i, j] = -Int32.Parse(dataGridView1[j - 1, i].Value.ToString());
                    }
                }

                for (int i = 0; i <6; i++)
                {
                    table[i, 0] = Int32.Parse(dataGridView1[dataGridView1.ColumnCount - 1, i].Value.ToString());
                }
            }
            catch(Exception )
            {
                double[,] table1 = { {31, 2, 3 },
                                {12, 1,1},
                                {20, 2,1},
                                {0, -40,-25} };
                table = table1;
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 1; j < 3; j++)
                    {
                        if (i != 4 - 1)
                         dataGridView1[j - 1, i].Value=   table[i, j]  ;
                        else
                            dataGridView1[j - 1, i].Value=- table[i, j] ;
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    dataGridView1[dataGridView1.ColumnCount - 1, i].Value=  table[i, 0];
                }
            }
            double[] result = new double[2];
            List<double[,]> table_result1;
           
            Simplex S = new Simplex(table);
            table_result1 = S.Calculate(result);
double[,] table_result=table_result1[table_result1.Count-1];
            if (checkBox1.Checked == false)
            {   
                richTextBox1.Text += ("Кінцевий результат\nРез\tx1\tx2\tx3\tx4\tx5\n");
                for (int i = 0; i < table_result.GetLength(0); i++)
                {
                    for (int j = 0; j < table_result.GetLength(1); j++)
                        richTextBox1.Text += (table_result[i, j] + "\t");
                    richTextBox1.Text += ("\n");


                }
            }
            else
            {
              
                for (int h=0;h< table_result1.Count ;h++)
                {
                    table_result = table_result1[h];

                    richTextBox1.Text += ("Крок"+(h+1)+"\n");
                    richTextBox1.Text += ("Рез\tx1\tx2\tx3\tx4\tx5\n");
                    for (int i = 0; i < table_result.GetLength(0); i++)
                    {
                        for (int j = 0; j < table_result.GetLength(1); j++)
                            richTextBox1.Text += (table_result[i, j] + "\t");
                        richTextBox1.Text += ("\n");


                    }
                }
            }
            table_result = table_result1[table_result1.Count - 1];
            richTextBox1.Text += ("Розв`язок:");
            richTextBox1.Text += ("\nX[1] = " + result[0]);
            richTextBox1.Text += ("\nX[2] = " + result[1]);
            richTextBox1.Text += ("\nМаксимальне значення = " + table_result[3,0]);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
    }
