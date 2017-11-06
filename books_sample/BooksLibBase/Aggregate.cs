using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BooksLib;

namespace BooksLib
{
    /// <summary>
    /// データ集合の基本クラス
    /// </summary>
    public class AggregateBase
    {
        protected List<List<string>> dataset;

        protected AggregateBase() { }//デフォルトコンストラクタは無効
        
        public virtual IteratorBase Iterator()
        {
            return null;
        }

        public virtual int Size()
        {
            return 0;
        }

        public virtual DataListBase GetData(int index)
        {
            return null;
        }
    }

    /// <summary>
    /// 書籍データ集合
    /// </summary>
    public class AggregateBook : AggregateBase
    {
        protected AggregateBook() { }//デフォルトコンストラクタは無効

        public AggregateBook(List<List<string>> dataset)
        {
            this.dataset = dataset;
        }

        public override IteratorBase Iterator()
        {
            return new IteratorBook(this);
        }

        public override int Size()
        {
            return dataset.Count;
        }

        public override DataListBase GetData(int index)
        {
            return new DataListBookInfo(dataset, index);
        }
    }
    //20130708から追加
    //ユーザ集合
    public class AggregateUser : AggregateBase
    {
        public AggregateUser(List<List<String>> dataset)
        {
            this.dataset = dataset;
            Console.WriteLine("this is AggreagteUser Construtor");
        }
        public override IteratorBase Iterator()
        {
            return new IteratorUser(this);
        }
        public override int Size()
        {
            return dataset.Count;
        }
        public override DataListBase GetData(int index)
        {
            Console.WriteLine("Aggreagte User getData index: {0}", index);
            //Console.WriteLine("Aggregate get: " + dataset[1][1].ToString());
            return new DataListUser(dataset, index);
        }
    }
    public class AggregateCategory : AggregateBase
    {
        public AggregateCategory(List<List<String>> dataset)
        {
            this.dataset = dataset;
            Console.WriteLine("this is AggreagteCategory Construtor");
        }

        public override int Size()
        {
            return dataset.Count;
        }
        public override DataListBase GetData(int index)
        {
            return new DataListCategory(dataset, index);
        }
    }
}
