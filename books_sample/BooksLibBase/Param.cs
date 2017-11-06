using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksLib
{
    /// <summary>
    /// パラメータリスト基本クラス
    /// </summary>
    public class ParamList
    {
        protected ParamList()
        {
        }

        /// <summary>
        /// パラメータ格納
        /// </summary>
        /// <param name="paramData"></param>
        /// <returns></returns>
        public virtual void SetParam(DataTypeBase paramData)
        {
        }

        /// <summary>
        /// パラメータ参照
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual DataTypeBase GetParam(DataType type)
        {
            return null;
        }
    }

    /// <summary>
    /// パラメータリスト　図書検索
    /// </summary>
    public class ParamBooksSearch : ParamList
    {
        private TypeBookNo bookNo;
        private TypeBookName bookName;
        private TypeRentalState rentalState;
        private TypeCategoryNo categoryNo;
        private TypeBookAggregate bookInfo;

        public override void SetParam(DataTypeBase paramData)
        {
            switch (paramData.Type())
            {
                case DataType.BookNo:
                    bookNo = (TypeBookNo)paramData;
                    break;
                case DataType.BookName:
                    bookName = (TypeBookName)paramData;
                    break;
                case DataType.BookAggregate:
                    bookInfo = (TypeBookAggregate)paramData;
                    break;
                case DataType.RentalState:
                    rentalState = (TypeRentalState)paramData;
                    break;
                case DataType.CategoryNo:
                    categoryNo = (TypeCategoryNo)paramData;
                    break;
                default:
                    break;
            }
        }

        public override DataTypeBase GetParam(DataType type)
        {
            DataTypeBase data = null;
            switch (type)
            {
                case DataType.BookNo:
                    data = bookNo;
                    break;
                case DataType.BookName:
                    data = bookName;
                    break;
                case DataType.BookAggregate:
                    data = bookInfo;
                    break;
                case DataType.RentalState:
                    data = rentalState;
                    break;
                case DataType.CategoryNo:
                    data = categoryNo;
                    break;
                default:
                    data = null;
                    break;
            }

            return data;
        }
    }
    //20130705から追加部分
    public class ParamRegistBook : ParamList
    {
        //変数宣言
        private TypeBookName bookName;
        private TypeAuthor author;
        private TypePress press;
        private TypeRegistDate registDate;
        private TypeCategoryNo categoryNo;

        public override void SetParam(DataTypeBase paramData)
        {
            switch (paramData.Type())
            {
                case DataType.BookName:
                    bookName = (TypeBookName)paramData;
                    break;
                case DataType.Author:
                    author = (TypeAuthor)paramData;
                    break;
                case DataType.Press:
                    press = (TypePress)paramData;
                    break;
                case DataType.RegistDate:
                    registDate = (TypeRegistDate)paramData;
                    break;
                case DataType.CategoryNo:
                    categoryNo = (TypeCategoryNo)paramData;
                    break;
                default:
                    break;
            }
        }

        public override DataTypeBase GetParam(DataType type)
        {
            DataTypeBase data = null;
            switch (type)
            {
                case DataType.BookName:
                    data = bookName;
                    break;
                case DataType.Author:
                    data = author;
                    break;
                case DataType.Press:
                    data = press;
                    break;
                case DataType.RegistDate:
                    data = registDate;
                    break;
                case DataType.CategoryNo:
                    data = categoryNo;
                    break;
                default:
                    data = null;
                    break;
            }
            return data;
        }
    }
    //20130706ユーザ登録getterとsetter
    public class ParamRegistUser : ParamList
    {
        private TypeUserName userName;

        public override void SetParam(DataTypeBase paramData)
        {
            switch (paramData.Type())
            {
                case DataType.UserName:
                    userName = (TypeUserName)paramData;
                    break;
                default:
                    break;
            }
        }
        public override DataTypeBase GetParam(DataType type)
        {
            DataTypeBase data = null;
            switch (type)
            {
                case DataType.UserName:
                    data = userName;
                    break;
                default:
                    data = null;
                    break;
            }
            return data;
        }
    }
    //カテゴリ検索getterとsetter
    public class ParamCategorySearch : ParamList
    {
        private TypeCategoryNo categoryNo;
        private TypeCategoryAggregate categoryAggregate;

        public override void SetParam(DataTypeBase paramData)
        {
            switch (paramData.Type())
            {
                case DataType.CategoryNo:
                    categoryNo = (TypeCategoryNo)paramData;
                    break;
                case DataType.CategoryAggregate:
                    categoryAggregate = (TypeCategoryAggregate)paramData;
                    break;
                default:
                    break;
            }
        }

        public override DataTypeBase GetParam(DataType type)
        {
            DataTypeBase data = null;
            switch (type)
            {
                case DataType.CategoryNo:
                    data = categoryNo;
                    break;
                case DataType.CategoryAggregate:
                    data = categoryAggregate;
                    break;
                default:
                    data = null;
                    break;
            }
            return data;
        }
    }
    //20130708ユーザ検索getterとsetter
    public class ParamUserSearch : ParamList
    {
        private TypeUserNo userNo;
        private TypeUserAggregate user;

        public override void SetParam(DataTypeBase paramData)
        {
            switch (paramData.Type())
            {
                case DataType.UserNo:
                    userNo = (TypeUserNo)paramData;
                    break;
                case DataType.UserAggregate:
                    user = (TypeUserAggregate)paramData;
                    break;
                default:
                    break;
            }
        }
        public override DataTypeBase GetParam(DataType type)
        {
            DataTypeBase data = null;
            switch (type)
            {
                case DataType.UserNo:
                    data = userNo;
                    break;
                case DataType.UserAggregate:
                    data = user;
                    break;
                default:
                    data = null;
                    break;
            }

            return data;
        }
    }
    public class ParamAuthManager : ParamList
    {
        private TypePassword password;

        public override void SetParam(DataTypeBase paramData)
        {
            switch (paramData.Type())
            {
                case DataType.Password:
                    password = (TypePassword)paramData;
                    break;
                default:
                    break;
            }
        }
        public override DataTypeBase GetParam(DataType type)
        {
            DataTypeBase data;
            switch (type)
            {
                case DataType.Password:
                    data = password;
                    break;
                default:
                    data = null;
                    break;
            }
            return data;
        }
    }    

}
