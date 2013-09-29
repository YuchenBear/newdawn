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
using Microsoft.Phone.Tasks;

namespace WotWforum.Pages
{
    public partial class ForumPage : PhoneApplicationPage
    {
        PhoneCallTask phoneTask = null;// Constructor
        PhoneNumberChooserTask phoneNumberChooserTask;

        public ForumPage()
        {
            InitializeComponent();
            phoneNumberChooserTask = new PhoneNumberChooserTask();
            phoneNumberChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);
            phoneTask = new PhoneCallTask();
        }

        void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                //Code to start a new phone call using the retrieved phone number.
                phoneTask.DisplayName = e.DisplayName;
                phoneTask.PhoneNumber = e.PhoneNumber;
                phoneTask.Show();
            }
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

        private void ThreadList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            (App.Current as App).SelectedThread = ThreadList.SelectedItem as Thread;
            (App.Current as App).SelectedThreadIndex = ThreadList.SelectedIndex;
            NavigationService.Navigate(new Uri("/Pages/CommentPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void newThreadAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/NewThreadPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void AgreeMenu_Click(object sender, RoutedEventArgs e)
        {
            (ThreadList.SelectedItem as Thread).Agree();
        }

        private void DisagreeMenu_Click(object sender, RoutedEventArgs e)
        {
            (ThreadList.SelectedItem as Thread).Disagree();
        }

        private void CallMenu_Click(object sender, RoutedEventArgs e)
        {
            phoneTask.DisplayName = "Rick Scott";
            phoneTask.PhoneNumber = "9043528125";
            phoneTask.Show();
        }

        private void MailMenu_Click(object sender, RoutedEventArgs e)
        {

            EmailComposeTask emailcomposer = new EmailComposeTask();
            emailcomposer.To = "scottopengov@eog.myflorida.com";
            emailcomposer.Subject = (ThreadList.SelectedItem as Thread).title;
            emailcomposer.Body = (ThreadList.SelectedItem as Thread).comment;
            emailcomposer.Show();
        }
    }
}