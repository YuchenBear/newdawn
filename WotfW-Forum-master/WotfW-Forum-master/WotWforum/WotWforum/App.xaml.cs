using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using WotWforum.Classes;
using WotWforum.ViewModel;
using WotWforum.Model;
using System.Collections.ObjectModel;

namespace WotWforum
{
    public partial class App : Application
    {
        // The static ViewModel, to be used across the application.
        private static TopicViewModel viewModel;
        public static TopicViewModel ViewModel
        {
            get { return viewModel; }
        }

        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        public string Name { get; set; }
        public IsolatedStorageSettings Settings = IsolatedStorageSettings.ApplicationSettings;
        public Thread SelectedThread;
        public int SelectedThreadIndex;
        public ObservableCollection<Thread> Threads = Thread.GetThreads();

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Standard Silverlight initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

            // Specify the local database connection string.
            string DBConnectionString = "Data Source=isostore:/Topics.sdf";

            // Create the database if it does not exist.
            using (TopicContext db = new TopicContext(DBConnectionString))
            {
                if (db.DatabaseExists() == false)
                {
                    // Create the local database.
                    db.CreateDatabase();

                    // Prepopulate the categories.
                    db.Categories.InsertOnSubmit(new TopicCategory { Name = "Date" });
                    db.Categories.InsertOnSubmit(new TopicCategory { Name = "Nearby" });
                    db.Categories.InsertOnSubmit(new TopicCategory { Name = "@" });

                    // Save categories to the database.
                    db.SubmitChanges();
                }
            }

            // Create the ViewModel object.
            viewModel = new TopicViewModel(DBConnectionString);

            // Query the local database and load observable collections.
            viewModel.LoadCollectionsFromDatabase();

        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            Threads.ElementAt(0).AddReply("Albert", "I'm sorry");
            Threads.ElementAt(0).AddReply("Alvin", "I'll pray for your success!");
            Threads.ElementAt(0).AddReply("Vivi", "Should have take better care of it!");
            Threads.ElementAt(0).AddReply("Ted", "I have it!");

            Threads.ElementAt(1).AddReply("Albert", "Not important");
            Threads.ElementAt(1).AddReply("Alvin", "Me too");
            Threads.ElementAt(1).AddReply("Vivi", "This is what our tax money is spent on?");
            Threads.ElementAt(1).AddReply("Ted", "Buy a candle!");


            Threads.ElementAt(2).AddReply("Albert", "I want some!");
            Threads.ElementAt(2).AddReply("Alvin", "I need some");
            Threads.ElementAt(2).AddReply("Vivi", "I'll buy them all");
            Threads.ElementAt(2).AddReply("Ted", "I'll sell them cheaper");

            Threads.ElementAt(4).AddReply("Albert", "Me too!");
            Threads.ElementAt(4).AddReply("Alvin", "Congrat!");
            Threads.ElementAt(4).AddReply("Vivi", "Thank you!");
            Threads.ElementAt(4).AddReply("Partypooper", "One year closer to death!");
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}