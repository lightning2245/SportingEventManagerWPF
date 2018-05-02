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

namespace SportingEventManager.SportsEvents
{
    public class SportsEventListViewModel : BindableBase
    {
        //private ISportsEventsRepository _repo = new SportsEventsRepository();
        private ISportsEventsRepository _repo;

        //public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public SportsEventListViewModel(ISportsEventsRepository repo)
        {
            _repo = repo;
            //if (DesignerProperties.GetIsInDesignMode(
            //	new System.Windows.DependencyObject())) return;

            //SportsEvents = new ObservableCollection<SportsEvent>(_repo.GetSportsEventsAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        
            AddSportsEventCommand = new RelayCommand(OnAddSportsEvent);
            EditSportsEventCommand = new RelayCommand<SportsEvent>(OnEditSportsEvent);
            ClearSearchCommand = new RelayCommand(OnClearSearch);

        }

        private ObservableCollection<SportsEvent> _sportsEvents;

        public ObservableCollection<SportsEvent> SportsEvents
        {
            get { return _sportsEvents; }
            set { SetProperty(ref _sportsEvents, value); }
        }

        private SportsEvent _selectedSportsEvent;

        public SportsEvent SelectedSportsEvent
        {
            get { return _selectedSportsEvent; }

            set
            {
                if (_selectedSportsEvent != value)
                {
                    //_selectedSportsEvent = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    ChangeCommand.RaiseCanExecuteChanged();
                    SetProperty(ref _selectedSportsEvent, value);
                    //PropertyChanged(this, new PropertyChangedEventArgs("SelectedSportsEvent"));
                }
            }
        }

        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ChangeCommand { get; set; }
        public RelayCommand AddSportsEventCommand { get; private set; }
        public RelayCommand<SportsEvent> EditSportsEventCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public async void LoadSportsEvents()
		{
			if (DesignerProperties.GetIsInDesignMode(
				new System.Windows.DependencyObject())) return;

            //SportsEvents = new ObservableCollection<SportsEvent>(await _repo.GetSportsEventsAsync());
            _allSportsEvents = await _repo.GetSportsEventsAsync();
            SportsEvents = new ObservableCollection<SportsEvent>(_allSportsEvents);
        }

		private bool CanDelete()
		{
			return SelectedSportsEvent != null;
		}

        private bool CanChange()
        {
            return SelectedSportsEvent != null;
        }

        private void OnDelete()
		{
			SportsEvents.Remove(SelectedSportsEvent);
		}

        
        public event Action<SportsEvent> AddSportsEventRequested = delegate { };

        private void OnAddSportsEvent()
        {
            AddSportsEventRequested(new SportsEvent {  });
        }

        public event Action<SportsEvent> EditSportsEventRequested = delegate { };

        private void OnEditSportsEvent(SportsEvent sportsEvent)
        {
            EditSportsEventRequested(sportsEvent);
        }

       
        private void OnClearSearch()
        {
            SearchInput = null;
        }

        private string _searchInput;
        private List<SportsEvent> _allSportsEvents;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterSportsEvents(_searchInput);
            }
        }

        private void FilterSportsEvents(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                SportsEvents = new ObservableCollection<SportsEvent>(_allSportsEvents);
                return;
            }
            else
            {
                SportsEvents = new ObservableCollection<SportsEvent>(_allSportsEvents.Where(c => c.Name.ToLower().Contains(searchInput.ToLower())));
            }
        }
    }
}
