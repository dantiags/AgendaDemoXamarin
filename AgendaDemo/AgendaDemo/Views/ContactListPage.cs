using AgendaDemo.Model;
using AgendaDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AgendaDemo.Views
{
    public class ContactListPage: MasterDetailPage
    {
        public ContactListPage()
        {
            var list = new ListView();

            var contacts = ServiceManager.GetContacts("c92a7b49060a9f9640e10134aa7654ea903c2fa3");
            list.ItemsSource = contacts;

            list.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    Detail = new ContactPage(e.SelectedItem as Contact);
                    IsPresented = false;
                }
            };

            Master = new ContentPage
            {
                Title = "Contacts",
                Content = list
            };

            Detail = new ContactPage(contacts[0]);
        }
    }
}
