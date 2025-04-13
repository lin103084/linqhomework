using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;
using static System.Windows.Forms.LinkLabel;
using System.Reflection;

namespace Starter
{
    public partial class FrmLINQ_To_XXX : Form
    {
        public FrmLINQ_To_XXX()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        //  --------------------  METHOD -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string MyGroupBySplit(int n)
        {
            if (n <= 3)
            {
                return "Smaill";
            }
            else if (n <= 7)
            {
                return "Medium";
            }
            else
            {
                return "Large";
            }
        }
        //  --------------------  METHOD -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        // --------------------Linq Operator:  Select/Where/Group/Order/Join / Others -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void butLinqOperato_Click(object sender, EventArgs e)
        {
            int[] nums1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] nums2 = { 1, 3, 5, 7, 9, };

            IEnumerable<int> query;

            query = nums1.Intersect(nums2);
            query = nums1.Union(nums2);

            // bool
            bool result;
            result = nums1.Any(n => n > 0);
            //MessageBox.Show(result.ToString());
            result = nums1.All(n => n > 5);
            //MessageBox.Show(result.ToString());
        }
        // --------------------Linq Operator:  Select/Where/Group/Order/Join / Others -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // -------------------- 分組彙總運算子 - Group  / Aggregate -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void butGroupBy_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            #region 上課中的
            //var query = from n in nums
            //            group n by (n % 2);

            IEnumerable<IGrouping<string, int>> query = from n in nums
                                                     group n by (n % 2 == 0 ? "偶數" : "奇數");
            
            //this.dataGridView1.DataSource = query.ToList();

            
            // Add to treeview
            //foreach (var group in query) 
            //{
            //    string headerKey = $"{group.Key} [{group.Count()}]";
            //    TreeNode treeNode = treeView1.Nodes.Add(headerKey);
            //    //MessageBox.Show(q.Key);
            //    foreach (var item in group) 
            //    {
            //        treeNode.Nodes.Add(item.ToString());
                    
            //        //MessageBox.Show(item.ToString());
            //    }
            //}

            // Add to listview

            //foreach (var group in query)
            //{
            //    string headerKey = $"{group.Key} [{group.Count()}]";
            //    ListViewItem listViewItem =  listView1.Items.Add(headerKey);
                
            //    foreach (var item in group)
            //    {
                 
            //        //listViewItem.SubItems.Add(item.ToString());

                 
            //    }
            //}

            #endregion

            //==========================================================
            #region exercise
            // query
            IEnumerable<IGrouping<string, int>> query2 = from n in nums
                                                                                                        group n by n % 2 == 0 ? "偶數" : "奇數";
            dataGridView1.DataSource = query2.ToList();

            // linq method

            IEnumerable<IGrouping<string, int>> queryLinq = nums
                                                                                                            .GroupBy(n => n % 2 == 0 ? "偶數" : "奇數");
            dataGridView2.DataSource = queryLinq.ToList();


            // add To treeview
            foreach(IGrouping<string, int> group in queryLinq) 
            {
                string header = $"{group.Key}({group.Count()})";
                 TreeNode treeNode = treeView1.Nodes.Add(header);
                foreach(var item in group) 
                {
                    treeNode.Nodes.Add(item.ToString());
                }                
            }    
            

            // add To listview
            foreach(IGrouping<string, int> group in queryLinq) 
            {
                string header = $"{group.Key}{group.Count()}";
                 ListViewGroup listViewGroup = listView1.Groups.Add(header, header);

                foreach (int item in group) 
                {
                    listView1.Items.Add(item.ToString()).Group = listViewGroup;
                }
            
            }

