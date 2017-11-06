using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BooksLib
{
    public class DataAccessInterface
    {
        protected DataAccessInterface()
        {
        }

        public enum DataTable
        {
            Books,
            Category,
            Rental,
            User,
        }

        public enum SearchPattern
        {
            BooksAllInfo,         //書籍情報全般
            Users,                  //利用者一覧
            //20130706
            Categorys,
        }

        public virtual void Regist(DataTable table, ParamList param)
        {
        }

        public virtual void Delete(DataTable table, ParamList param)
        {
        }

        public virtual void Update(DataTable table, ParamList param)
        {
        }

        public virtual AggregateBase Search(SearchPattern pattern, ParamList param)
        {
            return null;
        }

    }

    public class DBTableAccess : DataAccessInterface
    {
        public DBTableAccess()
        {
            db = new DBSqlServer();
        }

        private DBAccess db;
        //挿入
        public override void Regist(DataTable table, ParamList param)
        {
            //20130705から追加
            string query = "";
            switch (table)
            {
                case DataTable.Books:
                    Console.WriteLine("this is Regist!!");
                   // DataTypeBase dtb = param.GetParam(DataType.BookName);
                    TypeBookName tbn = (TypeBookName)param.GetParam(DataType.BookName);
                    TypeAuthor ta = (TypeAuthor)param.GetParam(DataType.Author);
                   // TypeBookName tbnn = (TypeBookName)dtb.Type();
                   // TypeBookName tbn = new TypeBookName("opengl");
                    String s1 = tbn.BookName();
                    String s2 = ta.Author();;
                    //Console.WriteLine(s);
                    query = "insert into books (book_name, author) values('"+ s1 +"', '"+ s2 +"')";                  
                    break;
                case DataTable.Category:

                    break;
                case DataTable.Rental:

                    break;

                case DataTable.User:
                    TypeUserName tun = (TypeUserName)param.GetParam(DataType.UserName);
                    //tun.UserName();
                    query = "insert into users (user_name) values('" + tun.UserName() + "')";
                    break;
                default:

                    break;
            }
           
            db.QueryInsert(query);
        }
        //削除
        public override void Delete(DataTable table, ParamList param)
        {
            string query = "";
            db.QueryDelete(query);
        }
        //更新
        public override void Update(DataTable table, ParamList param)
        {
            string query = "";
            db.QueryUpdate(query);
        }
        //条件検索
        public override AggregateBase Search(SearchPattern pattern, ParamList param)
        {
            AggregateBase aggregate;

            switch (pattern)
            {
                case SearchPattern.BooksAllInfo:
                    aggregate = SearchBooksAll(param);
                    break;
                case SearchPattern.Categorys : //20130706
                    aggregate = SearchCategoryAll(param); 
                    break;
                case SearchPattern.Users:
                    aggregate = SearchUserAll(param);
                    break;
                default:
                    aggregate = null;
                    break;
            }

            return aggregate;
        }
      
        //書籍検索
        protected AggregateBase SearchBooksAll(ParamList param)
        {
            Console.WriteLine("this is book search!");
            //検索パラメータの取り出し
            ParamBooksSearch paramList = (ParamBooksSearch)param;
            TypeBookNo bookno = (TypeBookNo)paramList.GetParam(DataType.BookNo);
            TypeBookName bookname = (TypeBookName)paramList.GetParam(DataType.BookName);

            //SQL文の組み立て 20130706
            string query = "select * from books";

            //検索実行
            DataSet dataSet = db.QuerySelect(query);

            //データの取り出し
            //System.Data.DataTableReader reader = dataSet.CreateDataReader();
            List<List<string>> dataList = new List<List<string>>();
            //int listCnt = 0;
            //while (reader.Read())
            //{
            //    //Listにデータを取り込む
            //    for (int cnt = 0; cnt < reader.VisibleFieldCount; cnt++)
            //    {
            //        dataList[listCnt][cnt] = reader[cnt].ToString();
            //    }
            //    listCnt++;
            //}

            AggregateBase aggregate = new AggregateBook(dataList);

            return aggregate;
        }
        //20130706から追加　
        //カテゴリ検索
        protected AggregateBase SearchCategoryAll(ParamList param)
        {
            Console.WriteLine("this is SearchUser method of DBTableAccess");
            AggregateBase aggregate = null;

            String query = "select * from category";
            List<List<String>> dataList = new List<List<string>>();
            DataSet dataset = ((DBSqlServer)db).QuerySelect(query, "category");

            for (int i = 0; i < dataset.Tables["category"].Rows.Count; i++)
            {
                String rowColumn0 = dataset.Tables["category"].Rows[i][0].ToString().Trim();
                String rowColumn1 = dataset.Tables["category"].Rows[i][1].ToString().Trim();
                List<String> item = new List<String>();
                item.Add(rowColumn0);
                item.Add(rowColumn1);
                dataList.Add(item);
            }
            for (int j = 0; j < dataList.Count; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    Console.Write("this is DBTableAccess: " + dataList[j][k].ToString() + "  ");
                    Console.WriteLine(dataList[j][k].ToString());
                }
            }
            aggregate = new AggregateCategory(dataList);
            return aggregate;
        }
        //20130708から追加
        //ユーザ検索
        protected AggregateBase SearchUserAll(ParamList param)
        {
            Console.WriteLine("this is SearchUser method of DBTableAccess");
            AggregateBase aggregate = null;
            String query = "select * from users";

            List<List<string>> dataList = new List<List<string>>();            
            DataSet dataset = ((DBSqlServer)db).QuerySelect(query, "users");

            for (int i = 0; i < dataset.Tables["users"].Rows.Count; i++)
            {
                String rowColumn0 = dataset.Tables["users"].Rows[i][0].ToString().Trim();
                String rowColumn1 = dataset.Tables["users"].Rows[i][1].ToString().Trim();
                //Console.WriteLine("this is DBTableAccess: " + rowColumn);
                List<String> item = new List<string>();
                item.Add(rowColumn0);
                item.Add(rowColumn1);
                dataList.Add(item);
            }
           
            for (int j = 0; j < dataList.Count; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    Console.Write("this is DBTableAccess: " + dataList[j][k].ToString()+"  ");
                    Console.WriteLine(dataList[j][k].ToString());
                }
            }
            
            aggregate = new AggregateUser(dataList);

            return aggregate;
        }
    }
    
}
