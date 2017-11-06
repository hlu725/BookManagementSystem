using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksLib
{
    public class DataListBase
    {
        protected List<List<string>> dataList;
        protected int rowIndex;

        protected DataListBase() { }//デフォルトコンストラクタは無効

        public DataListBase(List<List<string>> dataList, int rowIndex)
        {
            this.dataList = dataList;
            this.rowIndex = rowIndex;
        }        
    }

    public class DataListBookInfo : DataListBase
    {
        private const int BookNoColumn = 0;        //書籍番号
        private const int BookNameColumn = 1;        //書籍名
        private const int AuthorColumn = 2;        //著者
        private const int PressColumn = 3;        //出版社
        private const int RegistDateColumn = 4;        //登録日
        private const int CategoryNoColumn = 5;        //カテゴリ番号
        private const int CategoryNameColumn = 6;        //カテゴリ名
        private const int RentalNoColumn = 0;        //貸出番号
        private const int RentalDateColumn = 0;        //貸出日
        private const int ReturnWillColumn = 0;        //返却予定日
        private const int ReturnDateColumn = 0;        //返却日
        private const int UserNoColumn = 0;        //利用者番号
        private const int UserNameColumn = 0;        //利用者名

        protected DataListBookInfo()  //デフォルトコンストラクタは無効
        { }
        public DataListBookInfo(List<List<string>> dataList, int rowIndex)
            : base(dataList, rowIndex)
        {
        }     

        //書籍番号
        public int BookNo()
        {
            return int.Parse(dataList[rowIndex][BookNoColumn].ToString());
        }
        //書籍名
        public string BookName()
        {
            return dataList[rowIndex][BookNameColumn].ToString();
        }
        //著者
        public string Author()
        {
            return dataList[rowIndex][AuthorColumn].ToString();
        }
        //出版社
        public string Press()
        {
            return dataList[rowIndex][PressColumn].ToString();
        }
        //カテゴリ番号
        public int CategoryNo()
        {
            return int.Parse(dataList[rowIndex][CategoryNoColumn].ToString());
        }
        //カテゴリ名
        public string CategoryName()
        {
            return dataList[rowIndex][CategoryNameColumn].ToString();
        }
        //登録日
        public string RegistDate()
        {
            return dataList[rowIndex][RegistDateColumn].ToString();
        }       
    }
    //20130708から追加
    public class DataListUser : DataListBase
    {
        private const int UserNoColumn = 0;
        private const int UserNameColumn = 1;

        public DataListUser(List<List<String>> datalist, int rowIndex)
                :base(datalist, rowIndex)
        {
        }
        public int UserNo()
        {
            return int.Parse(dataList[rowIndex][UserNoColumn].ToString());
        }

        public String UserName()
        {
            return dataList[rowIndex][UserNameColumn].ToString();
        }
    }
    //20130709から追加
    public class DataListCategory : DataListBase
    {
        private const int CategoryNoColumn = 0;
        private const int CategoryNameColumn = 1;

        public DataListCategory(List<List<String>> datalist, int rowIndex)
            :base(datalist, rowIndex)
        {
        }
        public int CategoryNo()
        {
            return int.Parse(dataList[rowIndex][CategoryNoColumn].ToString());
        }
        public String CategoryName()
        {
            return dataList[rowIndex][CategoryNameColumn].ToString();
        }
    }
}
