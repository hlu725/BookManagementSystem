using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksLib
{
    public class ServiceInterface
    {
        protected ParamList param;

        protected ServiceInterface()
        {
        }

        public ServiceInterface(ParamList param)
        {
            this.param = param;
        }       

        public virtual void Run()
        {
        }
    }

    //書籍検索
    public class ServiceBooksSearch : ServiceInterface
    {
        protected ServiceBooksSearch()
        {
        }

        public ServiceBooksSearch(ParamList param)
            : base(param)
        {
        }

        public override void Run()
        {
            SearchData();
        }

        private void SearchData()
        {
            Console.WriteLine("ServiceBooksSearch Run");
            //検索実行
            DataAccessInterface dataAccess = new DBTableAccess();
            AggregateBook aggregate = (AggregateBook)dataAccess.Search(DataAccessInterface.SearchPattern.BooksAllInfo, param);

            //取得データを格納
            TypeBookAggregate bookInfo = new TypeBookAggregate(aggregate);
            param.SetParam(bookInfo);
        }
    }
    //書籍登録
    public class ServiceRegistBook : ServiceInterface
    {
        public ServiceRegistBook()
        {
        }
        public ServiceRegistBook(ParamList param)
            : base(param)
        { 
        }
        public override void Run()
        {
            base.Run();

            DataAccessInterface dataAccess = new DBTableAccess();
            dataAccess.Regist(DataAccessInterface.DataTable.Books, param);
        }
    }
    //ユーザ登録
    public class ServiceRegistUser : ServiceInterface
    {
        public ServiceRegistUser() { }
        public ServiceRegistUser(ParamList param)
            : base(param)
        { 
        }
        public override void Run()
        {
            DataAccessInterface dataAccess = new DBTableAccess();
            dataAccess.Regist(DataAccessInterface.DataTable.User, param);
        }
    }
    //カテゴリ検索
    public class ServiceSearchCategory : ServiceInterface
    {
        public ServiceSearchCategory() { }
        public ServiceSearchCategory(ParamList param)
            : base(param)
        {
        }
        public override void Run()
        {
            DataAccessInterface dataAccess = new DBTableAccess();
            AggregateCategory aggregate = (AggregateCategory)dataAccess.Search(DataAccessInterface.SearchPattern.Categorys, param);

            TypeCategoryAggregate categoryInfo = new TypeCategoryAggregate(aggregate);
            param.SetParam(categoryInfo);
        }
    }
    //20130708
    //ユーザ検索
    public class ServiceSearchUser : ServiceInterface
    {
        public ServiceSearchUser() { }
        public ServiceSearchUser(ParamList param)
            : base(param)
        { 
        }
        public override void Run()
        {
            Console.WriteLine("ServiceSearchUser Run");
            DataAccessInterface dataAccess = new DBTableAccess();
            AggregateUser aggregate = (AggregateUser)dataAccess.Search(DataAccessInterface.SearchPattern.Users, param);

            Console.WriteLine("this is size of Run method in Service class: "+aggregate.Size());
            //IteratorUser iu = (IteratorUser)aggregate.Iterator();
            //while (iu.HasNext())
            //{
            //    DataListUser dlu = (DataListUser)iu.Next();
            //    Console.WriteLine("this is Iterator in Run Method: " + dlu.UserName());                
            //}
            TypeUserAggregate userInfo = new TypeUserAggregate(aggregate);
            param.SetParam(userInfo);
        }
    }
    //権限取得
    public class ServiceAuthManager : ServiceInterface
    {
        private TypePassword password = new TypePassword("000");
        public ServiceAuthManager() { }
        public ServiceAuthManager(ParamList param)
            : base(param)
        {
        }
        public override void Run()
        {
            Console.WriteLine("ServiceAuthManager: {0}", password);
            param.SetParam(password);
        }
    }
}
