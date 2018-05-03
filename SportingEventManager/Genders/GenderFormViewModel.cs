using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Genders
{
    class GenderFormViewModel : BindableBase
    {
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private IGendersRepository _repo;

        public GenderFormViewModel(IGendersRepository repo)
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

        private DtoGender _gender;

        public DtoGender Gender
        {
            get { return _gender;  }
            set { SetProperty(ref _gender, value); }
        }

        private Gender _editingGender = null;

        public void SetGender(Gender ar)
        {
            _editingGender = ar;
            if (Gender != null) Gender.ErrorsChanged -= RaiseCanExecuteChanged;
            Gender = new DtoGender();
            Gender.ErrorsChanged += RaiseCanExecuteChanged;
            CopyGender(ar, Gender);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyGender(Gender source, DtoGender target)
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
            UpdateGender(Gender, _editingGender);
            if (EditMode) { await _repo.UpdateGenderAsync(_editingGender); }
            else { await _repo.AddGenderAsync(_editingGender); }

            Done();
        }

        private void UpdateGender(DtoGender source, Gender target)
        {
            target.Name = source.Name;            

        }

        private bool CanSave()
        {
            return !Gender.HasErrors;
        }
    }
}
