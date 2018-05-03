using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Sports
{
    class SportFormViewModel : BindableBase
    {
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private ISportsRepository _repo;

        public SportFormViewModel(ISportsRepository repo)
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

        private DtoSport _sport;

        public DtoSport Sport
        {
            get { return _sport;  }
            set { SetProperty(ref _sport, value); }
        }

        private Sport _editingSport = null;

        public void SetSport(Sport ar)
        {
            _editingSport = ar;
            if (Sport != null) Sport.ErrorsChanged -= RaiseCanExecuteChanged;
            Sport = new DtoSport();
            Sport.ErrorsChanged += RaiseCanExecuteChanged;
            CopySport(ar, Sport);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopySport(Sport source, DtoSport target)
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
            UpdateSport(Sport, _editingSport);
            if (EditMode) { await _repo.UpdateSportAsync(_editingSport); }
            else { await _repo.AddSportAsync(_editingSport); }

            Done();
        }

        private void UpdateSport(DtoSport source, Sport target)
        {
            target.Name = source.Name;
        }

        private bool CanSave()
        {
            return !Sport.HasErrors;
        }
    }
}
