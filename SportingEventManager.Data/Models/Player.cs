using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SportingEventManager.Data
{	
	public class Player
    {		
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
		public int Id { get; set; }

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

        [Display(Name = "Gender")]
		[ForeignKey("Gender"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? GenderId { get; set; }
		//private Gender _gender;
		public virtual Gender Gender { get; set; }
		

		[Display(Name = "Gender")]
		public string GenderName
		{
			get{ return Gender == null ? "" : Gender.Name; }
		}

		[Required]
        [Display(Name = "Date of Birth")]		
		public DateTime? Birthdate { get; set; }

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


		private ICollection<Guardian> _guardians;
		public virtual ICollection<Guardian> Guardians
		{
			get { return this._guardians ?? (this._guardians = new HashSet<Guardian>()); }
			set { this._guardians = value; }
		}
		private ICollection<int?> _guardiansIds;
		[Display(Name = "Guardians")]
		public virtual ICollection<int?> GuardiansIds
		{
			get { return this._guardiansIds ?? (this._guardiansIds = new HashSet<int?>()); }
			set { this._guardiansIds = value; }
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