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

namespace SportingEventManager.Coaches
{
    public class CoachListViewModel : BindableBase
    {
        //private ICoachesRepository _repo = new CoachesRepository();
        private ICoachesRepository _repo;

        //public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public CoachListViewModel(ICoachesRepository repo)
        {
            _repo = repo;
            //if (DesignerProperties.GetIsInDesignMode(
            //	new System.Windows.DependencyObject())) return;

            //Coaches = new ObservableCollection<Coach>(_repo.GetCoachesAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        
            AddCoachCommand = new RelayCommand(OnAddCoach);
            EditCoachCommand = new RelayCommand<Coach>(OnEditCoach);
            ClearSearchCommand = new RelayCommand(OnClearSearch);

        }

        private ObservableCollection<Coach> _coaches;

        public ObservableCollection<Coach> Coaches
        {
            get { return _coaches; }
            set { SetProperty(ref _coaches, value); }
        }

        private Coach _selectedCoach;

        public Coach SelectedCoach
        {
            get { return _selectedCoach; }

            set
            {
                if (_selectedCoach != value)
                {
                    //_selectedCoach = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    ChangeCommand.RaiseCanExecuteChanged();
                    SetProperty(ref _selectedCoach, value);
                    //PropertyChanged(this, new PropertyChangedEventArgs("SelectedCoach"));
                }
            }
        }

        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ChangeCommand { get; set; }
        public RelayCommand AddCoachCommand { get; private set; }
        public RelayCommand<Coach> EditCoachCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public async void LoadCoaches()
		{
			if (DesignerProperties.GetIsInDesignMode(
				new System.Windows.DependencyObject())) return;

            //Coaches = new ObservableCollection<Coach>(await _repo.GetCoachesAsync());
            _allCoaches = await _repo.GetCoachesAsync();
            Coaches = new ObservableCollection<Coach>(_allCoaches);
        }

		private bool CanDelete()
		{
			return SelectedCoach != null;
		}

        private bool CanChange()
        {
            return SelectedCoach != null;
        }

        private void OnDelete()
		{
			Coaches.Remove(SelectedCoach);
		}

        
        public event Action<Coach> AddCoachRequested = delegate { };

        private void OnAddCoach()
        {
            AddCoachRequested(new Coach {  });
        }

        public event Action<Coach> EditCoachRequested = delegate { };

        private void OnEditCoach(Coach coach)
        {
            EditCoachRequested(coach);
        }

       
        private void OnClearSearch()
        {
            SearchInput = null;
        }

        private string _searchInput;
        private List<Coach> _allCoaches;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterCoaches(_searchInput);
            }
        }

        private void FilterCoaches(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Coaches = new ObservableCollection<Coach>(_allCoaches);
                return;
            }
            else
            {
                Coaches = new ObservableCollection<Coach>(_allCoaches.Where(c => c.Name.ToLower().Contains(searchInput.ToLower())));
            }
        }
    }
}
