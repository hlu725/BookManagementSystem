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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadCategoryData();         //カテゴリ情報の読込み
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
                
                comboBoxCategory.Items.Add(dlc.CategoryName());            
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Console.WriteLine("search button click");
            TypeBookNo bno = new TypeBookNo(int.Parse(textBoxBookNo.Text));
            TypeBookName bname = new TypeBookName(textBoxBookName.Text);
            //TypeRentalState rental = new TypeRentalState(TypeRentalState.RentalState.NoRental);

            //パラメータ設定
            ParamList param = new ParamBooksSearch();
            param.SetParam(bno);
            param.SetParam(bname);
            //param.SetParam(rental);

            //検索実行
            ServiceInterface srv = new ServiceBooksSearch(param);
            srv.Run();

            //検索結果の取り出し
            TypeBookAggregate books = (TypeBookAggregate)param.GetParam(DataType.BookAggregate);
            AggregateBase agb = books.BookAggregate();
            IteratorBase ite = agb.Iterator();
            if (ite.HasNext())
            {
                DataListBookInfo info = (DataListBookInfo)ite.Next();
              //  Console.WriteLine(info.BookName());
            }
        }

        private void buttonRental_Click(object sender, EventArgs e)
        {

            Form frm = new Rental();
            frm.ShowDialog();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            Form frm = new Return();
            frm.ShowDialog();
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            //ParamAuthManager pam = new ParamAuthManager();
            //ServiceAuthManager sam = new ServiceAuthManager(pam);
            //sam.Run();
            //TypePassword tp = (TypePassword)pam.GetParam(DataType.Password);
            //if (tp.Password().Equals(textBox2.Text))
            //{
            //    MessageBox.Show("認証成功！");
            //    
            //}    
            buttonUserRegist.Enabled = true;
            buttonRegist.Enabled = true;
            buttonBookUpdate.Enabled = true;
        }

        private void buttonUserRegist_Click(object sender, EventArgs e)
        {
            Form frm = new UserRegist();
            frm.ShowDialog();
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            Form frm = new BookRegist();
            frm.ShowDialog();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Form frm = new BookRegist();
            frm.ShowDialog();
        }

        private void comboBoxRentalState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
