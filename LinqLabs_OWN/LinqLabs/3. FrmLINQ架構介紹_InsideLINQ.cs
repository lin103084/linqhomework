using LinqLabs;
using LinqLabs.NWDataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLINQ架構介紹_InsideLINQ : Form
    {
        public FrmLINQ架構介紹_InsideLINQ()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
        }

        // ----------------------------------- Linq to 集合 / Array -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void butArrayList_Click(object sender, EventArgs e)
        {
            ArrayList arr = new ArrayList();
            arr.Add(4);
            arr.Add(45);
            arr.Add(222);

            //string s = "sdf";

            var query = from a in arr.Cast<int>()
                        where a > 5
                        select new { A = a };
            //a.ToString();


            dataGridView1.DataSource = query.ToList();
        }

        private void butAggregation_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            listBox1.Items.Add($"Max : {nums.Max()}");
            listBox1.Items.Add($"Min : {nums.Min()}");
            listBox1.Items.Add($"Sum : {nums.Sum()}");
            listBox1.Items.Add($"Avg :  {nums.Average()}");

            //======================= nwdataset =======================

            decimal maxQuery = nwDataSet1.Products.Max(p => p.UnitPrice);
            listBox1.Items.Add($"最高價 : {maxQuery}");
            listBox1.Items.Add($"最低價 : {nwDataSet1.Products.Max(p => p.UnitPrice)}");
            listBox1.Items.Add($"平均價 : {nwDataSet1.Products.Max(p => p.UnitPrice)}");            
        }
        private void butDelayExecute_Click(object sender, EventArgs e)
        {

            //define source
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //define query
            int i = 0;
            IEnumerable<int> query = from n in nums
                                                               select i++;
            //Execute
            foreach (var q in query) 
            {
                listBox1.Items.Add($"count i : {i}, query q : {q}");
            }
            listBox1.Items.Add("===========================================");



            //=======================================================

            i = 0;
            var q1 = (from n in nums
                      select ++i).ToList();

            foreach (var v in q1)
            {
                listBox1.Items.Add(string.Format("v = {0}, i = {1}", v, i));
            }


        }
        private void button7_Click(object sender, EventArgs e)
        {
            //define query
            var query = (from p in nwDataSet1.Products
                         orderby p.UnitPrice descending
                         select p).Take(5);

            //do execute
            dataGridView1.DataSource = query.ToList();

            //===================================

            //define query
            #region 可讀性較高
            var query2 = from p in nwDataSet1.Products
                                     orderby p.UnitPrice descending
                                     select p;

            dataGridView2.DataSource = query.Take(5).ToList();
            #endregion
        }


    }
}