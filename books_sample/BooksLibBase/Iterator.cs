using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BooksLib;

namespace BooksLib
{
    /// <summary>
    /// イテレータ基本クラス
    /// </summary>
    public class IteratorBase
    {
        protected IteratorBase() { }//デフォルトコンストラクタは無効

        public virtual DataListBase Next()
        {
            return null;
        }

        public virtual bool HasNext()
        {
            return false;
        }
    }

    /// <summary>
    /// 書籍データ用イテレータ
    /// </summary>
    public class IteratorBook : IteratorBase
    {
        private AggregateBook bookInfo;
        private int index = 0;

        protected IteratorBook() { }//デフォルトコンストラクタは無効

        public IteratorBook(AggregateBook bookInfo)
        {
            this.bookInfo = bookInfo;
        }

        public override DataListBase Next()
        {
            DataListBase data = bookInfo.GetData(index);
            return data;
        }

        public override bool HasNext()
        {
            if (index < bookInfo.Size())
                return true;
            else
                return false;
        }
    }
    //ユーザイテレータ
    public class IteratorUser : IteratorBase
    {
        private AggregateUser userInfo;
        private int index = 0;

        public IteratorUser() { }
        public IteratorUser(AggregateUser userInfo)
        {
            this.userInfo = userInfo;
        }

        public override bool HasNext()
        {
            if (index < userInfo.Size())
                return true;
            else 
                return false;
        }
        public override DataListBase Next()
        {
            DataListBase data = userInfo.GetData(index);
            Console.WriteLine("Iterator class index: {0}", index);
            index++;
            return data;
        }
    }
    //カテゴリイテレータ
    public class IteratorCategory : IteratorBase
    {
        private AggregateBase categoryInfo;
        private int index = 0;
        public IteratorCategory(AggregateCategory categoryInfo)
        {
            this.categoryInfo = categoryInfo;
        }
        public override bool HasNext()
        {
            if (index < categoryInfo.Size())
                return true;
            else
                return false;
        }
        public override DataListBase Next()
        {
            DataListBase data = categoryInfo.GetData(index);
            index++;
            return data;
        }
    }
}
