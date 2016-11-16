using PCLAppConfig;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AgendaDemo.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            btnViewContacts.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ContactListPage());
            };


            btnTakePhoto.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }
                var fileName = "AgDemo_" + DateTime.Now.Millisecond.ToString() + ".jpg";
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "AgendaDemo",
                    Name = fileName
                });

                if (file == null)
                    return;

                await DisplayAlert("File Location", file.Path, "OK");

                imgTaken.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };


        }
    }
}
