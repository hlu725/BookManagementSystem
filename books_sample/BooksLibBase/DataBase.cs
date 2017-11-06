using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BooksLib
{
    /// <summary>
    /// 書籍テーブル定義
    /// </summary>
    public class DBTableBooks
    {
        public const string Table = "books";

        public const string ItemBookNo = "book_no";
        public const string ItemBookName = "book_name";
    }

    /// <summary>
    /// DBアクセスの基本クラス
    /// </summary>
    public class DBAccess
    {
        public virtual void QueryInsert(string query)
        {
        }

        public virtual void QueryDelete(string query)
        {
        }

        public virtual void QueryUpdate(string query)
        {
        }

        public virtual DataSet QuerySelect(string query)
        {
            return null;
        }
    }

    /// <summary>
    /// SQLServer用のDB操作クラス
    /// </summary>
    public class DBSqlServer : DBAccess
    {
        SqlConnection sConn = null;
        SqlCommand cmd = new SqlCommand();       

        public DBSqlServer()
        {
            string connString;
            connString = "server=0906-05-001\\SQLEXPRESS;uid=sa;pwd=furutani-01;database=BookManagement;";
           
            try
            {
                //定义连接对象sConn
                sConn = new SqlConnection(connString);
                cmd.Connection = sConn;
                //打开连接
                sConn.Open();
                Console.WriteLine("DBSqlServer Connect successful");
            }
            catch (Exception ex)
            {
                //给出错误信息
                Console.WriteLine("连接错误：" + ex.Message);
            }
          
        }
        public override void QueryInsert(string query)
        {
            //SQLServerに合わせた実装をする
            base.QueryInsert(query);
            cmd.CommandText = query;
           // cmd.CommandText = "insert into books (book_name) values('C++')";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

        public override void QueryDelete(string query)
        {
            //SQLServerに合わせた実装をする
            base.QueryDelete(query);
        }

        public override void QueryUpdate(string query)
        {
            //SQLServerに合わせた実装をする
            base.QueryUpdate(query);
        }

        public override DataSet QuerySelect(string query)
        {
            //SQLServerに合わせた実装をする
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();

            //cmd.CommandText = query;
            try
            {
                Console.WriteLine("execute select");
                adapter.SelectCommand = new SqlCommand(query, sConn);
                adapter.Fill(dataset);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dataset;
        }
        public DataSet QuerySelect(string query, string tableName)
        {
            //SQLServerに合わせた実装をする
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();

            //cmd.CommandText = query;
            try
            {
                Console.WriteLine("DBSqlServer execute select");
                adapter.SelectCommand = new SqlCommand(query, sConn);
                adapter.Fill(dataset, tableName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dataset;
        }
    }
}
