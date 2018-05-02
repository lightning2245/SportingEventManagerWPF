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

namespace SportingEventManager.Genders
{
    public class GenderListViewModel : BindableBase
    {
        //private IGendersRepository _repo = new GendersRepository();
        private IGendersRepository _repo;

        //public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public GenderListViewModel(IGendersRepository repo)
        {
            _repo = repo;
            //if (DesignerProperties.GetIsInDesignMode(
            //	new System.Windows.DependencyObject())) return;

            //Genders = new ObservableCollection<Gender>(_repo.GetGendersAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        
            AddGenderCommand = new RelayCommand(OnAddGender);
            EditGenderCommand = new RelayCommand<Gender>(OnEditGender);
            ClearSearchCommand = new RelayCommand(OnClearSearch);

        }

        private ObservableCollection<Gender> _genders;

        public ObservableCollection<Gender> Genders
        {
            get { return _genders; }
            set { SetProperty(ref _genders, value); }
        }

        private Gender _selectedGender;

        public Gender SelectedGender
        {
            get { return _selectedGender; }

            set
            {
                if (_selectedGender != value)
                {
                    //_selectedGender = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    ChangeCommand.RaiseCanExecuteChanged();
                    SetProperty(ref _selectedGender, value);
                    //PropertyChanged(this, new PropertyChangedEventArgs("SelectedGender"));
                }
            }
        }

        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ChangeCommand { get; set; }
        public RelayCommand AddGenderCommand { get; private set; }
        public RelayCommand<Gender> EditGenderCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public async void LoadGenders()
		{
			if (DesignerProperties.GetIsInDesignMode(
				new System.Windows.DependencyObject())) return;

            //Genders = new ObservableCollection<Gender>(await _repo.GetGendersAsync());
            _allGenders = await _repo.GetGendersAsync();
            Genders = new ObservableCollection<Gender>(_allGenders);
        }

		private bool CanDelete()
		{
			return SelectedGender != null;
		}

        private bool CanChange()
        {
            return SelectedGender != null;
        }

        private void OnDelete()
		{
			Genders.Remove(SelectedGender);
		}

        
        public event Action<Gender> AddGenderRequested = delegate { };

        private void OnAddGender()
        {
            AddGenderRequested(new Gender {  });
        }

        public event Action<Gender> EditGenderRequested = delegate { };

        private void OnEditGender(Gender gender)
        {
            EditGenderRequested(gender);
        }

       
        private void OnClearSearch()
        {
            SearchInput = null;
        }

        private string _searchInput;
        private List<Gender> _allGenders;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterGenders(_searchInput);
            }
        }

        private void FilterGenders(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Genders = new ObservableCollection<Gender>(_allGenders);
                return;
            }
            else
            {
                Genders = new ObservableCollection<Gender>(_allGenders.Where(c => c.Name.ToLower().Contains(searchInput.ToLower())));
            }
        }
    }
}