            #endregion

        }
        private void butGroupAggregate_Click(object sender, EventArgs e)
        {
            //================== query ==================
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            
            var query = from n in nums
                                                    group n by (n % 2 == 0? "偶數":"奇數") into g
                                                    select new { g.Key, MyCount = g.Count(), MyMin = g.Min(), MyMax = g.Max(), MyAvg = g.Average(), MyGropu = g };

            dataGridView1.DataSource = query.ToList();

            //================== Method ==================
            #region school
            //var query2 = nums.GroupBy(n => n % 2 == 0 ? "偶數" : "奇數")
            //                                    .Select(g => new { g.Key, MyCount = g.Count(), MyMin = g.Min(), MyMax = g.Max(), MyAvg = g.Average(), MyGropu = g });


            //dataGridView2.DataSource = query2.ToList();


            //// Add to treeview
            //foreach (var group in query)
            //{
            //    string headerKey = $"{group.Key} [{group.MyCount}]";
            //    TreeNode treeNode = treeView1.Nodes.Add(headerKey);
            //    //MessageBox.Show(q.Key);
            //    foreach (var item in group.MyGropu)
            //    {
            //        treeNode.Nodes.Add(item.ToString());

            //        //MessageBox.Show(item.ToString());
            //    }
            //}
            #endregion

            #region exercise
            
            //Define query
            var queryLinq = nums
                                           .GroupBy(n => n % 2==0?"偶數":"奇數")
                                           .Select(g => new { g.Key, myCount = g.Count(), myMax = g.Max(), myMin = g.Min(), myAvg = g.Average(), myGroup = g});

            // execute
            dataGridView2.DataSource = queryLinq.ToList();


            //add to treeview

            treeView1.Nodes.Clear();
            foreach (var group in queryLinq) 
            {
                string nodeHeader = $"{group.Key}[{group.myCount}]";
                TreeNode treeNode = treeView1.Nodes.Add(nodeHeader);
                

                foreach (var item in group.myGroup) 
                {
                    treeNode.Nodes.Add(item.ToString());
                }
            
            }

            #endregion

            //============ Add to Char ============

            chart1.DataSource = query.ToList();
            this.chart1.Series[0].XValueMember = "Key";
            this.chart1.Series[0].YValueMembers = "MyCount";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            this.chart1.Series[1].XValueMember = "Key";
            this.chart1.Series[1].YValueMembers = "MyAvg";
            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


        }
        private void butGroupInto_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            var query = nums.GroupBy(n => MyGroupBySplit(n))
                .Select(g => new { g.Key, myCount = g.Count(), myMin = g.Min(), myGroup = g });

            //string s = "";
            MessageBox.Show(nums.Length.ToString());
            dataGridView1.DataSource = query.ToList();


            // Add TreeView

            foreach (var group in query)
            {
                string headerKey = $"{group.Key} [{group.myCount}]";
                TreeNode treeNode = treeView1.Nodes.Add(headerKey);
                //MessageBox.Show(q.Key);
                foreach (var item in group.myGroup)
                {
                    treeNode.Nodes.Add(item.ToString());

                    //MessageBox.Show(item.ToString());
                }
            }

        }
        private string myFilter(int n, int [] arr) 
        {
            int count = arr.Count();
            int small = arr[Convert.ToInt32(count * 0.3)];
            int large = arr[Convert.ToInt32(count * 0.8)];

            //MessageBox.Show($"small : {small.ToString()} / Large : {large.ToString()}");

            if(n <= small) 
            {
                //MessageBox.Show($"{n} :small");
                return "small";
            }
            else if(n>small && n < large) 
            {
                //MessageBox.Show($"{n} :medium");
                return "medium";
            }
            else 
            {
                //MessageBox.Show($"{n} :large");
                return "large";
            }
            

        }

        private void butGroupInto2_Click(object sender, EventArgs e)
        {
            //source
            int[] numsArr = { 1, 200, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            //int[] numsArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //myFilter(17, numsArr);
            //define query
            var query = numsArr
                                .OrderBy(o => o)
                                .GroupBy(n => myFilter(n, numsArr))
                                .Select(g => new { g.Key,myCount = g.Count(),  myGroup = g});


            treeView1 .Nodes.Clear();
            foreach (var group in query) 
            {
                string header = $"{group.Key}[{group.myCount}]";
                TreeNode treeNode = treeView1.Nodes.Add(header);

                foreach ( var item in group.myGroup) 
                {
                    treeNode.Nodes.Add(item.ToString());
                }
            }
        }

      

        // -------------------- 分組彙總運算子 - Group  / Aggregate -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------- LinQ to string ------------------------------------------------------------------------------------------------------------------------------
        private void butStringCount_Click(object sender, EventArgs e)
        {
            //string s = "This is a pen.   this a book.    this is an apple";

            #region school
            //利用此分割
            //char[] splitChar = { ' ', '?', '.' };
            //string[] words = s.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);

            //var query = words.GroupBy(g => g).Select(g => new { g.Key, count = g.Count() });
            //dataGridView1.DataSource = query.ToList();

            #endregion

            #region exercise

            // source
            string str = "This is a pen.   this a book.    this is an apple";
            char[] splitChar = {' ', '?', '.'};
            string [] words = str.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);

            //query
            var linqQuery = words
                                    .GroupBy(g => g)
                                    .Select(g => new { g.Key, myCount = g.Count()})
                                    ;

            dataGridView1.DataSource = linqQuery.ToList();

            //string s = "";
            //foreach (string word in words) 
            //{
            //    s += $"{word}\n";
            //}
            //MessageBox.Show (s);
            //Console.WriteLine(s);

            #endregion
        }
        //-------------------------- LinQ to string ------------------------------------------------------------------------------------------------------------------------------


        //--------------------------  Linq to 檔案目錄------------------------------------------------------------------------------------------------------------------------------

        // 查詢具有指定屬性或名稱的檔案(用 Let)
        private void button3_Click(object sender, EventArgs e)
        {
            #region school
            //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            //System.IO.FileInfo[] files = dir.GetFiles();

            //var query = (from f in files
            //             let s = f.Extension.ToLower()
            //             where s == ".exe"
            //             select f).Count();

            //MessageBox.Show($"count : {query}");
            #endregion

            #region exercise
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(@"c:\windows");
            FileInfo[] file = directoryInfo.GetFiles();
            //DirectoryInfo[] file2 = directoryInfo.GetDirectories();

            // query
            var query = file.Where(f => f.Extension.ToLower() == ".exe");
            dataGridView1.DataSource = query.ToList() ;

            #endregion
        }

        //依副檔名分組檔案 
        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            //this.dataGridView1.DataSource = files;

            var query = files.GroupBy(g => g.Extension)
                .Select(g => new { g.Key, Count = g.Count() });

            dataGridView1.DataSource = query.ToList();

        }

        //--------------------------  Linq to 檔案目錄------------------------------------------------------------------------------------------------------------------------------


        //--------------------------  Linq to DataSet------------------------------------------------------------------------------------------------------------------------------
        // 尋找各分類之平均單價(Inner Join)
        private void button10_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);

            #region school
            //var query = nwDataSet1.Products
            //    .GroupBy(c => c.CategoryID)
            //    .Select(g => new {
            //        id = g.Key,
            //        averageUniprice = g.Average(p => p.UnitPrice)
            //    });

            //dataGridView1.DataSource = query.ToList();


            //var query2 = from c in nwDataSet1.Categories
            //             join p in nwDataSet1.Products
            //             on c.CategoryID equals p.CategoryID
            //             //select new { c.CategoryID, c.CategoryName, p.ProductID, p.ProductName, p.UnitPrice }
            //             group p by c.CategoryName into g
            //             select new { CategoryName = g.Key, AvgUnitPrice = g.Average(p => p.UnitPrice) }

            //              ;

            //this.dataGridView2.DataSource = query2.ToList();
            #endregion


            #region exercise
            //query
            var query = nwDataSet1.Products
                                    .GroupBy(p => p.CategoryID)
                                    .Select(g => new
                                    {
                                        id = g.Key,
                                        myAvg = g.Average(p => p.UnitPrice)
                                    })
                                    .Select(g => new
                                    {
                                        g.id,
                                        myAvg = $"{g.myAvg:C}"
                                    }); 

            dataGridView1.DataSource = query.ToList();


            //query 2 join

            var query2 = nwDataSet1.Categories
                .Join(
                        nwDataSet1.Products,
                        c => c.CategoryID,
                        p => p.CategoryID,
                        (c, p) => new { c.CategoryName, p.UnitPrice }
                )
                .GroupBy(j => j.CategoryName)
                .Select(g => new 
                {
                    CategoryName = g.Key,
                    myAvg = g.Average(p =>p.UnitPrice) 
                })
                .Select(g => new 
                {
                    g.CategoryName,
                    myAvg = $"{g.myAvg:C}"
                })
                ;

            dataGridView2.DataSource = query2.ToList();
            #endregion

        }

        //nw oder year count group
        private void button12_Click(object sender, EventArgs e)
        {
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);

            var query = nwDataSet1.Orders
                                    .GroupBy(y => y.OrderDate.Year) //Key
                                    .Select(yearGroup => new { year = yearGroup.Key, count = yearGroup.Count() });
            dataGridView1.DataSource = query.ToList();
        }

       

        //--------------------------  Linq to DataSet------------------------------------------------------------------------------------------------------------------------------















    }
}
