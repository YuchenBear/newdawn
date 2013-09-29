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
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Phone;
using System.Windows.Media.Imaging;

namespace ChoosePhoto
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        private void btnSelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask taskToChoosePhoto = new PhotoChooserTask();
            taskToChoosePhoto.PixelHeight = 400;
            taskToChoosePhoto.PixelWidth = 400;
            taskToChoosePhoto.Show();
            taskToChoosePhoto.Completed += new EventHandler<PhotoResult>(taskToChoosePhoto_Completed);
        }
        void taskToChoosePhoto_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                string fileName = e.OriginalFileName;
                WriteableBitmap selectedPhoto = PictureDecoder.DecodeJpeg(e.ChosenPhoto);
                imgSelected.Source = selectedPhoto;
            }
        }
    }
}