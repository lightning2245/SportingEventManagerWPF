using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.AgeRanges
{
    class AgeRangeFormViewModel : BindableBase
    {
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private IAgeRangesRepository _repo;

        public AgeRangeFormViewModel(IAgeRangesRepository repo)
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

        private DtoAgeRange _ageRange;

        public DtoAgeRange AgeRange
        {
            get { return _ageRange;  }
            set { SetProperty(ref _ageRange, value); }
        }

        private AgeRange _editingAgeRange = null;

        public void SetAgeRange(AgeRange ar)
        {
            _editingAgeRange = ar;
            if (AgeRange != null) AgeRange.ErrorsChanged -= RaiseCanExecuteChanged;
            AgeRange = new DtoAgeRange();
            AgeRange.ErrorsChanged += RaiseCanExecuteChanged;
            CopyAgeRange(ar, AgeRange);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyAgeRange(AgeRange source, DtoAgeRange target)
        {
            target.Id = source.Id;

            if(EditMode)
            {
                target.Min = source.Min;
                target.Max = source.Max;
                
            }
        }

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            UpdateAgeRange(AgeRange, _editingAgeRange);
            if (EditMode) { await _repo.UpdateAgeRangeAsync(_editingAgeRange); }
            else { await _repo.AddAgeRangeAsync(_editingAgeRange); }

            Done();
        }

        private void UpdateAgeRange(DtoAgeRange source, AgeRange target)
        {
            target.Min = source.Min;
            target.Max = source.Max;
            
        }

        private bool CanSave()
        {
            return !AgeRange.HasErrors;
        }
    }
}
