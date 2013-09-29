using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WotWforum.ViewModel
{
    class MainViewModel:INotifyPropertyChanged
    {
        public LocalDB localDB { get; set; }

        public ObservableCollection<UserInfoViewModel> userinfo { get; private set; }

        public bool IsDataLoaded { get; private set; }
        
        public MainViewModel()
        {
            userinfo = new ObservableCollection<UserInfoViewModel>();
            localDB = new LocalDB("DataSource = isostore/userinfo.sdf");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertynName) 
        {
            var handler = PropertyChanged;
            if (null != handler) 
            {
                //handler(this.PropertyChangedEventArgs(propertynName));
            }
        }

        public void LoadData()
        {
            IsDataLoaded = true;

            using (localDB) 
            {
                if (!localDB.DatabaseExists())
                {
                    localDB.CreateDatabase();
                    localDB.SubmitChanges();
                }

                else
                {
                    //foreach (var username in localDB.username)
                    //{
                    //    username.Add(username);
                    //}
                }
            }
        }
    }
}
