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

namespace SportingEventManager.Sports
{
    public class SportListViewModel : BindableBase
    {
        //private ISportsRepository _repo = new SportsRepository();
        private ISportsRepository _repo;

        //public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public SportListViewModel(ISportsRepository repo)
        {
            _repo = repo;
            //if (DesignerProperties.GetIsInDesignMode(
            //	new System.Windows.DependencyObject())) return;

            //Sports = new ObservableCollection<Sport>(_repo.GetSportsAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        
            AddSportCommand = new RelayCommand(OnAddSport);
            EditSportCommand = new RelayCommand<Sport>(OnEditSport);
            ClearSearchCommand = new RelayCommand(OnClearSearch);

        }

        private ObservableCollection<Sport> _sports;

        public ObservableCollection<Sport> Sports
        {
            get { return _sports; }
            set { SetProperty(ref _sports, value); }
        }

        private Sport _selectedSport;

        public Sport SelectedSport
        {
            get { return _selectedSport; }

            set
            {
                if (_selectedSport != value)
                {
                    //_selectedSport = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    ChangeCommand.RaiseCanExecuteChanged();
                    SetProperty(ref _selectedSport, value);
                    //PropertyChanged(this, new PropertyChangedEventArgs("SelectedSport"));
                }
            }
        }

        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ChangeCommand { get; set; }
        public RelayCommand AddSportCommand { get; private set; }
        public RelayCommand<Sport> EditSportCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public async void LoadSports()
		{
			if (DesignerProperties.GetIsInDesignMode(
				new System.Windows.DependencyObject())) return;

            //Sports = new ObservableCollection<Sport>(await _repo.GetSportsAsync());
            _allSports = await _repo.GetSportsAsync();
            Sports = new ObservableCollection<Sport>(_allSports);
        }

		private bool CanDelete()
		{
			return SelectedSport != null;
		}

        private bool CanChange()
        {
            return SelectedSport != null;
        }

        private void OnDelete()
		{
			Sports.Remove(SelectedSport);
		}

        
        public event Action<Sport> AddSportRequested = delegate { };

        private void OnAddSport()
        {
            AddSportRequested(new Sport {  });
        }

        public event Action<Sport> EditSportRequested = delegate { };

        private void OnEditSport(Sport sport)
        {
            EditSportRequested(sport);
        }

       
        private void OnClearSearch()
        {
            SearchInput = null;
        }

        private string _searchInput;
        private List<Sport> _allSports;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterSports(_searchInput);
            }
        }

        private void FilterSports(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Sports = new ObservableCollection<Sport>(_allSports);
                return;
            }
            else
            {
                Sports = new ObservableCollection<Sport>(_allSports.Where(c => c.Name.ToLower().Contains(searchInput.ToLower())));
            }
        }
    }
}
