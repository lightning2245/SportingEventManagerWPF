﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;
using SportingEventManager.Genders;

namespace SportingEventManager.Players
{
    public class DtoPlayer : ValidatableBindableBase
    {
        public DtoPlayer()
        {
           
        }
       
        public int Id { get; set; }
        public int? StoreId { get; set; }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        public string Name
        {
            get { return FirstName + " " + LastName; }
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
        
        public int? GenderId { get; set; }
        public virtual DtoGender Gender { get; set; }

        [Display(Name = "Gender")]
        public string GenderName
        {
            get { return Gender == null ? "" : Gender.Name; }
        }

        private string _birthDate;
        public string BirthDate
        {
            get { return _birthDate; }
            set { SetProperty(ref _birthDate, value); }
        }
    }
}
