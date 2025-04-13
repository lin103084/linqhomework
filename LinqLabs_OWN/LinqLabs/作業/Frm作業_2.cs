using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productPhotoTableAdapter1.Fill(this.awDataSet1.ProductPhoto);
            
            loadYears();
            loadSeason();
            loadStartDate();
            loadEndDate();
        }

        private void loadYears() 
        {
            comboBoxYears.Items.Clear();
            var query = awDataSet1.ProductPhoto                                   
                                   .Select(p => p.ModifiedDate.Year)
                                   .OrderBy(y => y)
                                   .Distinct();

            comboBoxYears.Items.Add("All");
            foreach (var item in query)
            {
                comboBoxYears.Items.Add(item);
            }

            if (comboBoxYears.Items.Count > 0) { comboBoxYears.SelectedIndex = 0; }

        }

        private void loadSeason()
        {
            comboBoxSeason.Items.Clear();

            comboBoxSeason.Items.Add("All");
            comboBoxSeason.Items.Add("第一季");
            comboBoxSeason.Items.Add("第二季");
            comboBoxSeason.Items.Add("第三季");
            comboBoxSeason.Items.Add("第四季");

            comboBoxSeason.SelectedIndex = 0;

        }


        private void loadStartDate() 
        {
            var query = awDataSet1.ProductPhoto
                                    .Min(p => p.ModifiedDate);

            dateTimePickerStart.Text = query.ToString();
            
        }
        private void loadEndDate()
        {
            var query = awDataSet1.ProductPhoto
                                    .Max(p => p.ModifiedDate);

            dateTimePickerEnd.Text = query.ToString();

        }




        private void ApplyFilter()
        {
            var query = awDataSet1.ProductPhoto.AsEnumerable();

            // 年份過濾
            if (comboBoxYears.Text != "All")
            {
                int year = Convert.ToInt32(comboBoxYears.Text);
                query = query.Where(p => p.ModifiedDate.Year == year);
            }

            // 季節過濾
            var seasonMap = new Dictionary<string, List<int>>
            {
                { "第一季", new List<int> { 1, 2, 3 } },
                { "第二季", new List<int> { 4, 5, 6 } },
                { "第三季", new List<int> { 7, 8, 9 } },
                { "第四季", new List<int> { 10, 11, 12 } }
            };

            if (comboBoxSeason.Text != "All" &&                
                seasonMap.TryGetValue(comboBoxSeason.Text, out var months))
            {
                query = query.Where(p => months.Contains(p.ModifiedDate.Month));
            }

            //區間過濾
            query = query.Where(p => 
            p.ModifiedDate >= Convert.ToDateTime(dateTimePickerStart.Value)
            &
            p.ModifiedDate <= Convert.ToDateTime(dateTimePickerEnd.Value)
            );




            dataGridView1.DataSource = query.ToList();
        }







        private void butReset_Click(object sender, EventArgs e)
        {
            loadYears();
            loadSeason();
            loadStartDate();
            loadEndDate();
        }

        private void butSerch_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) 
            {
                return;
            }
            //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells["ProductPhotoID"].Value.ToString());

            int photoID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProductPhotoID"].Value);

            //var row = awDataSet1.ProductPhoto.Where(p => p.ProductPhotoID == photoID).ToList();
            var targetRow = awDataSet1.ProductPhoto.FirstOrDefault(p => p.ProductPhotoID == photoID);


            if (targetRow != null)
            {
                byte[] photoByte = targetRow.ThumbNailPhoto;

                if (photoByte != null && photoByte.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(photoByte))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }
    }
}
