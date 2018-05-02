using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Locations
{
    class LocationFormViewModel : BindableBase
    {
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private ILocationsRepository _repo;

        public LocationFormViewModel(ILocationsRepository repo)
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

        private DtoLocation _location;

        public DtoLocation Location
        {
            get { return _location;  }
            set { SetProperty(ref _location, value); }
        }

        private Location _editingLocation = null;

        public void SetLocation(Location ar)
        {
            _editingLocation = ar;
            if (Location != null) Location.ErrorsChanged -= RaiseCanExecuteChanged;
            Location = new DtoLocation();
            Location.ErrorsChanged += RaiseCanExecuteChanged;
            CopyLocation(ar, Location);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyLocation(Location source, DtoLocation target)
        {
            target.Id = source.Id;

            if(EditMode)
            {
                target.Name = source.Name;                
                target.City = source.City;
                target.State = source.State;
                target.City = source.City;
                target.Street = source.Street;
            }
        }

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            UpdateLocation(Location, _editingLocation);
            if (EditMode) { await _repo.UpdateLocationAsync(_editingLocation); }
            else { await _repo.AddLocationAsync(_editingLocation); }

            Done();
        }

        private void UpdateLocation(DtoLocation source, Location target)
        {
            target.Name = source.Name;
            target.City = source.City;
            target.State = source.State;
            target.City = source.City;
            target.Street = source.Street;

        }

        private bool CanSave()
        {
            return !Location.HasErrors;
        }
    }
}
