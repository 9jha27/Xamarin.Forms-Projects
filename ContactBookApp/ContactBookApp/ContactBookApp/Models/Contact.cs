using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ContactBookApp.Models
{
    public class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //properties of a phone contact
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _firstname;

        public string FirstName
        {
            get { return _firstname; }
            set
            {
                //if the name values are the same, return the value
                if (_firstname == value)
                    return;

                _firstname = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _lastname;

        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (_lastname == value)
                    return;

                _lastname = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        public bool IsBlocked { get; set; }

        [MaxLength(255)]
        public string FullName
        {
            get { return $"{ FirstName} {LastName}"; }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
