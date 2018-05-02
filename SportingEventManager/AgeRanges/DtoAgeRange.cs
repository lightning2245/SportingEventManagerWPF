using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.AgeRanges
{
    public class DtoAgeRange : ValidatableBindableBase
    {
        public DtoAgeRange()
        {
           
        }
       
        public int Id { get; set; }
        public int? StoreId { get; set; }
       
        private int? _min;

        [Required]
        public int? Min
        {
            get { return _min; }
            set { SetProperty(ref _min, value); }
        }

        private int? _max;

        [Required]
        public int? Max
        {
            get { return _max; }
            set { SetProperty(ref _max, value); }
        }

        public string Name { get { return Min + " " + Max; } }       
    }
}
