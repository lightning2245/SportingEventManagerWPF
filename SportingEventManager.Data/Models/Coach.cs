using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace SportingEventManager.Data
{	
	public class Coach
    {		
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id  { get; set; }
		
		[Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
		
		[Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string Name { get { return FirstName.ToString() + " to " + LastName.ToString(); } }

        [Required]
        [StringLength(75)]
        public string City { get; set; }
		
		[Required]
        [StringLength(75)]
        public string State { get; set; }

		[StringLength(75)]
		public string Street { get; set; }

		[Required]
		[StringLength(20)]

		public string Zip { get; set; }

		private ICollection<Location> _locations;
		public virtual ICollection<Location> Locations
		{
			get{ return this._locations ?? (this._locations = new HashSet<Location>());}
			set{this._locations = value;}
		}
		private ICollection<int?> _locationsIds;
		[Display(Name = "Locations")]
		public virtual ICollection<int?> LocationsIds
		{
			get{ return this._locationsIds ?? (this._locationsIds = new HashSet<int?>());}
			set{this._locationsIds = value;}
		}

		private ICollection<Sport> _sports;
		public virtual ICollection<Sport> Sports
		{
			get{return this._sports ?? (this._sports = new HashSet<Sport>());}
			set{this._sports = value;}
		}		
		private ICollection<int?> _sportsIds;
		[Display(Name = "Sports")]
		public virtual ICollection<int?> SportsIds
		{
			get{return this._sportsIds ?? (this._sportsIds = new HashSet<int?>());}
			set{this._sportsIds = value;}
		}
		
		private ICollection<Gender> _genders;
		public virtual ICollection<Gender> Genders
		{
			get{return this._genders ?? (this._genders = new HashSet<Gender>());}
			set{this._genders = value;}
		}
		private ICollection<int?> _gendersIds;
		[Display(Name = "Genders")]
		public virtual ICollection<int?> GendersIds
		{
			get{return this._gendersIds ?? (this._gendersIds = new HashSet<int?>());}
			set{this._gendersIds = value;}
		}

		private ICollection<AgeRange> _ageRanges;
		public virtual ICollection<AgeRange> AgeRanges
		{
			get{return this._ageRanges ?? (this._ageRanges = new HashSet<AgeRange>());}
			set{this._ageRanges = value;}
		}
		private ICollection<int?> _ageRangesIds;
		[Display(Name = "Age Ranges")]
		public virtual ICollection<int?> AgeRangesIds
		{
			get{return this._ageRangesIds ?? (this._ageRangesIds = new HashSet<int?>());}
			set{this._ageRangesIds = value;}
		}

		private ICollection<Schedule> _schedules;
		public virtual ICollection<Schedule> Schedules
		{
			get{return this._schedules ?? (this._schedules = new HashSet<Schedule>());}
			set{this._schedules = value;}
		}
		private ICollection<int?> _schedulesIds;
		[Display(Name = "Schedules")]
		public virtual ICollection<int?> SchedulesIds
		{
			get{return this._schedulesIds ?? (this._schedulesIds = new HashSet<int?>());}
			set{this._schedulesIds = value;}
		}

		private ICollection<SportsEvent> _sportsEvents;
		public virtual ICollection<SportsEvent> SportsEvents
		{
			get{return this._sportsEvents ?? (this._sportsEvents = new HashSet<SportsEvent>());}
			set{this._sportsEvents = value;}
		}
		private ICollection<int?> _sportsEventsIds;
		[Display(Name = "Sports Events")]
		public virtual ICollection<int?> SportsEventsIds
		{
			get{return this._sportsEventsIds ?? (this._sportsEventsIds = new HashSet<int?>());}
			set{this._sportsEventsIds = value;}
		}

		//[Display(Name = "Locations")]
		//public ICollection<int?> LocationsIds { get; set; }
		////public virtual ICollection<Location> Locations { get; set; }

		//[Display(Name = "Sports")]
		//public ICollection<int?> SportsIds { get; set; }
		////public virtual ICollection<Sport> Sports { get; set; }

		//[Display(Name = "Genders")]
		//public ICollection<int?> GendersIds { get; set; }
		////public virtual ICollection<Gender> Genders { get; set; }

		//[Display(Name = "Age Ranges")]
		//public ICollection<int?> AgeRangesIds { get; set; }
		////public virtual ICollection<AgeRange> AgeRanges { get; set; }

		//[Display(Name = "Schedules")]
		//public ICollection<int?> SchedulesIds { get; set; }
		////public virtual ICollection<Schedule> Schedules { get; set; }

		//[Display(Name = "Sports Events")]
		//public ICollection<int?> SportsEventsIds { get; set; }
		////public virtual ICollection<SportsEvent> SportsEvents { get; set; }
        

    }
}