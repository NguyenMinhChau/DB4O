using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADB2020MidTerm
{
    class Database
    {
        public static string DbFileName { get; set; }
        public static IObjectContainer DB = null;
        public static void Open()
        {
            DB = Db4oEmbedded.OpenFile(DbFileName);
        }
        public static void Close()
        {
            DB.Close();
        }
        public static void Store<T>(T obj)
        {
            try
            {
                DB.Store(obj);
                DB.Commit();
            }
            catch
            {
                DB.Rollback();
            }
        }
        public static void Save<A,B>(A obj1, B obj2)
        {
            try
            {
                DB.Store(obj1);
                DB.Store(obj2);
                DB.Commit();
            }
            catch
            {
                DB.Rollback();
            }
        }
        public static void Delete<T>(T obj)
        {
            try
            {
                DB.Delete(obj);
                DB.Commit();
            }
            catch
            {
                DB.Rollback();
            }
        }
    }
}
