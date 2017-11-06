using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksLib
{
    /// <summary>
    /// 書籍番号
    /// </summary>
    public class TypeBookNo : DataTypeInteger
    {
        protected TypeBookNo()
        {
        }

        public TypeBookNo(int value)
            : base(DataType.BookNo, value)
        {
        }

        public int BookNo()
        {
            return data;
        }
    }
    
    /// <summary>
    /// 書籍名称
    /// </summary>
    public class TypeBookName : DataTypeString
    {
        protected TypeBookName()
        {
        }

        public TypeBookName(string value)
            : base(DataType.BookName, value)
        {
        }

        public string BookName()
        {
            return data;
        }
    }

    /// <summary>
    /// カテゴリ番号
    /// </summary>
    public class TypeCategoryNo : DataTypeInteger
    {
        protected TypeCategoryNo()
        {
        }

        public TypeCategoryNo(int value)
            : base(DataType.CategoryNo, value)
        {
        }

        public int CategoryNo()
        {
            return data;
        }
    }

    /// <summary>
    /// 貸出状態
    /// </summary>
    public class TypeRentalState : DataTypeInteger
    {
        public enum RentalState
        {
            NoRental,      //貸出し中でない
            Rental,        //貸出し中
            ReturnOver,    //返却予定延滞
        }

        protected TypeRentalState()
        {
        }

        public TypeRentalState(RentalState value)
            : base(DataType.BookNo, (int)value)
        {
        }

        public RentalState State()
        {
            return (RentalState)data;
        }
    }

    /// <summary>
    /// 貸出日
    /// </summary>
    public class TypeRentalDate : DataTypeDateString
    {
        protected TypeRentalDate()
        {
        }

        public TypeRentalDate(string value)
            : base(DataType.RentalDate, value)
        {
        }

        public string RentalDate()
        {
            return data;
        }
    }

    /// <summary>
    /// 書籍情報の集合
    /// </summary>
    public class TypeBookAggregate : DataTypeAggreegate
    {
        protected TypeBookAggregate() { }

        public TypeBookAggregate(AggregateBase value)
            : base(DataType.BookAggregate, value)
        {
        }

        public AggregateBase BookAggregate()
        {
            return data;
        }
    }
    //20130705から追加
    public class TypeAuthor : DataTypeString
    {
        public TypeAuthor(String value)
        :base(DataType.Author, value)
        {

        }
        public String Author()
        {
            return data;
        }
    }

    public class TypePress : DataTypeString
    {
        public TypePress(String value)
        :base(DataType.Press, value)
        {

        }

        public String Press()
        {
            return data;
        }
    }

    public class TypeRegistDate : DataTypeString
    {
        public TypeRegistDate(String value)
        :base(DataType.RegistDate, value)
        {

        }
        public String RegistDate()
        {
            return data;
        }
    }

    public class TypeCategoryAggregate : DataTypeAggreegate
    {
        public TypeCategoryAggregate(AggregateBase value)
            : base(DataType.CategoryAggregate, value)
        {

        }
        public AggregateBase CategoryAggregate()
        {
            return data;
        }
    }
    public class TypeUserName : DataTypeString
    {
        public TypeUserName(String value)
            : base(DataType.UserName, value)
        {
        }
        public String UserName()
        {
            return data;
        }
    }
    //20130708
    public class TypeCategoryName : DataTypeString
    {
        public TypeCategoryName(String value)
        :base(DataType.CategoryName, value)
        {

        }
        public String CategoryName()
        {
            return data;
        }
    }
    public class TypeReturnDate : DataTypeDateString
    {
        public TypeReturnDate(String value)
            : base(DataType.ReturnDate, value)
        {
        }
        public String ReturnDate()
        {
            return data;
        }
    }
    public class TypeReturnWill : DataTypeDateString
    {
        public TypeReturnWill(String value)
            : base(DataType.ReturnWill, value)
        {
        }
        public String ReturnWill()
        {
            return data;
        }
    }
    public class TypeUserAggregate : DataTypeAggreegate
    {
        public TypeUserAggregate(AggregateBase value)
            :base(DataType.UserAggregate, value)
        {
        }
        public AggregateBase UserAggregate()
        {
            return data;
        }
    }
    public class TypeUserNo : DataTypeInteger
    {
        public TypeUserNo(int value)
            :base(DataType.UserNo, value)
        {
        }
        public int UserNo()
        {
            return data;
        }
    }
    public class TypePassword : DataTypeString
    {
        public TypePassword(String value)
            :base(DataType.Password, value)
        { 
        }
        public String Password()
        {
            return data;
        }
    }
}
