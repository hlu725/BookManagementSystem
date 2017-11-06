using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BooksLib;

namespace books_sample
{
    public partial class BookRegist : Form
    {
        public BookRegist()
        {
            InitializeComponent();
            // セット必要なパラメータ
             LoadCategoryData();
          
        }
        private void LoadCategoryData()
        {
            //カテゴリテーブルから全カテゴリの情報を取得し、
            //comboBoxのアイテムに設定する
            ParamCategorySearch pcs = new ParamCategorySearch();

            ServiceSearchCategory ssc = new ServiceSearchCategory(pcs);
            ssc.Run();
            TypeCategoryAggregate dta = (TypeCategoryAggregate)pcs.GetParam(DataType.CategoryAggregate);
            AggregateCategory ac = (AggregateCategory)dta.CategoryAggregate();
            for (int i = 0; i < ac.Size(); i++)
            {
                DataListCategory dlc = (DataListCategory)ac.GetData(i);
                comboBox1.Items.Add(dlc.CategoryName());
            }
        }
        //20130709から追加
        //private Boolean checkString(String s)
        //{
        //    if (s.Substring(0, 1).Equals(""))
        //        return false;
        //    else
        //        return true;
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            //check...
            //if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            //{
            //    MessageBox.Show("");
            //}

            //20130705から追加    
            //パラメーター設定
            TypeBookName tbn = new TypeBookName(textBox1.Text);         //書籍名
            TypeAuthor ta = new TypeAuthor(textBox2.Text);              //著者
            TypePress tp = new TypePress(textBox3.Text);                //出版社
            TypeCategoryName tcn = new TypeCategoryName(comboBox1.Text);//カテゴリ名
            TypeRegistDate trd = new TypeRegistDate(textBox4.Text);     //登録日

            ParamRegistBook prb = new ParamRegistBook();
            prb.SetParam(tbn);
            prb.SetParam(ta);
            prb.SetParam(tp);
            prb.SetParam(tcn);
            prb.SetParam(trd);

            try
            {
                ServiceRegistBook srb = new ServiceRegistBook(prb);
                srb.Run();
                Close();
            }
            catch
            {
                MessageBox.Show("Error!");
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
