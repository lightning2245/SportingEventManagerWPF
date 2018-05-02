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

namespace SportingEventManager.Players
{
    public class PlayerListViewModel : BindableBase
    {
        //private IPlayersRepository _repo = new PlayersRepository();
        private IPlayersRepository _repo;

        //public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public PlayerListViewModel(IPlayersRepository repo)
        {
            _repo = repo;
            //if (DesignerProperties.GetIsInDesignMode(
            //	new System.Windows.DependencyObject())) return;

            //Players = new ObservableCollection<Player>(_repo.GetPlayersAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        
            AddPlayerCommand = new RelayCommand(OnAddPlayer);
            EditPlayerCommand = new RelayCommand<Player>(OnEditPlayer);
            ClearSearchCommand = new RelayCommand(OnClearSearch);

        }

        private ObservableCollection<Player> _players;

        public ObservableCollection<Player> Players
        {
            get { return _players; }
            set { SetProperty(ref _players, value); }
        }

        private Player _selectedPlayer;

        public Player SelectedPlayer
        {
            get { return _selectedPlayer; }

            set
            {
                if (_selectedPlayer != value)
                {
                    //_selectedPlayer = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    ChangeCommand.RaiseCanExecuteChanged();
                    SetProperty(ref _selectedPlayer, value);
                    //PropertyChanged(this, new PropertyChangedEventArgs("SelectedPlayer"));
                }
            }
        }

        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ChangeCommand { get; set; }
        public RelayCommand AddPlayerCommand { get; private set; }
        public RelayCommand<Player> EditPlayerCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public async void LoadPlayers()
		{
			if (DesignerProperties.GetIsInDesignMode(
				new System.Windows.DependencyObject())) return;

            //Players = new ObservableCollection<Player>(await _repo.GetPlayersAsync());
            _allPlayers = await _repo.GetPlayersAsync();
            Players = new ObservableCollection<Player>(_allPlayers);
        }

		private bool CanDelete()
		{
			return SelectedPlayer != null;
		}

        private bool CanChange()
        {
            return SelectedPlayer != null;
        }

        private void OnDelete()
		{
			Players.Remove(SelectedPlayer);
		}

        
        public event Action<Player> AddPlayerRequested = delegate { };

        private void OnAddPlayer()
        {
            AddPlayerRequested(new Player {  });
        }

        public event Action<Player> EditPlayerRequested = delegate { };

        private void OnEditPlayer(Player player)
        {
            EditPlayerRequested(player);
        }

       
        private void OnClearSearch()
        {
            SearchInput = null;
        }

        private string _searchInput;
        private List<Player> _allPlayers;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterPlayers(_searchInput);
            }
        }

        private void FilterPlayers(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Players = new ObservableCollection<Player>(_allPlayers);
                return;
            }
            else
            {
                Players = new ObservableCollection<Player>(_allPlayers.Where(c => c.Name.ToLower().Contains(searchInput.ToLower())));
            }
        }
    }
}
