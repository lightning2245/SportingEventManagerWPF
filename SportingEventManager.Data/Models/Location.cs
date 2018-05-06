using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportingEventManager.Data
{	
	public class Location
    {		
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id  { get; set; }
		
		[Required]
        [StringLength(75)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [StringLength(75)]
        public string State { get; set; }
		
		[Required]
		[StringLength(75)]
		public string Street { get; set; }
        	
		
		[Required]
        [StringLength(75)]
        public string Zip { get; set; }
		
		[Required]
        [StringLength(75)]
        public string Name { get; set; }

		
		private ICollection<Coach> _coaches;
		public virtual ICollection<Coach> Coaches
		{
			get { return this._coaches ?? (this._coaches = new HashSet<Coach>()); }
			set { this._coaches = value; }
		}
		private ICollection<int?> _coachesIds;
		[Display(Name = "Coaches")]
		public virtual ICollection<int?> CoachesIds
		{
			get { return this._coachesIds ?? (this._coachesIds = new HashSet<int?>()); }
			set { this._coachesIds = value; }
		}


		private ICollection<SportsEvent> _sportsEvents;
		public virtual ICollection<SportsEvent> SportsEvents
		{
			get { return this._sportsEvents ?? (this._sportsEvents = new HashSet<SportsEvent>()); }
			set { this._sportsEvents = value; }
		}
		private ICollection<int?> _sportsEventsIds;
		[Display(Name = "Sports Events")]
		public virtual ICollection<int?> SportsEventsIds
		{
			get { return this._sportsEventsIds ?? (this._sportsEventsIds = new HashSet<int?>()); }
			set { this._sportsEventsIds = value; }
		}

	}
}