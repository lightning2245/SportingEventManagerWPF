using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;
//using SportingEventManager.Genders;
//using SportingEventManager.Organizers;
//using SportingEventManager.Locations;
//using SportingEventManager.Sports;
//using SportingEventManager.Schedules;
using SportingEventManager.AgeRanges;

namespace SportingEventManager.SportsEvents
{
    public class DtoSportsEvent : ValidatableBindableBase
    {
        public DtoSportsEvent()
        {
           
        }
       
        public int Id { get; set; }
        public int? StoreId { get; set; }

        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }


        [Display(Name = "Gender")]
        public string GenderName
        {
            get { return Gender == null ? "" : Gender.Name; }
        }

        private Location _location;
        public Location Location
        {
            get { return _location; }
            set { SetProperty(ref _location, value); }
        }

        private int? _locationId;
        public int? LocationId
        {
            get { return _locationId; }
            set { SetProperty(ref _locationId, value); }
        }
        
        public string LocationName
        {
            get { return Location == null ? "" : Location.Name; }
        }
        
        public string LocationAddress
        {
            get { return Location == null ? "" : Location.City + ", " + Location.State + " " + Location.Street + " " + Location.Zip; }
        }

        private Organizer _organizer;
        public Organizer Organizer
        {
            get { return _organizer; }
            set { SetProperty(ref _organizer, value); }
        }

        private int? _organizerId;
        public int? OrganizerId
        {
            get { return _organizerId; }
            set { SetProperty(ref _organizerId, value); }
        }

        public string OrganizerName
        {
            get { return Organizer == null ? "" : Organizer.Name; }
        }


        private Schedule _schedule;
        public Schedule Schedule
        {
            get { return _schedule; }
            set { SetProperty(ref _schedule, value); }
        }

        private int? _scheduleId;
        public int? ScheduleId
        {
            get { return _scheduleId; }
            set { SetProperty(ref _scheduleId, value); }
        }

        public string ScheduleName
        {
            get { return Schedule == null ? "" : Schedule.Name; }
        }


        private Sport _sport;
        public Sport Sport
        {
            get { return _sport; }
            set { SetProperty(ref _sport, value); }
        }

        private int? _sportId;
        public int? SportId
        {
            get { return _sportId; }
            set { SetProperty(ref _sportId, value); }
        }

        public string SportName
        {
            get { return Sport == null ? "" : Sport.Name; }
        }
    }
}
