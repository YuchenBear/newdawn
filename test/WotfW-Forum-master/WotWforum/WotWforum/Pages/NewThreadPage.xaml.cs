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
    public partial class NewThreadPage : PhoneApplicationPage
    {
        public NewThreadPage()
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
                Thread newThread = new Thread
                {
                    name = (App.Current as App).Name,
                    title = newTaskNameTextBox.Text,
                    comment = description.Text,
                    date = DateTime.Now
                };

                // Add the topic to the ViewModel.
                (App.Current as App).Threads.Add(newThread);

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
