using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 發牌
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
      


        private void button2_Click(object sender, EventArgs e)
        {

            //發牌
            int number = int.Parse(textBox1.Text);//double可改int
            if (number <= 52 && number >= 1)
            {
                return;
            }

            MessageBox.Show("只能輸入1~52哦！");

            List<int> poke = new List<int>();
            for (int i = 1; i <=52; i++)
            {
                poke.Add(i);
                List<int> takeList = poke.Take(number).ToList() ;
                List<List<int>> ListGroup = new List<List<int>>();
                //分組
                for (int j = 1; j <= 52 ; j++)
                {
                    ListGroup.Add(poke.Take(number).ToList());
                }

                int count = 1;
                foreach(List<int> Item in ListGroup)
                {
                    Console.WriteLine(string.Format("第{0}組",count));
                    foreach(int num in Item )
                    {
                        Console.Write(num + "");
                    }
                    Console.WriteLine();
                    count++;

                }
                Console.Read();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> poke = new List<int>();
            for (int i = 1 ; i <=52 ; i++)
            {
                poke.Add(i);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //順序數字
            List<int> poke = new List<int>();
            for (int i = 1; i <=52 ; i++)
            {
                poke.Add(new int());

            }

            //打亂順序
            List<int> ints = new List<int>();
            for (int i = 1; i <=52; i++)
            {
                int currenIndex = Random (52, i);
                poke.RemoveAt(currenIndex);
            }
        }

        private int Random(int v, int i)
        {
            throw new NotImplementedException();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            richTextBox1.Clear();

            for (int i = 1; i <=52 ; i++)
            {
                if (i % 52 == 0)
                {
                    richTextBox1.AppendText(i + "\r\n");
                    num += i;
                }
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 1; i < this.dataGridView1.Rows.Count; i++)

            {

                DataGridViewRow r = this.dataGridView1.Rows[i];

                r.HeaderCell.Value = string.Format("{1}", i + 1);

            }

            this.dataGridView1.Refresh();
        }
    }
}
