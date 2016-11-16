using PCLAppConfig;
using Plugin.Geolocator;
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

            btnGetGeoLocation.Clicked += async (sender, args) =>
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100; //100 is new default

                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

                lblLocation.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                var text = "Position Status: " + position.Timestamp + "\n";
                text += "Position Latitude: " + position.Latitude + "\n";
                text += "Position Longitude: " + position.Longitude;
                lblLocation.Text = text;
            };


        }
    }
}
