using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SportingEventManager.Data;

namespace SportingEventManager.Locations
{
    public class LocationListViewModel : BindableBase
    {
        //private ILocationsRepository _repo = new LocationsRepository();
        private ILocationsRepository _repo;

        //public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public LocationListViewModel(ILocationsRepository repo)
        {
            _repo = repo;
            //if (DesignerProperties.GetIsInDesignMode(
            //	new System.Windows.DependencyObject())) return;

            //Locations = new ObservableCollection<Location>(_repo.GetLocationsAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        
            AddLocationCommand = new RelayCommand(OnAddLocation);
            EditLocationCommand = new RelayCommand<Location>(OnEditLocation);
            ClearSearchCommand = new RelayCommand(OnClearSearch);

        }

        private ObservableCollection<Location> _locations;

        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set { SetProperty(ref _locations, value); }
        }

        private Location _selectedLocation;

        public Location SelectedLocation
        {
            get { return _selectedLocation; }

            set
            {
                if (_selectedLocation != value)
                {
                    //_selectedLocation = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    ChangeCommand.RaiseCanExecuteChanged();
                    SetProperty(ref _selectedLocation, value);
                    //PropertyChanged(this, new PropertyChangedEventArgs("SelectedLocation"));
                }
            }
        }

        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ChangeCommand { get; set; }
        public RelayCommand AddLocationCommand { get; private set; }
        public RelayCommand<Location> EditLocationCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public async void LoadLocations()
		{
			if (DesignerProperties.GetIsInDesignMode(
				new System.Windows.DependencyObject())) return;

            //Locations = new ObservableCollection<Location>(await _repo.GetLocationsAsync());
            _allLocations = await _repo.GetLocationsAsync();
            Locations = new ObservableCollection<Location>(_allLocations);
        }

		private bool CanDelete()
		{
			return SelectedLocation != null;
		}

        private bool CanChange()
        {
            return SelectedLocation != null;
        }

        private void OnDelete()
		{
			Locations.Remove(SelectedLocation);
		}

        
        public event Action<Location> AddLocationRequested = delegate { };

        private void OnAddLocation()
        {
            AddLocationRequested(new Location {  });
        }

        public event Action<Location> EditLocationRequested = delegate { };

        private void OnEditLocation(Location location)
        {
            EditLocationRequested(location);
        }

       
        private void OnClearSearch()
        {
            SearchInput = null;
        }

        private string _searchInput;
        private List<Location> _allLocations;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterLocations(_searchInput);
            }
        }

        private void FilterLocations(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Locations = new ObservableCollection<Location>(_allLocations);
                return;
            }
            else
            {
                Locations = new ObservableCollection<Location>(_allLocations.Where(c => c.Name.ToLower().Contains(searchInput.ToLower())));
            }
        }
    }
}
