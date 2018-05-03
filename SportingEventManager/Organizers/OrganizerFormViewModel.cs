using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Organizers
{
    class OrganizerFormViewModel : BindableBase
    {
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private IOrganizersRepository _repo;

        public OrganizerFormViewModel(IOrganizersRepository repo)
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

        private DtoOrganizer _organizer;

        public DtoOrganizer Organizer
        {
            get { return _organizer;  }
            set { SetProperty(ref _organizer, value); }
        }

        private Organizer _editingOrganizer = null;

        public void SetOrganizer(Organizer ar)
        {
            _editingOrganizer = ar;
            if (Organizer != null) Organizer.ErrorsChanged -= RaiseCanExecuteChanged;
            Organizer = new DtoOrganizer();
            Organizer.ErrorsChanged += RaiseCanExecuteChanged;
            CopyOrganizer(ar, Organizer);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyOrganizer(Organizer source, DtoOrganizer target)
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
            UpdateOrganizer(Organizer, _editingOrganizer);
            if (EditMode) { await _repo.UpdateOrganizerAsync(_editingOrganizer); }
            else { await _repo.AddOrganizerAsync(_editingOrganizer); }

            Done();
        }

        private void UpdateOrganizer(DtoOrganizer source, Organizer target)
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
            return !Organizer.HasErrors;
        }
    }
}
