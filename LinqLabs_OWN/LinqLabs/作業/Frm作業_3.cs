using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_3 : Form
    {
        public Frm作業_3()
        {
            InitializeComponent();
        }

        private string MyFilter(int n, int[] arr)
        {
            Array.Sort(arr);
            int count = arr.Count();
            int smaill = arr[Convert.ToInt32(count * 0.3) - 1];
            int large = arr[Convert.ToInt32(count * 0.8) - 1];

            //MessageBox.Show($"smaill : {smaill}  large : {large}");

            if (n <= smaill)
            {
                return "small";
            }
            else if (n > smaill && n < large)
            {
                return "medium";
            }
            else 
            {
                return "large";
            }
            
        }
        private void butNoLinq_Click(object sender, EventArgs e)
        {
            //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] nums = { 1, 11, 2, 14, 9, 6, 7, 8, 5, 10, 3, 12, 13, 4, 15 };
            //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };



            List<int> smallArr = new List<int> { };
            List<int> mediumArr = new List<int> { };
            List<int> largeArr = new List<int> { };

            //MyFilter(1, nums);
            
            //分類
            foreach (int n in nums)
            {
                string result = MyFilter(n, nums);

                switch (result)
                {
                    case "small":
                        smallArr.Add(n);
                        break;

                    case "medium":
                        mediumArr.Add(n);
                        break;

                    case "large":
                        largeArr.Add(n);
                        break;
                }                
            }


            //輸出
            string str = "small : \n";
            foreach (int s in smallArr) 
            {
                str += $"{s}," ;
            }

            str += "\nmedium:\n";
            foreach (int m in mediumArr)
            {
                str += $"{m},";
            }
            str += "\nlarge:\n";
            foreach (int l in largeArr)
            {
                str += $"{l},";
            }

            MessageBox.Show(str);


        }


        private string myPriceFilter(decimal n, decimal[] arr) 
        {
            int count = arr.Length;

            decimal small = arr[Convert.ToInt32(count * 0.3) - 1];
            decimal large = arr[Convert.ToInt32(count * 0.8) - 1];

            if (n <= small)
            {
                return "small";
            }
            else if (n > small && n < large)
            {
                return "medium";
            }
            else 
            {
                return "large";
            }
        }

        //NW Products 低中高 價產品 
        private void button8_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);

            //取得所有UnitPrice
            var queryOrderbyPrice = nwDataSet1.Products
                                                            .Select(p => Convert.ToDecimal(p.UnitPrice))
                                                            .OrderBy(p => p)
                                                            .ToArray();

            //分群
            var query = nwDataSet1.Products
                                .OrderBy(p => p.UnitPrice)
                                .GroupBy(p => myPriceFilter(p.UnitPrice, queryOrderbyPrice))
                                .Select(g => new
                                {
                                    category = g.Key,
                                    myCount = g.Count(),
                                    myGroup = g
                                })
                                ;

            // add to treeview
            treeView1.Nodes.Clear();
            foreach (var group in query)
            {
                string headerNode = $"{group.category}[{group.myCount}]";
               TreeNode treeNode =  treeView1.Nodes.Add(headerNode);

                foreach (var item in group.myGroup)
                {
                    treeNode.Nodes.Add($"[{item.ProductID}] {item.ProductName} - ${item.UnitPrice:N2}");

                }

            }
        }

 
    }
}
