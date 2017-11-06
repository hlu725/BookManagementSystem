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
    public partial class UserRegist : Form
    {
        public UserRegist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                TypeUserName tun = new TypeUserName(textBox1.Text);
                ParamRegistUser pru = new ParamRegistUser();
                pru.SetParam(tun);

                try
                {
                    ServiceRegistUser sru = new ServiceRegistUser(pru);
                    sru.Run();
                    Close();
                }
                catch
                {
                    MessageBox.Show("error");
                }
            }
            else
            {
                MessageBox.Show("ユーザ名を入力してください");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
