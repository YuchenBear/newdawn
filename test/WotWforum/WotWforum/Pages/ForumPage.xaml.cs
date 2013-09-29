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
    public partial class ForumPage : PhoneApplicationPage
    {
        public ForumPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NameBlock.Text = (App.Current as App).Name;
            Visibility v = (Visibility)Resources["PhoneLightThemeVisibility"];

            if (v == System.Windows.Visibility.Visible)
            {
                // Is light theme
            }
            else
            {
                // Is dark theme
            }
            this.ThreadList.ItemsSource = (App.Current as App).Threads;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread test = new Thread();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        }

        private void ThreadList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            (App.Current as App).SelectedThread = ThreadList.SelectedItem as Thread;
            NavigationService.Navigate(new Uri("/Pages/CommentPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void newThreadAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/NewThreadPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}