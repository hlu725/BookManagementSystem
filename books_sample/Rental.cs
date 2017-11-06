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
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();

            LoadUserData();         //利用者の一覧を読み込む
        }

        private void LoadUserData()
        {
            //利用者テーブルから全利用者の情報を取得し、
            //comboBoxのアイテムに設定する
            //20130709から追加,完成
            ParamUserSearch pus = new ParamUserSearch();
            ServiceSearchUser ssu = new ServiceSearchUser(pus);
            ssu.Run();
            TypeUserAggregate tua = (TypeUserAggregate)pus.GetParam(DataType.UserAggregate);
            AggregateUser au = (AggregateUser)tua.UserAggregate();
            DataListUser dlu;
            Console.WriteLine("this is size of AggregateUser in Rental class: " + au.Size());

            for (int i = 0; i < au.Size(); i++)
            {
                dlu = (DataListUser)au.GetData(i);
                comboBox1.Items.Add(dlu.UserName());
                int index = comboBox1.FindString(comboBox1.Text);
                comboBox1.SelectedIndex = index;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
