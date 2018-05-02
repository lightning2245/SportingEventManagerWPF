using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Locations
{
    public class DtoLocation : ValidatableBindableBase
    {
        public int Id { get; set; }
        public int? StoreId { get; set; }

        public DtoLocation()
        {
           
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        private string _state;
        public string State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        private string _zip;
        public string Zip
        {
            get { return _zip; }
            set { SetProperty(ref _zip, value); }
        }

        private string _street;
        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }
    }
}
