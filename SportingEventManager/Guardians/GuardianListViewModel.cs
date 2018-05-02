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

namespace SportingEventManager.Guardians
{
    public class GuardianListViewModel : BindableBase
    {
        //private IGuardiansRepository _repo = new GuardiansRepository();
        private IGuardiansRepository _repo;

        //public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public GuardianListViewModel(IGuardiansRepository repo)
        {
            _repo = repo;
            //if (DesignerProperties.GetIsInDesignMode(
            //	new System.Windows.DependencyObject())) return;

            //Guardians = new ObservableCollection<Guardian>(_repo.GetGuardiansAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        
            AddGuardianCommand = new RelayCommand(OnAddGuardian);
            EditGuardianCommand = new RelayCommand<Guardian>(OnEditGuardian);
            ClearSearchCommand = new RelayCommand(OnClearSearch);

        }

        private ObservableCollection<Guardian> _guardians;

        public ObservableCollection<Guardian> Guardians
        {
            get { return _guardians; }
            set { SetProperty(ref _guardians, value); }
        }

        private Guardian _selectedGuardian;

        public Guardian SelectedGuardian
        {
            get { return _selectedGuardian; }

            set
            {
                if (_selectedGuardian != value)
                {
                    //_selectedGuardian = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    ChangeCommand.RaiseCanExecuteChanged();
                    SetProperty(ref _selectedGuardian, value);
                    //PropertyChanged(this, new PropertyChangedEventArgs("SelectedGuardian"));
                }
            }
        }

        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ChangeCommand { get; set; }
        public RelayCommand AddGuardianCommand { get; private set; }
        public RelayCommand<Guardian> EditGuardianCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public async void LoadGuardians()
		{
			if (DesignerProperties.GetIsInDesignMode(
				new System.Windows.DependencyObject())) return;

            //Guardians = new ObservableCollection<Guardian>(await _repo.GetGuardiansAsync());
            _allGuardians = await _repo.GetGuardiansAsync();
            Guardians = new ObservableCollection<Guardian>(_allGuardians);
        }

		private bool CanDelete()
		{
			return SelectedGuardian != null;
		}

        private bool CanChange()
        {
            return SelectedGuardian != null;
        }

        private void OnDelete()
		{
			Guardians.Remove(SelectedGuardian);
		}

        
        public event Action<Guardian> AddGuardianRequested = delegate { };

        private void OnAddGuardian()
        {
            AddGuardianRequested(new Guardian {  });
        }

        public event Action<Guardian> EditGuardianRequested = delegate { };

        private void OnEditGuardian(Guardian guardian)
        {
            EditGuardianRequested(guardian);
        }

       
        private void OnClearSearch()
        {
            SearchInput = null;
        }

        private string _searchInput;
        private List<Guardian> _allGuardians;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterGuardians(_searchInput);
            }
        }

        private void FilterGuardians(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Guardians = new ObservableCollection<Guardian>(_allGuardians);
                return;
            }
            else
            {
                Guardians = new ObservableCollection<Guardian>(_allGuardians.Where(c => c.Name.ToLower().Contains(searchInput.ToLower())));
            }
        }
    }
}
