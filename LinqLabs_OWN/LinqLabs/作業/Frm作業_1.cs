using LinqLabs;
using LinqLabs.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        //string ConnectionString = Settings.Default.NorthwindConnectionString;
        DataTable dt = new DataTable();
        BindingSource bindingSource = new BindingSource();
        
        public Frm作業_1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);

            this.dataGridViewOrder.ReadOnly = true;
            this.dataGridViewOrderDetail.ReadOnly = true;
        }
        //------------------------------- Method -----------------------------------------------------------------------------------------------------------------------------------------------------------
        private string FileSizeFilter(long size, int[] sortedSizes)
        {
            int count = sortedSizes.Length;
            int small = sortedSizes[(int)(count * 0.3)];
            int large = sortedSizes[(int)(count * 0.8)];

            if (size <= small)
                return "small";
            else if (size > small && size < large)
                return "medium";
            else
                return "large";
        }


        //------------------------------- Method -----------------------------------------------------------------------------------------------------------------------------------------------------------



        // 找log檔案
        private void butFileInfoByLog_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();


            // Define LINQ Query
            IEnumerable<System.IO.FileInfo> query = from f in files
                                                    where f.Name.EndsWith(".log")
                                                    //where f.Extension == ".log"
                                                    select f;

            this.dataGridViewOrder.DataSource = query.ToList();
        }
        //大檔案
        private void butFileInfoByBigData_Click(object sender, EventArgs e)
        {
            //Define Source
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();



            //LINQ Query
            //IEnumerable<System.IO.FileInfo> query = from f in files
            //                                        where f.Length > 500000
            //                                        select f;

            //Linq method

            //取得所有檔案大小
            var fileSizes = files
                                        .Select(f => (int)f.Length)
                                        .OrderBy(s => s)
                                        .ToArray();

            //add to datafridview
            var datagridviewQuery = files
                                                            .GroupBy(f => FileSizeFilter(f.Length, fileSizes))
                                                            .Where(g => g.Key == "large")
                                                            .SelectMany(g => g)
                                                            .Select(f => new
                                                            {
                                                                f.Name,
                                                                Size = $"{f.Length:N0} bytes",
                                                                Created = f.CreationTime,
                                                                f.FullName
                                                            })

                                                            ;


            dataGridViewOrder.DataSource = datagridviewQuery.ToList();
            // add to treeview
            var treeviewQuery = files
            .OrderBy(s => s.Length)
            .GroupBy(f => FileSizeFilter(f.Length, fileSizes))            
            .Select(g => new
            {
                SizeCategory = g.Key,
                Count = g.Count(),
                Files = g
            });


            
            treeView1.Nodes.Clear();
            foreach (var group in treeviewQuery)
            {
                string header = $"{group.SizeCategory} [{group.Count}]";
                TreeNode node = treeView1.Nodes.Add(header);

                foreach (var file in group.Files)
                {
                    node.Nodes.Add($"{file.Name} ({file.Length} bytes)");
                }
            }
        }
            //建立時間
            private void butFileInfoByCreate_Click(object sender, EventArgs e)
        {
            //Define Source
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            //LINK Query
            IEnumerable<System.IO.FileInfo> query = from f in files
                                                    where f.CreationTime.Year >= 2022
                                                    select f;

            this.dataGridViewOrder.DataSource = query.ToList();
        }



        //------------------------------- 右半邊 -----------------------------------------------------------------------------------------------------------------------------------------------------------
        //上/下 頁面使用
        int skip = 0;
        

        //讀取LoadYear       
        private void LoadYearIntoComboBox() 
        {
            comboBoxYears.Items.Clear();
            
            var query = nwDataSet1.Orders                                   
                                   //.Select(row => row.Field<DateTime?>("OrderDate")?.Year)
                                   .Select(o => o.OrderDate.Year)
                                   .Distinct()
                                   .OrderBy(y => y);
                                                                    
            foreach (int item in query) 
            {
                comboBoxYears.Items.Add(item);
            }
            

        }
        private void butPreviousPage_Click(object sender, EventArgs e)
        {
            int dataCount = nwDataSet1.Orders.Count;
            // 每頁顯示筆數
            int pageSize = Convert.ToInt32(textBox1.Text);

            if (skip >= pageSize)
                skip -= pageSize;
            else
                skip = 0;

            var query = nwDataSet1.Orders
                                .Skip(skip)
                                .Take(pageSize);


            dataGridViewOrder.DataSource = query.ToList();

            
            textBox2.Text = $"{skip} / {dataCount}";
            



        }


        

        private void butNextPage_Click(object sender, EventArgs e)
        {
            int dataCount = nwDataSet1.Orders.Count;
            // 每頁顯示筆數
            int pageSize = Convert.ToInt32(textBox1.Text);


           


            var query = nwDataSet1.Orders
                                .Skip(skip)
                                .Take(pageSize);                      
            dataGridViewOrder.DataSource = query.ToList();
            //MessageBox.Show(skip.ToString());

            if (skip + pageSize >= dataCount)
            {
                skip = dataCount;
                //MessageBox.Show("準備return");
                return;
            }
            skip += pageSize;
            textBox2.Text = $"{skip} / {dataCount}";
        }
        
        private void butSearchYearOrder_Click(object sender, EventArgs e)
        {
            
        }
       
        // All order
        private void butAllOrder_Click(object sender, EventArgs e)
        {

            IEnumerable<NWDataSet.OrdersRow> query = nwDataSet1.Orders;                                   
            bindingSource.DataSource = query.ToList();
            dataGridViewOrder.DataSource = bindingSource;
            
            LoadYearIntoComboBox();
        }
        //Combobox 選取Year
        private void comboBoxYears_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selectYear = Convert.ToInt32(comboBoxYears.Text);          
            var query = nwDataSet1.Orders
                                .Where(o => o.Field<DateTime?>("OrderDate")?.Year == selectYear);
            
            dataGridViewOrder.DataSource = query.ToList() ;
        }

        private void dataGridViewOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

            // ⛔ 點到標題列就不處理
            if (e.RowIndex < 0)
                return;

            if (dataGridViewOrder.Columns.Contains("OrderID")) 
            {
            int id = Convert.ToInt32(dataGridViewOrder.Rows[e.RowIndex].Cells["OrderID"].Value);
            var query = nwDataSet1.Orders
                                .Where(o => o.OrderID == id);
                                
                                
            dataGridViewOrderDetail.DataSource = query.ToList() ;
            }
        }
    }
}
