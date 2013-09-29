using System;
using Microsoft.Devices;
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework.Media;
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

namespace PhoneApp2
{
    public partial class MainPage : PhoneApplicationPage
    {
        private byte[] _imageBytes;

        private void buttonCapture_Click(object sender, RoutedEventArgs e)
        {
            ShowCameraCaptureTask();
        }

        private void ShowCameraCaptureTask()
        {
            var cameraTask = new CameraCaptureTask();
            cameraTask.Completed += cameraTask_Completed;
            cameraTask.Show();
        }

        private void cameraTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                // Get the image temp file from e.OriginalFileName.
                // Get the image temp stream from e.ChosenPhoto.
                // Don't keep either the stream or rely on the temp
                // file name as they may be vanished!

                // Store the image bytes.
                _imageBytes = new byte[e.ChosenPhoto.Length];
                e.ChosenPhoto.Read(_imageBytes, 0, _imageBytes.Length);

                // Seek back so we can create an image.
                e.ChosenPhoto.Seek(0, SeekOrigin.Begin);

                // Create an image from the stream.
                var imageSource = PictureDecoder.DecodeJpeg(e.ChosenPhoto);

            }
        }
    }
}