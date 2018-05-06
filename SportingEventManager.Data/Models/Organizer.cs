using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SportingEventManager.Data
{	
	public class Organizer
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