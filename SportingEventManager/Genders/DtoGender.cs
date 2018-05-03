using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Genders
{
    public class DtoGender : ValidatableBindableBase
    {
        
        public int Id { get; set; }
        public int? StoreId { get; set; }

        private string _name;

        [Required]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

    }
}
