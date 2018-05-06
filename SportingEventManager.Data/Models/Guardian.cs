using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SportingEventManager.Data
{
	
	
	public class Guardian
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

		//[StringLength(75)]
		//public string Street { get; set; }
		
		[Required]
        [StringLength(20)]
        public string Zip { get; set; }

		[StringLength(75)]
		public string Street { get; set; }

        //[StringLength(75)]
        //public string Street
        //{
        //	get
        //	{
        //		return Street == null ? "" : Street;
        //	}
        //	set { Street = value; }
        //}

        //[Display(Name = "Address")]
        //public string Address
        //{
        //	get{ return City + ", " + State + " " + Street == null ? "" : Street + " " + Zip; }
        //}

        private ICollection<int?> _playersIds;
        [Display(Name = "Players")]
        public virtual ICollection<int?> PlayersIds
        {
            get { return this._playersIds ?? (this._playersIds = new HashSet<int?>()); }
            set { this._playersIds = value; }
        }
        private ICollection<Player> _players;
		public virtual ICollection<Player> Players
		{
			get { return this._players ?? (this._players = new HashSet<Player>()); }
			set { this._players = value; }
		}
		

	}
}