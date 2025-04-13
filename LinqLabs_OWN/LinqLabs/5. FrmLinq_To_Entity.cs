using LinqLabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLinq_To_Entity : Form
    {

        LinqLabs.NorthwindEntities dbContext = new LinqLabs.NorthwindEntities();


        public FrmLinq_To_Entity()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dbContext.Database.Log = Console.WriteLine;

        }
        
        

        private void butTestEntityModel_Click(object sender, EventArgs e)
        {
            #region  query
            //query

           
            var query = from p in dbContext.Products
                                where p.UnitPrice > 30
                                select p;

            dataGridView1.DataSource = query.ToList();
            #endregion

            //linq method
            
            var query2 = dbContext.Products
                                    .Where(p => p.UnitPrice > 30);

            dataGridView1.DataSource = query2.ToList();

        }

        //導覽屬性
        private void butNavigationProperties_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.dbContext.Categories.First().Products.ToList();
            MessageBox.Show(this.dbContext.Products.First().Category.CategoryName);

            
        }

        //預存程序
        private void butStoredProcedures_Click(object sender, EventArgs e)
        {
            var query = this.dbContext.Sales_by_Year(new DateTime(1997, 1, 1), DateTime.Now);
            dataGridView1.DataSource = query.ToList();
        }

        private void butOrderbyThenBy_Click(object sender, EventArgs e)
        {
            #region query 
            var query = from p in dbContext.Products
                        orderby p.UnitPrice descending, p.ProductID descending
                        select p;

            dataGridView1.DataSource = query.ToList();
            #endregion

            #region linq method
            var query2 = dbContext.Products
                                .OrderByDescending(p => p.UnitPrice)
                                .ThenByDescending(p => p.ProductID);
            dataGridView2.DataSource = query2.ToList();                                
            #endregion
        }

        private void butNoteAsEnumerable_Click(object sender, EventArgs e)
        {
            #region query
            var query = from p in this.dbContext.Products.AsEnumerable()
                        select new { p.ProductID, p.ProductName, p.UnitPrice, p.UnitsInStock, TotalPrice = $"{ p.UnitPrice* p.UnitsInStock:c}"                        };

            dataGridView1.DataSource = query.ToList();
            #endregion


        }

        private void butNoteTodoOrdersGroupBy_Click(object sender, EventArgs e)
        {
            #region query 
            var query = from o in dbContext.Orders
                        group o by o.OrderDate.Value.Year into g
                        select new { Year = g.Key, Count = g.Count()};

            dataGridView1.DataSource = query.ToList();

            #endregion
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }


        // ------------------------------------- JOIN -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //尚未使用 Entity 去join ，沒使用 - 導覽屬性
        private void but_join_inner_join_join_into_left_outer_join_Click(object sender, EventArgs e)
        {
            var query = from c in this.dbContext.Categories
                                    join p in this.dbContext.Products
                                    on c.CategoryID equals p.CategoryID
                                    select new { c.CategoryID, c.CategoryName, p.ProductName, p.UnitPrice };

            dataGridView1.DataSource = query.ToList();

       


        }

        //使用Entity 的導覽屬性自動 join 
        private void butNavEntity_Click(object sender, EventArgs e)
        {
            var query = from p in this.dbContext.Products
                        select new { p.CategoryID, p.Category.CategoryName, p.ProductName, p.UnitPrice };
            dataGridView2.DataSource = query.ToList();
        }


        //使用select many 底層也是 join 方式
        private void butSelectMany_Click(object sender, EventArgs e)
        {
            // inner join
            var query = from c in this.dbContext.Categories
                        from p in c.Products
                        select new { c.CategoryID, c.CategoryName, p.ProductID, p.ProductName, p.UnitPrice };

            dataGridView1.DataSource = query.ToList();

            MessageBox.Show($"query Count {query.Count()}");

            // Cross join
            var query2 = from c in this.dbContext.Categories
                        from p in this.dbContext.Products
                        select new { c.CategoryID, c.CategoryName, p.ProductID, p.ProductName, p.UnitPrice };

            dataGridView2.DataSource = query2.ToList();

            MessageBox.Show($"query Count {query2.Count()}");
        }


        //------------------------- join gropu by ---------------------------------------------------------------------------------------------------------------------------------------
        private void button11_Click(object sender, EventArgs e)
        {

            var query = from p in this.dbContext.Products
                        group p by p.Category.CategoryName into g //key 
                        select new { CategoryName = g.Key, Average = g.Average(p => p.UnitPrice) };

            dataGridView1.DataSource = query.ToList();


            // linq method
            var query2 = this.dbContext.Products
                           .GroupBy(p => p.Category.CategoryName)
                           .Select(g => new 
                           { 
                               CategoryName = g.Key,                                //導覽屬性
                               Average = g.Average(p => p.UnitPrice)    //分群統計
                           });

            dataGridView2.DataSource = query2.ToList();

        }
        //-------------------------- CRUD ----------------------------------------------------

        private byte[] ImageToByres(Image image) 
        {
            using (MemoryStream ms = new MemoryStream()) 
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void butCreateInsert_Click(object sender, EventArgs e)
        {
            byte[] data = ImageToByres(pictureBox1.Image);
            Category category = new Category { CategoryName = DateTime.Now.ToLongTimeString(), Picture = data};

            //Product product = new Product { ProductName = DateTime.Now.ToLongTimeString(), Discontinued = true };
            Product product = new Product { ProductName = "test" };//, Discontinued = true };

            this.dbContext.Categories.Add(category);
            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();
            refashDatagridviewByProducts();
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            var productsQuery = this.dbContext.Products
                .Where(p => p.ProductName.Contains("test")).FirstOrDefault();

            if(productsQuery == null) { return; }

            productsQuery.ProductName += "test";
            dbContext.SaveChanges();

            refashDatagridviewByProducts();
        }

        private void refashDatagridviewByProducts()
        {
            dataGridView1.DataSource = this.dbContext.Products.ToList();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            var productsQuery = this.dbContext.Products
                .Where(p => p.ProductName.Contains("test")).FirstOrDefault();

            if (productsQuery == null) { return; }

            dbContext.Products.Remove(productsQuery);
            dbContext.SaveChanges();

            refashDatagridviewByProducts();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string str = "";
            str += $" ID : {this.dbContext.Order_Details.First().Order.Employee.EmployeeID.ToString()}\n";
            str += $"Name: {this.dbContext.Order_Details.First().Order.Employee.FirstName}";
            str += $" {this.dbContext.Order_Details.First().Order.Employee.LastName}";

            MessageBox.Show(str);
        }
    }
}
