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

        private void Form1_Load(object sender, EventArgs e)
        {
            
            for (int i = 1; i <= 52; i++)
            {
                poke.Add(i);
            }

        }

        public List<int> poke = new List<int>();


    private void button1_Click(object sender, EventArgs e)
        {
            //順序數字
            //List<int> poke = new List<int>();
            //for (int i = 1; i <= 52; i++)
            //{
            //    poke.Add( 0 );
            //}

            List<int> poke = new List<int>();
            

            for (int i = 1; i <= 52; i++)
            {
                poke.Add(i);

            }

            int[] b = new int[52];
            Random r = new Random();

            for (int i = 0; i <=51; i++)
            {
                b[i] = r.Next(1, 52);
                //撲克牌兩個位置進行交換
                for (int j = 1; j < i; j++)
                {
                    while (b[j] == b[i])    //檢查是否與前面產生的數值發生重複，如果有就重新產生
                    {
                        j = 1;  //如有重複，將變數j設為0，再次檢查 (因為還是有重複的可能)
                        b[i] = r.Next(1, 52);   //重新產生，存回陣列，亂數產生的範圍是1~9
                    }
                }

            }

            b = b.Distinct().ToArray();

            //我這邊需要一個int的陣列來塞入我要的數值
            //所以來個
            //int[] aa = new int[52];    //你喜歡也可以用10....

            //然後為了不想要數字很死，所以用個random來產生數字
            // Random a = new Random();
            // for (int i = 1; i <= 52; i++)
            //  {
            //      aa[i] = a.Next(0, 99);
            //   }



            //打亂順序

            //for (int i = 1; i <= 52; i++)
            //{
            //    Random r = new Random();
            //    //用來儲存隨機生成的不重複的52個數
            //    int[] result = new int[52];
            //    int site = 52;//設定上限
            //    int id;
            //    for (int j = 1; j <=52; j++)
            //    {
            //        id = r.Next(1, site - 1);
            //        //在隨機位置取出一個數，儲存到結果陣列
            //        result[j] = poke[id];
            //        //最後一個數複製到當前位置
            //        poke[id] = poke[site - 1];
            //        //位置的上限減少一
            //        site--;
            //    }
            //}
        }

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
    }
}
