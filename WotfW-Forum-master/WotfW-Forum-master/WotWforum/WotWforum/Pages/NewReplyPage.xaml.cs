using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WotWforum.Model;
using WotWforum.Classes;

namespace WotWforum.Pages
{
    public partial class NewReplyPage : PhoneApplicationPage
    {
        public NewReplyPage()
        {
            InitializeComponent();

            // Set the page DataContext property to the ViewModel.
            this.DataContext = App.ViewModel;
        }

        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            // Confirm there is some text in the text box.
            if (newTaskNameTextBox.Text.Length > 0)
            {
                Reply newReply = new Reply
                {
                    name = (App.Current as App).Name,
                    comment = description.Text,
                    date = DateTime.Now
                };

                // Add the topic to the ViewModel.
                (App.Current as App).Threads.ElementAt((App.Current as App).SelectedThreadIndex).AddReply(newReply);

                // Return to the main page.
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            }
        }

        private void appBarCancelButton_Click(object sender, EventArgs e)
        {
            // Return to the main page.
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void newTaskDescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
