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

namespace SportingEventManager.Organizers
{
    public class OrganizerListViewModel : BindableBase
    {
        //private IOrganizersRepository _repo = new OrganizersRepository();
        private IOrganizersRepository _repo;

        //public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public OrganizerListViewModel(IOrganizersRepository repo)
        {
            _repo = repo;
            //if (DesignerProperties.GetIsInDesignMode(
            //	new System.Windows.DependencyObject())) return;

            //Organizers = new ObservableCollection<Organizer>(_repo.GetOrganizersAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        
            AddOrganizerCommand = new RelayCommand(OnAddOrganizer);
            EditOrganizerCommand = new RelayCommand<Organizer>(OnEditOrganizer);
            ClearSearchCommand = new RelayCommand(OnClearSearch);

        }

        private ObservableCollection<Organizer> _organizers;

        public ObservableCollection<Organizer> Organizers
        {
            get { return _organizers; }
            set { SetProperty(ref _organizers, value); }
        }

        private Organizer _selectedOrganizer;

        public Organizer SelectedOrganizer
        {
            get { return _selectedOrganizer; }

            set
            {
                if (_selectedOrganizer != value)
                {
                    //_selectedOrganizer = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    ChangeCommand.RaiseCanExecuteChanged();
                    SetProperty(ref _selectedOrganizer, value);
                    //PropertyChanged(this, new PropertyChangedEventArgs("SelectedOrganizer"));
                }
            }
        }

        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ChangeCommand { get; set; }
        public RelayCommand AddOrganizerCommand { get; private set; }
        public RelayCommand<Organizer> EditOrganizerCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public async void LoadOrganizers()
		{
			if (DesignerProperties.GetIsInDesignMode(
				new System.Windows.DependencyObject())) return;

            //Organizers = new ObservableCollection<Organizer>(await _repo.GetOrganizersAsync());
            _allOrganizers = await _repo.GetOrganizersAsync();
            Organizers = new ObservableCollection<Organizer>(_allOrganizers);
        }

		private bool CanDelete()
		{
			return SelectedOrganizer != null;
		}

        private bool CanChange()
        {
            return SelectedOrganizer != null;
        }

        private void OnDelete()
		{
			Organizers.Remove(SelectedOrganizer);
		}

        
        public event Action<Organizer> AddOrganizerRequested = delegate { };

        private void OnAddOrganizer()
        {
            AddOrganizerRequested(new Organizer {  });
        }

        public event Action<Organizer> EditOrganizerRequested = delegate { };

        private void OnEditOrganizer(Organizer organizer)
        {
            EditOrganizerRequested(organizer);
        }

       
        private void OnClearSearch()
        {
            SearchInput = null;
        }

        private string _searchInput;
        private List<Organizer> _allOrganizers;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterOrganizers(_searchInput);
            }
        }

        private void FilterOrganizers(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Organizers = new ObservableCollection<Organizer>(_allOrganizers);
                return;
            }
            else
            {
                Organizers = new ObservableCollection<Organizer>(_allOrganizers.Where(c => c.Name.ToLower().Contains(searchInput.ToLower())));
            }
        }
    }
}
