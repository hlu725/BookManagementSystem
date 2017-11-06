using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksLib
{
    /// <summary>
    /// データ種別
    /// </summary>
    public enum DataType
    {
        None,                   //不定
        BookNo,                 //書籍番号
        BookName,               //書籍名 
        Author,                 //著者
        Press,                  //出版社
        RegistDate,             //登録日
        CategoryNo,             //カテゴリ番号
        CategoryName,           //カテゴリ名称
        RentalDate,             //貸出日
        ReturnWill,             //返却予定日
        ReturnDate,             //返却日
        Password,               //パスワード
        UserName,               //ユーザー氏名
        RentalState,            //貸出し状態
        BookAggregate,          //書籍情報の集合
        CategoryAggregate,      //20130706
        UserAggregate,
        UserNo,
    }

    /// <summary>
    /// データ型の基本クラス
    /// </summary>
    public class DataTypeBase
    {
        protected DataType type = DataType.None;       //データ種別
        protected int size = 0;         //データサイズ

        protected DataTypeBase()
        {
        }

        protected DataTypeBase(DataType type)
        {
            this.type = type;
        }      

        public DataType Type()
        {
            return type;
        }
    }

    /// <summary>
    /// 整数型データの基本クラス
    /// </summary>
    public class DataTypeInteger : DataTypeBase
    {
        protected int data = 0;

        protected DataTypeInteger()
        {
        }

        protected DataTypeInteger(DataType type, int value) 
            : base(type)
        {
            data = value;
            size = sizeof(int);
        }
        
    }

    /// <summary>
    /// 文字列型データの基本クラス
    /// </summary>
    public class DataTypeString : DataTypeBase
    {
        protected string data = null;

        protected DataTypeString()
        {
        }

        protected DataTypeString(DataType type, string value) 
            : base(type)
        {
            data = value;
            size = value.Length;
        }        
    }

    /// <summary>
    /// 日付文字列データ
    ///   YYYY/MM/DD 
    /// </summary>
    public class DataTypeDateString : DataTypeString
    {
        protected DataTypeDateString()
        {
        }

        public DataTypeDateString(DataType type, string value)
            : base(type, value)
        {
        }

        private int GetDateItem(int index, int size)
        {
            int item;
            //get date and change to int
            try
            {
                string itemStr = data.Substring(index, size);
                item = int.Parse(itemStr);
            }
            catch (Exception exception)
            {
                item = 0;
                System.Diagnostics.Debugger.Log(0, "", exception.Message);
            }

            return item;
        }

        public int Year()
        {
            return GetDateItem(0,4);
        }

        public int Month()
        {
            return GetDateItem(5,2);
        }

        public int Day()
        {
            return GetDateItem(8,2);
        }
    }

    public class DataTypeAggreegate : DataTypeBase
    {
        protected AggregateBase data = null;

        protected DataTypeAggreegate() { }

        protected DataTypeAggreegate(DataType type, AggregateBase value)
            : base(type)
        {
            data = value;
        }
      
    }
}
