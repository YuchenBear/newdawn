﻿#pragma checksum "C:\Users\Yuchen Xiong\Desktop\Local Database Sample\C#\sdkLocalDatabaseCS\NewTaskPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2E9609AAE2EDE97BA34F690FD34CE3E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace sdkLocalDatabaseCS {
    
    
    public partial class NewTaskPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.StackPanel ContentPanel;
        
        internal System.Windows.Controls.TextBox newTaskNameTextBox;
        
        internal Microsoft.Phone.Controls.ListPicker categoriesListPicker;
        
        internal System.Windows.Controls.TextBox description;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appBarOkButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appBarCancelButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/sdkLocalDatabaseCS;component/NewTaskPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.StackPanel)(this.FindName("ContentPanel")));
            this.newTaskNameTextBox = ((System.Windows.Controls.TextBox)(this.FindName("newTaskNameTextBox")));
            this.categoriesListPicker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("categoriesListPicker")));
            this.description = ((System.Windows.Controls.TextBox)(this.FindName("description")));
            this.appBarOkButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appBarOkButton")));
            this.appBarCancelButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appBarCancelButton")));
        }
    }
}

