using ContactBookApp.Models;
using ContactBookApp.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailsPage : ContentPage
    {
        
        //create event delegates to reference respective methods
        public event EventHandler<Contact> ContactAdded; //ContactAdded method
        public event EventHandler<Contact> ContactUpdated; //ContactUpdated method

        private SQLiteAsyncConnection _connection;

        public ContactDetailsPage(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            //you can't just bind the context to the ContactService you created. you must bind it to a new Contact object and it's properties
            BindingContext = new Contact { Id = contact.Id, FirstName = contact.FirstName, LastName = contact.LastName, Phone = contact.Phone, Email = contact.Email, IsBlocked = contact.IsBlocked };


        }

        async void OnSave(object sender, EventArgs e)
        {
            
            var contact = BindingContext as Contact;

            //if the first name is empty, show an alert asking them to enter their first name.
            if (String.IsNullOrWhiteSpace(contact.FirstName)) 
            {
                await DisplayAlert("Error", "Please enter your first name.", "Ok", "No thanks");
                return; 
            }

            //if it's a new contact, assign an id number to the new contact id
            if (contact.Id == 0)
            {
                await _connection.InsertAsync(contact);

                ContactAdded?.Invoke(this, contact);
            }

            else
            {
                await _connection.UpdateAsync(contact);

                ContactUpdated?.Invoke(this, contact);
            }

    

            //after all checked, pop this page off the stack.
            await Navigation.PopAsync();
        }
    }
}