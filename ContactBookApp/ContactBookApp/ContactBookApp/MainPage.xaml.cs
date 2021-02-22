using ContactBookApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactBookApp
{
    public partial class MainPage : ContentPage
    {
        //initialize the ContactService class to be able to access the list of contacts 
        private ObservableCollection<Contact> _contacts;      

        public MainPage()
        {
            InitializeComponent();
            //display the properties and contacts hard-coded into the Contacts service 
            _contacts = new ObservableCollection<Contact>
            {
                new Contact {Id=1, FirstName="Laura", LastName="Ha", Email="laura.ha@test.com", Phone="555-555-5555", IsBlocked=false},
                new Contact {Id=2, FirstName="Tobi", LastName="Ha", Email="tobi.ha@tobi.com", Phone="222-222-2222", IsBlocked=false}
            };

            contactList.ItemsSource = _contacts;
        }

        //When Add button in toolbar is clicked - OnAddContact
        async void OnAddContact(object sender, EventArgs e)
        {
            _contacts = new ObservableCollection<Contact>();
            var page = new ContactDetailsPage(new Contact());

            //subscribe to the ContactAdded event delegated by EventHandler<Contact> in ContactDetailsPage.xaml.cs
            page.ContactAdded += (source, contact) => _contacts.Add(contact);
            //navigate to page once contact is added
            await Navigation.PushAsync(page);
        }

        //when a contact is selected from the list
        async void Contact_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (contactList.SelectedItem == null)
            {
                return;
            }

            var selectedContact = e.SelectedItem as Contact;

            //make sure it's unselected when you go back to the main list
            contactList.SelectedItem = null;

            //subscribe to the ContactUpdated event 
            var page = new ContactDetailsPage(selectedContact);

            page.ContactUpdated += (source, contact) =>
            {             //update all the properties of the contact
                selectedContact.Id = contact.Id;
                selectedContact.FirstName = contact.FirstName;
                selectedContact.LastName = contact.LastName;
                selectedContact.Phone = contact.Phone;
                selectedContact.Email = contact.Email;
                selectedContact.IsBlocked = contact.IsBlocked;
            };

            //after all that, show the contact details page
            await Navigation.PushAsync(page);
        }

        //when Delete is clicked, 
        async void OnDelete(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            //if they accept:
            if (await DisplayAlert("Delete", "Are you sure you want to delete this contact?", "Yes", "No"))
            {
                //remove from the observable collection Contact
                _contacts.Remove(contact);
            }
        }
    }
}
