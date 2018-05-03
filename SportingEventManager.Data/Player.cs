using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Zza.Data
{
    public class Player :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Player()
        {
            //Orders = new List<Order>();
        }         

        [Key]
        public Guid Id { get; set; }
        public Guid? StoreId { get; set; }
        //public string FirstName { get; set; }
		private string _firstName;

		public string FirstName
		{
			get { return _firstName; }
			set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
                }
            }
		}

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
                }
            }
        }

        public string FullName { get { return FirstName + " " + LastName; } }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Phone"));
                }
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Email"));
                }
            }
        }

        private string _street;

        public string Street
        {
            get { return _street; }
            set
            {
                if (_street != value)
                {
                    _street = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Street"));
                }
            }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("City"));
                }
            }
        }

        private string _state;

        public string State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("State"));
                }
            }
        }

        private string _zip;

        public string Zip
        {
            get { return _zip; }
            set
            {
                if (_zip != value)
                {
                    _zip = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Zip"));
                }
            }
        }

        private List<Order> _orders;

        public List<Order> Orders
        {
            get { return _orders; }
            set
            {
                if (_orders != value)
                {
                    _orders = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Orders"));
                }
            }
        }

    }
}
