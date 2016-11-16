using AgendaDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AgendaDemo.Views
{
    public partial class ContactPage : ContentPage
    {
        public ContactPage(Contact contact)
        {
            InitializeComponent();
            BackgroundColor = Color.FromRgb(48, 63, 159);
            BindingContext = contact;
        }
    }
}
