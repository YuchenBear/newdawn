using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WotWforum.Classes;

namespace WotWforum.Pages
{
    public partial class CommentPage : PhoneApplicationPage
    {
        //public Thread SelectedThread { get; set; }
        public CommentPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Thread test = new Thread();
            this.LayoutRoot.DataContext = (App.Current as App).SelectedThread;
            this.ReplyList.ItemsSource = (App.Current as App).SelectedThread.replies;
        }
    }
}