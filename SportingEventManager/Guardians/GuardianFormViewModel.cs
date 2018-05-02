using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Guardians
{
    class GuardianFormViewModel : BindableBase
    {
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private IGuardiansRepository _repo;

        public GuardianFormViewModel(IGuardiansRepository repo)
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

        private DtoGuardian _guardian;

        public DtoGuardian Guardian
        {
            get { return _guardian;  }
            set { SetProperty(ref _guardian, value); }
        }

        private Guardian _editingGuardian = null;

        public void SetGuardian(Guardian ar)
        {
            _editingGuardian = ar;
            if (Guardian != null) Guardian.ErrorsChanged -= RaiseCanExecuteChanged;
            Guardian = new DtoGuardian();
            Guardian.ErrorsChanged += RaiseCanExecuteChanged;
            CopyGuardian(ar, Guardian);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyGuardian(Guardian source, DtoGuardian target)
        {
            target.Id = source.Id;

            if(EditMode)
            {
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.City = source.City;
                target.State = source.State;
                target.City = source.City;
                target.Street = source.Street;

            }
        }

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            UpdateGuardian(Guardian, _editingGuardian);
            if (EditMode) { await _repo.UpdateGuardianAsync(_editingGuardian); }
            else { await _repo.AddGuardianAsync(_editingGuardian); }

            Done();
        }

        private void UpdateGuardian(DtoGuardian source, Guardian target)
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
            return !Guardian.HasErrors;
        }
    }
}
