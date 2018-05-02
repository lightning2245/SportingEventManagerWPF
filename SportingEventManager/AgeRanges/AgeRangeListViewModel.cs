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

namespace SportingEventManager.AgeRanges
{
    public class AgeRangeListViewModel : BindableBase
    {
        //private IAgeRangesRepository _repo = new AgeRangesRepository();
        private IAgeRangesRepository _repo;

        //public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public AgeRangeListViewModel(IAgeRangesRepository repo)
        {
            _repo = repo;
            //if (DesignerProperties.GetIsInDesignMode(
            //	new System.Windows.DependencyObject())) return;

            //AgeRanges = new ObservableCollection<AgeRange>(_repo.GetAgeRangesAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        
            AddAgeRangeCommand = new RelayCommand(OnAddAgeRange);
            EditAgeRangeCommand = new RelayCommand<AgeRange>(OnEditAgeRange);
            ClearSearchCommand = new RelayCommand(OnClearSearch);

        }

        private ObservableCollection<AgeRange> _ageRanges;

        public ObservableCollection<AgeRange> AgeRanges
        {
            get { return _ageRanges; }
            set { SetProperty(ref _ageRanges, value); }
        }

        private AgeRange _selectedAgeRange;

        public AgeRange SelectedAgeRange
        {
            get { return _selectedAgeRange; }

            set
            {
                if (_selectedAgeRange != value)
                {
                    //_selectedAgeRange = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    ChangeCommand.RaiseCanExecuteChanged();
                    SetProperty(ref _selectedAgeRange, value);
                    //PropertyChanged(this, new PropertyChangedEventArgs("SelectedAgeRange"));
                }
            }
        }

        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ChangeCommand { get; set; }
        public RelayCommand AddAgeRangeCommand { get; private set; }
        public RelayCommand<AgeRange> EditAgeRangeCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public async void LoadAgeRanges()
		{
			if (DesignerProperties.GetIsInDesignMode(
				new System.Windows.DependencyObject())) return;

            //AgeRanges = new ObservableCollection<AgeRange>(await _repo.GetAgeRangesAsync());
            _allAgeRanges = await _repo.GetAgeRangesAsync();
            AgeRanges = new ObservableCollection<AgeRange>(_allAgeRanges);
        }

		private bool CanDelete()
		{
			return SelectedAgeRange != null;
		}

        private bool CanChange()
        {
            return SelectedAgeRange != null;
        }

        private void OnDelete()
		{
			AgeRanges.Remove(SelectedAgeRange);
		}

        
        public event Action<AgeRange> AddAgeRangeRequested = delegate { };

        private void OnAddAgeRange()
        {
            AddAgeRangeRequested(new AgeRange {  });
        }

        public event Action<AgeRange> EditAgeRangeRequested = delegate { };

        private void OnEditAgeRange(AgeRange ageRange)
        {
            EditAgeRangeRequested(ageRange);
        }

       
        private void OnClearSearch()
        {
            SearchInput = null;
        }

        private string _searchInput;
        private List<AgeRange> _allAgeRanges;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterAgeRanges(_searchInput);
            }
        }

        private void FilterAgeRanges(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                AgeRanges = new ObservableCollection<AgeRange>(_allAgeRanges);
                return;
            }
            else
            {
                AgeRanges = new ObservableCollection<AgeRange>(_allAgeRanges.Where(c => c.Name.ToLower().Contains(searchInput.ToLower())));
            }
        }
    }
}
