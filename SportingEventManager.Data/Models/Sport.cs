using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SportingEventManager.Data
{	
	public class Sport
    {		
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		 public int Id  { get; set; }

        [Required]
        [StringLength(255)]
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

	}
}