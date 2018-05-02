using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Players
{
    class PlayerFormViewModel : BindableBase
    {
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private IPlayersRepository _repo;

        public PlayerFormViewModel(IPlayersRepository repo)
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

        private DtoPlayer _player;

        public DtoPlayer Player
        {
            get { return _player;  }
            set { SetProperty(ref _player, value); }
        }

        private Player _editingPlayer = null;

        public void SetPlayer(Player ar)
        {
            _editingPlayer = ar;
            if (Player != null) Player.ErrorsChanged -= RaiseCanExecuteChanged;
            Player = new DtoPlayer();
            Player.ErrorsChanged += RaiseCanExecuteChanged;
            CopyPlayer(ar, Player);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyPlayer(Player source, DtoPlayer target)
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
            UpdatePlayer(Player, _editingPlayer);
            if (EditMode) { await _repo.UpdatePlayerAsync(_editingPlayer); }
            else { await _repo.AddPlayerAsync(_editingPlayer); }

            Done();
        }

        private void UpdatePlayer(DtoPlayer source, Player target)
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
            return !Player.HasErrors;
        }
    }
}
