using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SportingEventManager.Data
{	
	public class SportsEvent
    {		
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		 public int Id  { get; set; }

        [Required]
        [StringLength(255)]
         public string Name { get; set; }

		[Display(Name = "Age Range")]
		[ForeignKey("AgeRange"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? AgeRangeId { get; set; }
		public virtual AgeRange AgeRange { get; set; }


		[Display(Name = "Gender")]
		[ForeignKey("Gender"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? GenderId { get; set; }
		//private Gender _gender;
		public virtual Gender Gender { get; set; }
		

		[Display(Name = "Gender")]
		public string GenderName
		{
			get	{ return Gender == null ? "" : Gender.Name;}
		}		

		[Display(Name = "Location")]
		[ForeignKey("Location"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? LocationId { get; set; }
		//private Location _location;
		public virtual Location Location { get; set; }
		//{
		//	get { return this._location ?? (this._location = new Location()); }
		//	set { this._location = value; }
		//}
				


		[Display(Name = "Location")]
		public string LocationName
		{
			get { return Location == null ? "" : Location.Name; }
		}

		[Display(Name = "Address")]
		public string Address
		{
			get { return Location.City + ", " + Location.State + " " + Location.Street == null ? "" : Location.Street + " " + Location.Zip; }
		}

		[Display(Name = "Organizer")]
		[ForeignKey("Organizer"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? OrganizerId { get; set; }


		//private Organizer _organizer;
		public virtual Organizer Organizer { get; set; }
		//{
		//	get { return this._organizer ?? (this._organizer = new Organizer()); }
		//	set { this._organizer = value; }
		//}

		//[Display(Name = "Organizer")]
		//public string OrganizerName
		//{
		//	get { return Organizer == null ? "" : Organizer.Name;	}
		//}

		//private ICollection<Coach> _coaches;
		public virtual ICollection<Coach> Coaches { get; set; }
		//{
		//	get { return this._coaches ?? (this._coaches = new HashSet<Coach>()); }
		//	set { this._coaches = value; }
		//}
		private ICollection<int?> _coachesIds;
		[Display(Name = "Coaches")]
		public virtual ICollection<int?> CoachesIds
		{
			get { return this._coachesIds ?? (this._coachesIds = new HashSet<int?>()); }
			set { this._coachesIds = value; }
		}

		private ICollection<Player> _players;
		public virtual ICollection<Player> Players
		{
			get { return this._players ?? (this._players = new HashSet<Player>()); }
			set { this._players = value; }
		}
		private ICollection<int?> _playersIds;
		[Display(Name = "Players")]
		public virtual ICollection<int?> PlayersIds
		{
			get { return this._playersIds ?? (this._playersIds = new HashSet<int?>()); }
			set { this._playersIds = value; }
		}

		[Display(Name = "Schedule")]
		[ForeignKey("Schedule"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? ScheduleId { get; set; }
		//private Schedule _schedule;
		public virtual Schedule Schedule { get; set; }
		//{
		//	get { return this._schedule ?? (this._schedule = new Schedule()); }
		//	set { this._schedule = value; }
		//}

		[Display(Name = "Schedule")]
		public string ScheduleName
		{
			get	{ return Schedule == null ? "" : Schedule.Name; }
		}

		[Display(Name = "Sport")]
		[ForeignKey("Sport"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? SportId { get; set; }
		//private Sport _sport;
		public virtual Sport Sport { get; set; }
		//{
		//	get { return this._sport ?? (this._sport = new Sport()); }
		//	set { this._sport = value; }
		//}

		[Display(Name = "Sport")]
		public string SportName
		{
			get	{ return Sport == null ? "" : Sport.Name; }
		}
	}
}