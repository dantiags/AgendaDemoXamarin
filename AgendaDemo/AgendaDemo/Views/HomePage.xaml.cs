using PCLAppConfig;
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
        }
    }
}
