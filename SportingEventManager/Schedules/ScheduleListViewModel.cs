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

namespace SportingEventManager.Schedules
{
    public class ScheduleListViewModel : BindableBase
    {
        //private ISchedulesRepository _repo = new SchedulesRepository();
        private ISchedulesRepository _repo;

        //public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ScheduleListViewModel(ISchedulesRepository repo)
        {
            _repo = repo;
            //if (DesignerProperties.GetIsInDesignMode(
            //	new System.Windows.DependencyObject())) return;

            //Schedules = new ObservableCollection<Schedule>(_repo.GetSchedulesAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        
            AddScheduleCommand = new RelayCommand(OnAddSchedule);
            EditScheduleCommand = new RelayCommand<Schedule>(OnEditSchedule);
            ClearSearchCommand = new RelayCommand(OnClearSearch);

        }

        private ObservableCollection<Schedule> _schedules;

        public ObservableCollection<Schedule> Schedules
        {
            get { return _schedules; }
            set { SetProperty(ref _schedules, value); }
        }

        private Schedule _selectedSchedule;

        public Schedule SelectedSchedule
        {
            get { return _selectedSchedule; }

            set
            {
                if (_selectedSchedule != value)
                {
                    //_selectedSchedule = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    ChangeCommand.RaiseCanExecuteChanged();
                    SetProperty(ref _selectedSchedule, value);
                    //PropertyChanged(this, new PropertyChangedEventArgs("SelectedSchedule"));
                }
            }
        }

        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ChangeCommand { get; set; }
        public RelayCommand AddScheduleCommand { get; private set; }
        public RelayCommand<Schedule> EditScheduleCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public async void LoadSchedules()
		{
			if (DesignerProperties.GetIsInDesignMode(
				new System.Windows.DependencyObject())) return;

            //Schedules = new ObservableCollection<Schedule>(await _repo.GetSchedulesAsync());
            _allSchedules = await _repo.GetSchedulesAsync();
            Schedules = new ObservableCollection<Schedule>(_allSchedules);
        }

		private bool CanDelete()
		{
			return SelectedSchedule != null;
		}

        private bool CanChange()
        {
            return SelectedSchedule != null;
        }

        private void OnDelete()
		{
			Schedules.Remove(SelectedSchedule);
		}

        
        public event Action<Schedule> AddScheduleRequested = delegate { };

        private void OnAddSchedule()
        {
            AddScheduleRequested(new Schedule {  });
        }

        public event Action<Schedule> EditScheduleRequested = delegate { };

        private void OnEditSchedule(Schedule schedule)
        {
            EditScheduleRequested(schedule);
        }

       
        private void OnClearSearch()
        {
            SearchInput = null;
        }

        private string _searchInput;
        private List<Schedule> _allSchedules;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterSchedules(_searchInput);
            }
        }

        private void FilterSchedules(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Schedules = new ObservableCollection<Schedule>(_allSchedules);
                return;
            }
            else
            {
                Schedules = new ObservableCollection<Schedule>(_allSchedules.Where(c => c.Name.ToLower().Contains(searchInput.ToLower())));
            }
        }
    }
}
