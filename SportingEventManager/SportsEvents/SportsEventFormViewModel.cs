using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.SportsEvents
{
    class SportsEventFormViewModel : BindableBase
    {
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private ISportsEventsRepository _repo;

        public SportsEventFormViewModel(ISportsEventsRepository repo)
        {
            _repo = repo;
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }        

        private bool _editMode;

        public bool EditMode
        {
            get { return _editMode; }
            set { SetProperty(ref _editMode, value); }
        }

        private DtoSportsEvent _sportsEvent;

        public DtoSportsEvent SportsEvent
        {
            get { return _sportsEvent;  }
            set { SetProperty(ref _sportsEvent, value); }
        }

        private SportsEvent _editingSportsEvent = null;

        public void SetSportsEvent(SportsEvent ar)
        {
            _editingSportsEvent = ar;
            if (SportsEvent != null) SportsEvent.ErrorsChanged -= RaiseCanExecuteChanged;
            SportsEvent = new DtoSportsEvent();
            SportsEvent.ErrorsChanged += RaiseCanExecuteChanged;
            CopySportsEvent(ar, SportsEvent);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopySportsEvent(SportsEvent source, DtoSportsEvent target)
        {
            target.Id = source.Id;

            if(EditMode)
            {
                source.Gender = target.Gender;
                source.GenderId = target.GenderId;
                source.Location = target.Location;
                source.LocationId = target.LocationId;
                source.Organizer = target.Organizer;
                source.OrganizerId = target.OrganizerId;
                source.Schedule = target.Schedule;
                source.ScheduleId = target.ScheduleId;
                source.Sport = target.Sport;
                source.SportId = target.SportId;
                
                
            }
        }

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            UpdateSportsEvent(SportsEvent, _editingSportsEvent);
            if (EditMode) { await _repo.UpdateSportsEventAsync(_editingSportsEvent); }
            else { await _repo.AddSportsEventAsync(_editingSportsEvent); }

            Done();
        }

        private void UpdateSportsEvent(DtoSportsEvent source, SportsEvent target)
        {
            source.Gender = target.Gender;

            source.Gender = target.Gender;
            source.GenderId = target.GenderId;
            source.Location = target.Location;
            source.LocationId = target.LocationId;
            source.Organizer = target.Organizer;
            source.OrganizerId = target.OrganizerId;
            source.Schedule = target.Schedule;
            source.ScheduleId = target.ScheduleId;
            source.Sport = target.Sport;
            source.SportId = target.SportId;

        }

        private bool CanSave()
        {
            return !SportsEvent.HasErrors;
        }
    }
}
