using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Schedules
{
    class ScheduleFormViewModel : BindableBase
    {
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private ISchedulesRepository _repo;

        public ScheduleFormViewModel(ISchedulesRepository repo)
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

        private DtoSchedule _schedule;

        public DtoSchedule Schedule
        {
            get { return _schedule;  }
            set { SetProperty(ref _schedule, value); }
        }

        private Schedule _editingSchedule = null;

        public void SetSchedule(Schedule ar)
        {
            _editingSchedule = ar;
            if (Schedule != null) Schedule.ErrorsChanged -= RaiseCanExecuteChanged;
            Schedule = new DtoSchedule();
            Schedule.ErrorsChanged += RaiseCanExecuteChanged;
            CopySchedule(ar, Schedule);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopySchedule(Schedule source, DtoSchedule target)
        {
            target.Id = source.Id;

            if(EditMode)
            {
                target.Name = source.Name;              
                
            }
        }

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            UpdateSchedule(Schedule, _editingSchedule);
            if (EditMode) { await _repo.UpdateScheduleAsync(_editingSchedule); }
            else { await _repo.AddScheduleAsync(_editingSchedule); }

            Done();
        }

        private void UpdateSchedule(DtoSchedule source, Schedule target)
        {
            target.Name = source.Name;
        }

        private bool CanSave()
        {
            return !Schedule.HasErrors;
        }
    }
}
