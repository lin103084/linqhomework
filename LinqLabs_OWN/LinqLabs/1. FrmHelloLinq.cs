using LinqLabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmHelloLinq : Form
    {
        public FrmHelloLinq()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // 理解 List<>內 實作的interface GetEnumerator() method
        private void butListEnumerator_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            listBox1.Items.Clear();
            // 語法糖
            foreach (int i in list)
            {
                this.listBox1.Items.Add(i);
            }
            //========================================
            //底層實作
            this.listBox1.Items.Add("========================");
            List<int>.Enumerator en = list.GetEnumerator();
            while (en.MoveNext())
            {
                this.listBox1.Items.Add((int)en.Current);
            }

        }

        // 理解 Array 內 實作的interface GetEnumerator() method
        private void butArrayEnumerator_Click(object sender, EventArgs e)
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            listBox1.Items.Clear();
            foreach (int i in nums)
            {
                this.listBox1.Items.Add(i);
            }

            //底層實作
            this.listBox1.Items.Add("========================");
            System.Collections.IEnumerator en = nums.GetEnumerator();
            while (en.MoveNext())
            {
                this.listBox1.Items.Add((int)en.Current);
            }
        }

        //測試LINQ 查詢 
        private void butTasteOfLinqArray_Click(object sender, EventArgs e)
        {
            //step 1: define source
            //step 2: define query
            //step 3: execute query - foreach
            listBox1.Items.Clear();

            // step 1 source
            int[] sourceNums = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // step 2 Linq Query define (尚未使用，僅是定義LINQ查詢)
            IEnumerable<int> q = from n in sourceNums
                                     //where n % 2 == 0 
                                     //            && n >= 5 
                                     //            && n <= 10

                                 where n > 0
                                 select n;

            // step 3 執行 Linq Query (使用已定義LINQ查詢)
            foreach (int n in q)
            {
                listBox1.Items.Add(n);
            }

        }






        bool isEven(int n)
        {
            if (n % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //測試Array使用LINQ查詢搭配call method
        private void butTasteOfLinqArrayIsEven_Click(object sender, EventArgs e)
        {
            
            int[] nums = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> q = from n in nums
                                 where isEven(n)
                                 select n;

            listBox1.Items.Clear();
            foreach (int n in q)
            {
                listBox1.Items.Add(n);
            }

        }

        //測試List<T>使用LINQ查詢搭配call method
        private void butTasteOfLinqAnyType_Click(object sender, EventArgs e)
        {
            
            int[] nums = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<Point> q = from n in nums
                                   where isEven(n)
                                   select new Point(n, n * n);

            listBox1.Items.Clear();
            foreach (Point n in q)
            {
                listBox1.Items.Add(n.X + ":" + n.Y);
            }

            //========================
            //execute query Toxxxx()
            List<Point> list = q.ToList();  // back foreach(... in q)
            this.dataGridView1.DataSource = list;


            //========================
            this.chart1.DataSource = list;
            this.chart1.Series[0].XValueMember = "X";
            this.chart1.Series[0].YValueMembers = "Y";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        //測試使用array string 使用LINQ查詢
        private void butTasteOfLinqArrayString_Click(object sender, EventArgs e)
        {
            string[] words = { "Apple", "xxxApple", "Pineapple", "xxx", "yyy" };
            IEnumerable<string> q = from w in words
                                    where w.Length > 5 && w.ToLower().Contains("apple")
                                    select w;

            foreach (string w in q)
            {
                this.listBox1.Items.Add(w);
            }
        }

        //NwDataSet 搭配 productsTableAdapter1 LINQ
        private void butNwDataSetProducts_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);

            // define linq query
            IEnumerable<NWDataSet.ProductsRow> q = from p in this.nwDataSet1.Products
                                                   where p.UnitPrice > 30
                                                            && p.ProductName.ToLower().StartsWith("c")
                                                   select p;

            this.dataGridView1.DataSource = q.ToList();


            // 清空 DataGridView
            //dataGridView1.Columns.Clear();
            //dataGridView1.Rows.Clear();

            //// 自訂欄位（這裡示範三個欄位）
            //dataGridView1.Columns.Add("ProductID", "產品ID");
            //dataGridView1.Columns.Add("ProductName", "產品名稱");
            //dataGridView1.Columns.Add("UnitPrice", "單價");


            //foreach (NWDataSet.ProductsRow item in q)
            //{
            //    dataGridView1.Rows.Add(item.ProductID, item.ProductName, item.UnitPrice);
            //}

        }

        //NwDataSet 搭配 ordersTableAdapter1 LINQ
        private void butNwDataSetOrders_Click(object sender, EventArgs e)
        {
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);

            //define link query
            IEnumerable<NWDataSet.OrdersRow> q = from o in this.nwDataSet1.Orders
                                                 where o.OrderDate.Year >= 1997

                                                 select o;

            this.dataGridView1.DataSource = q.ToList();

        }
    }
}
