﻿namespace Starter
{
    partial class FrmHelloLinq
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button49 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.nwDataSet1 = new LinqLabs.NWDataSet();
            this.productsTableAdapter1 = new LinqLabs.NWDataSetTableAdapters.ProductsTableAdapter();
            this.ordersTableAdapter1 = new LinqLabs.NWDataSetTableAdapters.OrdersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nwDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(169, 237);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(362, 59);
            this.button2.TabIndex = 25;
            this.button2.Text = "a taste of Linq - int[]";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.butTasteOfLinqArray_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(168, 438);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(362, 59);
            this.button1.TabIndex = 24;
            this.button1.Text = "a taste of Linq - string[]";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.butTasteOfLinqArrayString_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(165, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 100);
            this.label1.TabIndex = 23;
            this.label1.Text = "What is Linq \r\n\r\n統一資料存取 - 徹底融入語言";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(709, 237);
            this.listBox1.Margin = new System.Windows.Forms.Padding(5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(456, 116);
            this.listBox1.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(170, 642);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 59;
            this.label9.Text = "Demo :";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Blue;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(173, 663);
            this.button3.Margin = new System.Windows.Forms.Padding(5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(313, 56);
            this.button3.TabIndex = 60;
            this.button3.Text = "Advanced";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button49
            // 
            this.button49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button49.Location = new System.Drawing.Point(171, 44);
            this.button49.Margin = new System.Windows.Forms.Padding(5);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(159, 42);
            this.button49.TabIndex = 61;
            this.button49.Text = "參考 / 匯入";
            this.button49.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(709, 37);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(194, 57);
            this.button4.TabIndex = 62;
            this.button4.Text = "IEnumerable<T> List<T>";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.butListEnumerator_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(709, 107);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(194, 57);
            this.button5.TabIndex = 62;
            this.button5.Text = "IEnumerable<T>int[]";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.butArrayEnumerator_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(168, 306);
            this.button6.Margin = new System.Windows.Forms.Padding(5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(362, 59);
            this.button6.TabIndex = 25;
            this.button6.Text = "a taste of Linq - int[] bool isEven(n)";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.butTasteOfLinqArrayIsEven_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Control;
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(168, 369);
            this.button7.Margin = new System.Windows.Forms.Padding(5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(362, 59);
            this.button7.TabIndex = 25;
            this.button7.Text = "a taste of Linq - int[] bool isEven(n) any type";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.butTasteOfLinqAnyType_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(709, 381);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(456, 116);
            this.dataGridView1.TabIndex = 63;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(709, 522);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(456, 209);
            this.chart1.TabIndex = 64;
            this.chart1.Text = "chart1";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(168, 506);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(360, 59);
            this.button8.TabIndex = 65;
            this.button8.Text = "NwDataSetProducts";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.butNwDataSetProducts_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(169, 571);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(360, 59);
            this.button9.TabIndex = 65;
            this.button9.Text = "NwDataSetOrders";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.butNwDataSetOrders_Click);
            // 
            // nwDataSet1
            // 
            this.nwDataSet1.DataSetName = "NWDataSet";
            this.nwDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productsTableAdapter1
            // 
            this.productsTableAdapter1.ClearBeforeFill = true;
            // 
            // ordersTableAdapter1
            // 
            this.ordersTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmHelloLinq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 743);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button49);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmHelloLinq";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nwDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button49;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private LinqLabs.NWDataSet nwDataSet1;
        private LinqLabs.NWDataSetTableAdapters.ProductsTableAdapter productsTableAdapter1;
        private LinqLabs.NWDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter1;
    }
}

