using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using WotWforum.ViewModel;

namespace WotWforum
{
    class LocalDB:DataContext
    {
        public LocalDB(String connectionString) : base(connectionString) 
        { 
        
        }

        public Table<UserInfoViewModel> userinfo;


    }
}
