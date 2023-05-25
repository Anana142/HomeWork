using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Database
{
    public class DataBase
    {
        public DataBase() { }
        static ShopContext instance;
        public static ShopContext GetInstance()
        {
            if (instance == null)
                instance = new ShopContext();
            return instance;
        }
    }
}
