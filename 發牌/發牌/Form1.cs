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


        private void Form1_Load(object sender, EventArgs e)
        {
            
            for (int i = 1; i <= 52; i++)
            {
                poke.Add(i);
            }

        }

        public List<int> poke = new List<int>();



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            richTextBox1.Clear();

            for (int i = 1; i <= 52; i++)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<int> poke = new List<int>();


            for (int i = 1; i <= 52; i++)
            {
                poke.Add(i);

            }


            int[] b = new int[52];
            Random r = new Random();

            for (int i = 0; i <= 51; i++)
            {
                b[i] = r.Next(1, 53);
                //撲克牌兩個位置進行交換
                for (int j = 0; j < i; j++)
                {
                    while (b[j] == b[i])    //檢查是否與前面產生的數值發生重複，如果有就重新產生
                    {
                        j = 0;  //如有重複，將變數j設為0，再次檢查 (因為還是有重複的可能)
                        b[i] = r.Next(1, 53);   //重新產生，存回陣列，亂數產生的範圍是1~9

                       
                    }
                    
                }

            }



            var bt = b.Distinct().ToArray();

            var only = b.GroupBy(x => x).Where(x => x.Count() > 1).SelectMany(x => x).ToList();


            var test = b.OrderBy(x => x).ToList();


            //int[] a= new int[20];
            //Random random= new Random();
            //for (int i = 0; i < 2; i++)
            //{
            //    a[i]= random.Next(1,3);
            //} 測試random臨界值
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int numberPeople = int.Parse(textBox1.Text);
            if (numberPeople>=1 && numberPeople<=52)
            {
                則將牌數除以人數並分發相對應人數然後顯示在表單中
            }

            else
            {
                則顯示提醒並且重新輸入人數
            }







            //發牌
            int number = int.Parse(textBox1.Text);//double可改int
            if (number < 1 || number > 52)
            {
                MessageBox.Show("只能輸入1~52哦！");
                return;
            }

            

            List<int> poke = new List<int>();
            for (int i = 1; i <= 52; i++)
            {
                poke.Add(i);
                List<int> takeList = poke.Take(number).ToList();
                List<List<int>> ListGroup = new List<List<int>>();
                //分組
                for (int j = 1; j <= 52; j++)
                {
                    ListGroup.Add(poke.Take(number).ToList());
                }

                int count = 1;
                foreach (List<int> Item in ListGroup)
                {
                    Console.WriteLine(string.Format("第{0}組", count));
                    foreach (int num in Item)
                    {
                        Console.Write(num + "");
                    }
                    Console.WriteLine();
                    count++;

                }
                Console.Read();
            }
        }
    }
}
