using LinqLabs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLangForLINQ : Form
    {
        public FrmLangForLINQ()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        //----------------------------------------------------- Generic 泛型 ---------------------------------------------------------------------------------------------------------------------------------------------------------------
        //swap 固定型別 (無法多變化)
        private void swap(ref int n1, ref int n2)
        {
            int temp = n1;
            n1 = n2;
            n2 = temp;
        }

        // 使用 swap 固定型別  - 傳 "址" 方式
        private void butSwap_Click(object sender, EventArgs e)
        {
            //    public static System.Collections.Generic.IEnumerable<TSource> Where<TSource>(this System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate)
            //    System.Linq.Enumerable 的成員
            int x = 100;
            int y = 200;
            MessageBox.Show($"傳址前 : {x}, {y}");
            swap(ref x, ref y);
            MessageBox.Show($"傳址後 : {x}, {y}");
        }


        //swapAnytype  泛型 接受多變化
        private void swapAnyType<T>(ref T n1, ref T n2)
        {
            T temp = n1;
            n1 = n2;
            n2 = temp;
        }

        // 使用 swapAnyType 泛型  傳 "址" 方式
        private void butSwapAnyType_Click(object sender, EventArgs e)
        {
            // int
            MessageBox.Show("測試SwapAnyType<int>");
            int x = 100;
            int y = 200;
            MessageBox.Show($"傳址前 {x}, {y}");
            swapAnyType(ref x, ref y);
            MessageBox.Show($"傳址後 {x}, {y}");

            // sting
            MessageBox.Show("測試SwapAnyType<string>");
            string s1 = "s1";
            string s2 = "s2";
            MessageBox.Show($"傳址前 {s1}, {s2}");
            swapAnyType(ref s1, ref s2);
            MessageBox.Show($"傳址後 {s1}, {s2}");

        }

        private void ButtonXPrint1(object sender, EventArgs e)
        {
            MessageBox.Show("這是使用 Delegate 註冊的具名 Method 1");
        }
        private void ButtonXPrint2(object sender, EventArgs e)
        {
            MessageBox.Show("這是使用 Delegate 註冊的具名 Method 2");
        }


        //----------------------------------------------------- Delegate (委派) --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //利用該按鈕 註冊ButtonX的click事件
        private void butDelegateByButtonX_Click(object sender, EventArgs e)
        {
            #region
            ////具名方法
            //this.buttonX.Click += ButtonXPrint1;
            //this.buttonX.Click += ButtonXPrint2;

            ////匿名方法
            //this.buttonX.Click += delegate (object sender1, EventArgs e1)
            //                                        {
            //                                            MessageBox.Show("delegate匿名方法");
            //                                        };

            ////匿名Lambda方法
            //this.buttonX.Click += (sender2, e2) =>
            //                                        {
            //                                            MessageBox.Show("delegate匿名Lambda方法!");
            //                                        };

            #endregion
            //事件註冊 - 具名方法
            this.buttonX.Click += ButtonXPrint1;
            this.buttonX.Click += ButtonXPrint2;

            //事件註冊 - 匿名方法
            this.buttonX.Click += delegate (object sender2, EventArgs eventArgs2)
            {
                MessageBox.Show("OK吧? 這就是C#2.0 的 匿名Method!");
            };

            //事件註冊 - 匿名方法
            this.buttonX.Click += (sender3, e3) => 
            {
                MessageBox.Show("OK吧? 這就是C#3.0 的 Lambda Method!");
            };

        }





        //======================== 自建 delegate 實作 event ========================

        private bool greaterThan(int n)
        {
            return n > 5;
        }
        private bool isEven(int n)
        {
            return n % 2 == 0;
        }

        // step1 Create delegate class
        // step2 Create delegate Object - method
        // step3 Invoke Method
        public delegate bool Mydelegate(int n);


        private void butTestDelegate_Click(object sender, EventArgs e)
        {
            #region 上課
            // TEST
            //bool result = Test(5);
            //MessageBox.Show($"result : {result}");

            // C# 1.0 具名
            //Mydelegate mydelegate = new Mydelegate(Test);
            //bool mydelegateTestResult = mydelegate.Invoke(10);
            //MessageBox.Show($"C# 1.0 mydelegateTestResult : {mydelegateTestResult}");

            //mydelegate = isEven;
            //bool mydelegateisEvenResul = mydelegate.Invoke(1);
            //MessageBox.Show($"C# 1.0 mydelegateisEvenResult : {mydelegateisEvenResul}");

            //// C# 2.0 匿名方法
            //mydelegate = delegate (int n)
            //                            {
            //                                return n > 5;
            //                            };

            //bool delegateResult = mydelegate.Invoke(19);
            //MessageBox.Show($"C#2.0 delegate匿名 : {delegateResult}");

            //// C# 3.0 Lambda方法
            //mydelegate = n =>
            //                            {
            //                                return n > 5;
            //                            };

            //bool resultLambda = mydelegate.Invoke(19);
            //MessageBox.Show($"C#3.0 Lambda匿名 : {resultLambda}");

            #endregion

            #region 再練習
            //C# 1.0 delegate 具名方式
            Mydelegate mydelegate = new Mydelegate(greaterThan);
            bool result = mydelegate(10);
            MessageBox.Show($"建立 Delegate event - 具名result : {result}");

            //C# 2.0 delegate 匿名方式
            mydelegate = delegate (int n)
            {
                return n > 5;
            };

            bool result2  = mydelegate.Invoke(10); //invoke = call method
            MessageBox.Show($"建立 Delegate event - 匿名result : {result2}");


            //C# 2.0 delegate Lambda 方式
            mydelegate = (n) => { return n > 5; };
            bool result3 = mydelegate.Invoke(10);
            MessageBox.Show($"建立 Delegate event - Lambda result : {result3}");
            #endregion
        }


        //把delegate當參數傳遞 (只要是它能接受的簽名方式)
        List<int> Mywhere(int[] nums, Mydelegate mydelegate)
        {
            List<int> list = new List<int>();

            foreach (int n in nums)
            {
                if (mydelegate.Invoke(n))
                {
                    list.Add(n);
                }
            }

            return list;
        }



        private void butListMyWhereMydelegate_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> listTest = Mywhere(nums, greaterThan);
            List<int> listIsEven = Mywhere(nums, isEven);

            listBox1.Items.Clear();
            listBox1.Items.Add("listTest");
            foreach (int n in listTest) { this.listBox1.Items.Add(n); }
            listBox1.Items.Add("listIsEven");
            foreach (int n in listIsEven) { this.listBox1.Items.Add(n); }


            //================= 匿名 =================
            List<int> listLambda1 = Mywhere(nums, n => n % 2 == 0);


            this.listBox2.Items.Clear();
            this.listBox2.Items.Add("listLambda1");
            foreach (int n in listLambda1) { this.listBox2.Items.Add(n); }


            this.listBox2.Items.Add("listLambda2");
            List<int> listLambda2 = Mywhere(nums, n => n % 2 == 1);
            foreach (int n in listLambda2) { this.listBox2.Items.Add(n); }
        }

        //----------------------------------------------------- Iterator ---------------------------------------------------------------------------------------------------------------------------------------------------------------
        IEnumerable<int> MyIterator(int[] source, Mydelegate mydelegate)
        {
            foreach (int n in source)
            {
                yield return n;
            }
        }



        private void butYield_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> q = MyIterator(nums, n => n % 2 == 0);
            this.listBox1.Items.Clear();

            foreach (int n in q)
            {
                this.listBox1.Items.Add(n);
            }

        }

        private void butFromLinqDoCsharp_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<int> list = nums.Where<int>(n => n % 2 == 0);
            this.listBox1.Items.Clear();
            foreach (int n in list)
            {
                this.listBox1.Items.Add((int)n);
            }

            string[] words = { "aaa", "bbbbbb", "cccccccc" };

            IEnumerable<string> wordlist = words.Where<string>(n => n.Length > 4);
            this.listBox2.Items.Clear();
            foreach (string w in wordlist)
            {
                this.listBox2.Items.Add(w);
            }

            // =================== nwdataset  ===================
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.dataGridView1.DataSource = this.nwDataSet1.Products.Where<NWDataSet.ProductsRow>(p => p.UnitPrice > 30).ToList();




        }

        //----------------------------------------------------- C# 3.0 ---------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void butVar_Click(object sender, EventArgs e)
        {
            //var n = 10;
            //var n2 = "123";

            Point  point   = new Point(1, 2);
            MessageBox.Show($"point : {point.X}, {point.Y}");

            var pointVar = new Point(1, 2);
            MessageBox.Show($"pointVar : {pointVar.X}, {pointVar.Y}");

        }

        private void butObjectInitializer_Click(object sender, EventArgs e)
        {
            Point p = new Point(2, 3);

            Font font = new Font("arial", 3, FontStyle.Bold);
            //=================================
            //C# 3.0

            Point p2 = new Point { X = 1 };
            Point p3 = new Point { X = 5, Y = 9 };


            List<Point> list = new List<Point>() { p2, p3 };
            list.Add(new Point { Y = 123 });

            this.dataGridView1.DataSource = list;
        }

        private void butAnonymouseType_Click(object sender, EventArgs e)
        {
            var p = new { X = 1, Y = 2, Z = 3 };
            //MessageBox.Show($"{p.X} {p.Y} {p.Z}");

            listBox1.Items.Add(p.GetType());

            //============================

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //LINQ 運算式
            //var query = from n in nums
            //                        where n > 5
            //                        select new { N = n, square = n * n, Cube = n * n * n };
            //dataGridView1.DataSource = query.ToList();

            //LINQ Method
            var query2 = nums.Where(n => n > 5)
                                                .Select(n => new { N = n, Cube = n * n, square = n * n });

            dataGridView1.DataSource = query2.ToList();



            //=============================
            //運算式
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            //var query3 = from p2 in nwDataSet1.Products
            //             where p2.UnitPrice > 30
            //             select new 
            //             { 
            //ID = p2.ProductID, 
            //                 Name = p2.ProductName, 
            //                 p2.UnitPrice, 
            //                 p2.UnitsInStock, 
            //                 total = p2.UnitsInStock * p2.UnitPrice
            //             };

            //dataGridView2.DataSource = query3.ToList();


            //Method
            var query3 = nwDataSet1.Products
                                .Where(p3 => p3.UnitPrice > 30)
                                .Select(p3 => new
                                {
                                    ID = p3.ProductID,
                                    Name = p3.ProductName,
                                    p3.UnitPrice,
                                    p3.UnitsInStock,
                                    total = $"{p3.UnitsInStock * p3.UnitPrice:C}"
                                });

            dataGridView2.DataSource = query3.ToList();
        }

        //擴充方法
        private void butExpansionMethod_Click(object sender, EventArgs e)
        {
            // 直接使用靜態方法
            string strs = "abcdefg";
            int count = strs.wordscount();
            MessageBox.Show($"Count : {count}");


            //透過靜態類別 引用靜態方法
            string strs2 = "asdfasvxzcvadsfbdafbgdafg";
            int count2 = Mywords.wordscount(strs2);
            MessageBox.Show($"Count2 : {count2}");



            //================char ================

            Char s =  strs.Char(5);
            MessageBox.Show($"Char s : {s} Index : {5} ");
        }

        private void button38_Click(object sender, EventArgs e)
        {

        }
    }
}


//擴充方法
public static class Mywords 
{
    public static int wordscount(this string str) 
    {
        return str.Length;
    }

    public static char Char(this string str, int index) 
    { 
        return str[index];
    }
}