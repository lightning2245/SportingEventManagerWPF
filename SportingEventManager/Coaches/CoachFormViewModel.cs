using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Coaches
{
    class CoachFormViewModel : BindableBase
    {
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private ICoachesRepository _repo;

        public CoachFormViewModel(ICoachesRepository repo)
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

        private DtoCoach _coach;

        public DtoCoach Coach
        {
            get { return _coach;  }
            set { SetProperty(ref _coach, value); }
        }

        private Coach _editingCoach = null;

        public void SetCoach(Coach ar)
        {
            _editingCoach = ar;
            if (Coach != null) Coach.ErrorsChanged -= RaiseCanExecuteChanged;
            Coach = new DtoCoach();
            Coach.ErrorsChanged += RaiseCanExecuteChanged;
            CopyCoach(ar, Coach);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyCoach(Coach source, DtoCoach target)
        {
            target.Id = source.Id;

            if(EditMode)
            {
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
            }
        }

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            UpdateCoach(Coach, _editingCoach);
            if (EditMode) { await _repo.UpdateCoachAsync(_editingCoach); }
            else { await _repo.AddCoachAsync(_editingCoach); }

            Done();
        }

        private void UpdateCoach(DtoCoach source, Coach target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.City = source.City;
            target.State = source.State;
            target.City = source.City;
            target.Street = source.Street;

        }

        private bool CanSave()
        {
            return !Coach.HasErrors;
        }
    }
}
