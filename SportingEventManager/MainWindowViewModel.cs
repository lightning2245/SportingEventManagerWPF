using SportingEventManager.AgeRanges;
using SportingEventManager.Coaches;
using SportingEventManager.Genders;
using SportingEventManager.Guardians;
using SportingEventManager.Locations;
using SportingEventManager.Organizers;
using SportingEventManager.Players;
using SportingEventManager.Schedules;
using SportingEventManager.Sports;
using SportingEventManager.SportsEvents;
using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using SportingEventManager.Data;
using Unity;

namespace SportingEventManager
{
	class MainWindowViewModel : BindableBase
	{
        private Timer _timer = new Timer(5000);

        private AgeRangeListViewModel _ageRangeListViewModel;
        //private AgeRangeDetailViewModel _ageRangeDetailViewModel;
        private AgeRangeFormViewModel _ageRangeFormViewModel;

        private CoachListViewModel _coachListViewModel;
        //private CoachDetailViewModel _coachDetailViewModel;
        private CoachFormViewModel _coachFormViewModel;

        private GenderListViewModel _genderListViewModel;
        //private GenderDetailViewModel _genderDetailViewModel;
        private GenderFormViewModel _genderFormViewModel;

        private GuardianListViewModel _guardianListViewModel;
        //private GuardianDetailViewModel _guardianDetailViewModel;
        private GuardianFormViewModel _guardianFormViewModel;

        private LocationListViewModel _locationListViewModel;
        //private LocationDetailViewModel _locationDetailViewModel;
        private LocationFormViewModel _locationFormViewModel;

        private OrganizerListViewModel _organizerListViewModel;
        //private OrganizerDetailViewModel _organizerDetailViewModel;
        private OrganizerFormViewModel _organizerFormViewModel;

        private PlayerListViewModel _playerListViewModel;
        //private PlayerDetailViewModel _playerDetailViewModel;
        private PlayerFormViewModel _playerFormViewModel;

        private ScheduleListViewModel _scheduleListViewModel;
        //private ScheduleDetailViewModel _scheduleDetailViewModel;
        private ScheduleFormViewModel _scheduleFormViewModel;

        private SportListViewModel _sportListViewModel;
        //private SportDetailViewModel _sportDetailViewModel;
        private SportFormViewModel _sportFormViewModel;

        private SportsEventListViewModel _sportsEventListViewModel;
        //private SportsEventDetailViewModel _sportsEventDetailViewModel;
        private SportsEventFormViewModel _sportsEventFormViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);

            _ageRangeListViewModel = ContainerHelper.Container.Resolve<AgeRangeListViewModel>();
           //
            _ageRangeFormViewModel = ContainerHelper.Container.Resolve<AgeRangeFormViewModel>();

            _coachListViewModel = ContainerHelper.Container.Resolve<CoachListViewModel>();
            //_coachDetailViewModel = ContainerHelper.Container.Resolve<CoachDetailViewModel>();
            _coachFormViewModel = ContainerHelper.Container.Resolve<CoachFormViewModel>();

            _genderListViewModel = ContainerHelper.Container.Resolve<GenderListViewModel>();
            //_genderDetailViewModel = ContainerHelper.Container.Resolve<GenderDetailViewModel>();
            _genderFormViewModel = ContainerHelper.Container.Resolve<GenderFormViewModel>();

            _guardianListViewModel = ContainerHelper.Container.Resolve<GuardianListViewModel>();
            //_guardianDetailViewModel = ContainerHelper.Container.Resolve<GuardianDetailViewModel>();
            _guardianFormViewModel = ContainerHelper.Container.Resolve<GuardianFormViewModel>();

            _locationListViewModel = ContainerHelper.Container.Resolve<LocationListViewModel>();
            //_locationDetailViewModel = ContainerHelper.Container.Resolve<LocationDetailViewModel>();
            _locationFormViewModel = ContainerHelper.Container.Resolve<LocationFormViewModel>();

            _organizerListViewModel = ContainerHelper.Container.Resolve<OrganizerListViewModel>();
            //_organizerDetailViewModel = ContainerHelper.Container.Resolve<OrganizerDetailViewModel>();
            _organizerFormViewModel = ContainerHelper.Container.Resolve<OrganizerFormViewModel>();

            _playerListViewModel = ContainerHelper.Container.Resolve<PlayerListViewModel>();
            //_playerDetailViewModel = ContainerHelper.Container.Resolve<PlayerDetailViewModel>();
            _playerFormViewModel = ContainerHelper.Container.Resolve<PlayerFormViewModel>();

            _scheduleListViewModel = ContainerHelper.Container.Resolve<ScheduleListViewModel>();
            //_scheduleDetailViewModel = ContainerHelper.Container.Resolve<ScheduleDetailViewModel>();
            _scheduleFormViewModel = ContainerHelper.Container.Resolve<ScheduleFormViewModel>();

            _sportListViewModel = ContainerHelper.Container.Resolve<SportListViewModel>();
            //_sportDetailViewModel = ContainerHelper.Container.Resolve<SportDetailViewModel>();
            _sportFormViewModel = ContainerHelper.Container.Resolve<SportFormViewModel>();

            _sportsEventListViewModel = ContainerHelper.Container.Resolve<SportsEventListViewModel>();
            //_sportsEventDetailViewModel = ContainerHelper.Container.Resolve<SportsEventDetailViewModel>();
            _sportsEventFormViewModel = ContainerHelper.Container.Resolve<SportsEventFormViewModel>();


            //_ageRangeListViewModel.DetailAgeRangeRequested += NavToAgeRangeDetail;
            _ageRangeListViewModel.AddAgeRangeRequested += NavToAddAgeRange;
            _ageRangeListViewModel.EditAgeRangeRequested += NavToEditAgeRange;
            _ageRangeFormViewModel.Done += NavToAgeRangeList;

            //_coachListViewModel.DetailCoachRequested += NavToCoachDetail;
            _coachListViewModel.AddCoachRequested += NavToAddCoach;
            _coachListViewModel.EditCoachRequested += NavToEditCoach;
            _coachFormViewModel.Done += NavToCoachList;

            //_genderListViewModel.DetailGenderRequested += NavToGenderDetail;
            _genderListViewModel.AddGenderRequested += NavToAddGender;
            _genderListViewModel.EditGenderRequested += NavToEditGender;
            _genderFormViewModel.Done += NavToGenderList;

            //_guardianListViewModel.DetailGuardianRequested += NavToGuardianDetail;
            _guardianListViewModel.AddGuardianRequested += NavToAddGuardian;
            _guardianListViewModel.EditGuardianRequested += NavToEditGuardian;
            _guardianFormViewModel.Done += NavToGuardianList;

            //_locationListViewModel.DetailLocationRequested += NavToLocationDetail;
            _locationListViewModel.AddLocationRequested += NavToAddLocation;
            _locationListViewModel.EditLocationRequested += NavToEditLocation;
            _locationFormViewModel.Done += NavToLocationList;

            //_organizerListViewModel.DetailOrganizerRequested += NavToOrganizerDetail;
            _organizerListViewModel.AddOrganizerRequested += NavToAddOrganizer;
            _organizerListViewModel.EditOrganizerRequested += NavToEditOrganizer;
            _organizerFormViewModel.Done += NavToOrganizerList;

            //_playerListViewModel.DetailPlayerRequested += NavToPlayerDetail;
            _playerListViewModel.AddPlayerRequested += NavToAddPlayer;
            _playerListViewModel.EditPlayerRequested += NavToEditPlayer;
            _playerFormViewModel.Done += NavToPlayerList;

            //_scheduleListViewModel.DetailScheduleRequested += NavToScheduleDetail;
            _scheduleListViewModel.AddScheduleRequested += NavToAddSchedule;
            _scheduleListViewModel.EditScheduleRequested += NavToEditSchedule;
            _scheduleFormViewModel.Done += NavToScheduleList;

            //_sportListViewModel.DetailSportRequested += NavToSportDetail;
            _sportListViewModel.AddSportRequested += NavToAddSport;
            _sportListViewModel.EditSportRequested += NavToEditSport;
            _sportFormViewModel.Done += NavToSportList;

            //_sportsEventListViewModel.DetailSportsEventRequested += NavToSportsEventDetail;
            _sportsEventListViewModel.AddSportsEventRequested += NavToAddSportsEvent;
            _sportsEventListViewModel.EditSportsEventRequested += NavToEditSportsEvent;
            _sportsEventFormViewModel.Done += NavToSportsEventList;
        }

        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        private string _notificationMessage;

        public string NotificationMessage
        {
            get { return _notificationMessage; }
            set { SetProperty(ref _notificationMessage, value); }
        }

        //public string NotificationMessage
        //{
        //    get { return _NotificationMessage; }
        //    set
        //    {
        //        if (value != _NotificationMessage)
        //        {
        //            _NotificationMessage = value;
        //            PropertyChanged(this, new PropertyChangedEventArgs("NotificationMessage"));
        //        }
        //    }


        //}

        public RelayCommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "ageRangeList":
                    CurrentViewModel = _ageRangeListViewModel;
                    break;
                //case "ageRangeDetail":
                //    CurrentViewModel = _ageRangeDetailViewModel;
                //    break;
                case "ageRangeFormAdd":
                    CurrentViewModel = _ageRangeFormViewModel;
                    break;

                case "coachList":
                    CurrentViewModel = _coachListViewModel;
                    break;
                case "coachDetail":
                    //CurrentViewModel = _coachDetailViewModel;
                    break;
                case "coachForm":
                    CurrentViewModel = _coachFormViewModel;
                    break;

                case "genderList":
                    CurrentViewModel = _genderListViewModel;
                    break;
                case "genderDetail":
                    //CurrentViewModel = _genderDetailViewModel;
                    break;
                case "genderForm":
                    CurrentViewModel = _genderFormViewModel;
                    break;

                case "guardianList":
                    CurrentViewModel = _guardianListViewModel;
                    break;
                case "guardianDetail":
                    //CurrentViewModel = _guardianDetailViewModel;
                    break;
                case "guardianForm":
                    CurrentViewModel = _guardianFormViewModel;
                    break;

                case "locationList":
                    CurrentViewModel = _locationListViewModel;
                    break;
                case "locationDetail":
                    //CurrentViewModel = _locationDetailViewModel;
                    break;
                case "locationForm":
                    CurrentViewModel = _locationFormViewModel;
                    break;

                case "organizerList":
                    CurrentViewModel = _organizerListViewModel;
                    break;
                case "organizerDetail":
                    //CurrentViewModel = _organizerDetailViewModel;
                    break;
                case "organizerForm":
                    CurrentViewModel = _organizerFormViewModel;
                    break;

                case "playerList":
                    CurrentViewModel = _playerListViewModel;
                    break;
                case "playerDetail":
                    //CurrentViewModel = _playerDetailViewModel;
                    break;
                case "playerForm":
                    CurrentViewModel = _playerFormViewModel;
                    break;

                case "scheduleList":
                    CurrentViewModel = _scheduleListViewModel;
                    break;
                case "scheduleDetail":
                    //CurrentViewModel = _scheduleDetailViewModel;
                    break;
                case "scheduleForm":
                    CurrentViewModel = _scheduleFormViewModel;
                    break;

                case "sportList":
                    CurrentViewModel = _sportListViewModel;
                    break;
                case "sportDetail":
                    //CurrentViewModel = _sportDetailViewModel;
                    break;
                case "sportForm":
                    CurrentViewModel = _sportFormViewModel;
                    break;

                case "sportsEventList":
                    CurrentViewModel = _sportsEventListViewModel;
                    break;
                case "sportsEventDetail":
                    //CurrentViewModel = _sportsEventDetailViewModel;
                    break;
                case "sportsEventForm":
                    CurrentViewModel = _sportsEventFormViewModel;
                    break;
                default:
                    CurrentViewModel = _sportsEventListViewModel;
                    break;
            }
        }


        #region AgeRangeNav Functions
        private void NavToAgeRangeList()
        {
            CurrentViewModel = _ageRangeListViewModel;
        }

        private void NavToAgeRangeDetail(AgeRange ageRange)
        {
            //_ageRangeDetailViewModel.SetAgeRange(ageRange);
            //CurrentViewModel = _ageRangeDetailViewModel;
        }

        private void NavToEditAgeRange(AgeRange ageRange)
        {
            _ageRangeFormViewModel.EditMode = true;
            _ageRangeFormViewModel.SetAgeRange(ageRange);
            CurrentViewModel = _ageRangeFormViewModel;
        }

        private void NavToAddAgeRange(AgeRange ageRange)
        {
            _ageRangeFormViewModel.EditMode = false;
            _ageRangeFormViewModel.SetAgeRange(ageRange);
            CurrentViewModel = _ageRangeFormViewModel;
        }
        #endregion

        #region CoachNav Functions
        private void NavToCoachList()
        {
            CurrentViewModel = _coachListViewModel;
        }

        private void NavToCoachDetail(int coachId)
        {
            //_coachListViewModel.coachId = coachId;
            //CurrentViewModel = _coachDetailViewModel;
        }

        private void NavToEditCoach(Coach coach)
        {
            _coachFormViewModel.EditMode = true;
            _coachFormViewModel.SetCoach(coach);
            CurrentViewModel = _coachFormViewModel;
        }

        private void NavToAddCoach(Coach coach)
        {
            _coachFormViewModel.EditMode = false;
            _coachFormViewModel.SetCoach(coach);
            CurrentViewModel = _coachFormViewModel;
        }
        #endregion

        #region GenderNav Functions
        private void NavToGenderList()
        {
            CurrentViewModel = _genderListViewModel;
        }

        private void NavToGenderDetail(int genderId)
        {
            //_genderListViewModel.genderId = genderId;
            //CurrentViewModel = _genderDetailViewModel;
        }

        private void NavToEditGender(Gender gender)
        {
            _genderFormViewModel.EditMode = true;
            _genderFormViewModel.SetGender(gender);
            CurrentViewModel = _genderFormViewModel;
        }

        private void NavToAddGender(Gender gender)
        {
            _genderFormViewModel.EditMode = false;
            _genderFormViewModel.SetGender(gender);
            CurrentViewModel = _genderFormViewModel;
        }
        #endregion

        #region GuardianNav Functions
        private void NavToGuardianList()
        {
            CurrentViewModel = _guardianListViewModel;
        }

        private void NavToGuardianDetail(int guardianId)
        {
            //_guardianDetailViewModel.guardianId = guardianId;
            //CurrentViewModel = _guardianDetailViewModel;
        }

        private void NavToEditGuardian(Guardian guardian)
        {
            _guardianFormViewModel.EditMode = true;
            _guardianFormViewModel.SetGuardian(guardian);
            CurrentViewModel = _guardianFormViewModel;
        }

        private void NavToAddGuardian(Guardian guardian)
        {
            _guardianFormViewModel.EditMode = false;
            _guardianFormViewModel.SetGuardian(guardian);
            CurrentViewModel = _guardianFormViewModel;
        }
        #endregion

        #region LocationNav Functions
        private void NavToLocationList()
        {
            CurrentViewModel = _locationListViewModel;
        }

        private void NavToLocationDetail(int locationId)
        {
            //_locationDetailViewModel.locationId = locationId;
            //CurrentViewModel = _locationDetailViewModel;
        }

        private void NavToEditLocation(Location location)
        {
            _locationFormViewModel.EditMode = true;
            _locationFormViewModel.SetLocation(location);
            CurrentViewModel = _locationFormViewModel;
        }

        private void NavToAddLocation(Location location)
        {
            _locationFormViewModel.EditMode = false;
            _locationFormViewModel.SetLocation(location);
            CurrentViewModel = _locationFormViewModel;
        }
        #endregion

        #region OrganizerNav Functions
        private void NavToOrganizerList()
        {
            CurrentViewModel = _organizerListViewModel;
        }

        private void NavToOrganizerDetail(int organizerId)
        {
            //_organizerDetailViewModel.organizerId = organizerId;
            //CurrentViewModel = _organizerDetailViewModel;
        }

        private void NavToEditOrganizer(Organizer organizer)
        {
            _organizerFormViewModel.EditMode = true;
            _organizerFormViewModel.SetOrganizer(organizer);
            CurrentViewModel = _organizerFormViewModel;
        }

        private void NavToAddOrganizer(Organizer organizer)
        {
            _organizerFormViewModel.EditMode = false;
            _organizerFormViewModel.SetOrganizer(organizer);
            CurrentViewModel = _organizerFormViewModel;
        }
        #endregion

        #region PlayerNav Functions
        private void NavToPlayerList()
        {
            CurrentViewModel = _playerListViewModel;
        }

        private void NavToPlayerDetail(int playerId)
        {
            //_playerDetailViewModel.playerId = playerId;
            //CurrentViewModel = _playerDetailViewModel;
        }

        private void NavToEditPlayer(Player player)
        {
            _playerFormViewModel.EditMode = true;
            _playerFormViewModel.SetPlayer(player);
            CurrentViewModel = _playerFormViewModel;
        }

        private void NavToAddPlayer(Player player)
        {
            _playerFormViewModel.EditMode = false;
            _playerFormViewModel.SetPlayer(player);
            CurrentViewModel = _playerFormViewModel;
        }
        #endregion

        #region ScheduleNav Functions
        private void NavToScheduleList()
        {
            CurrentViewModel = _scheduleListViewModel;
        }

        private void NavToScheduleDetail(int scheduleId)
        {
            //_scheduleDetailViewModel.scheduleId = scheduleId;
            //CurrentViewModel = _scheduleDetailViewModel;
        }

        private void NavToEditSchedule(Schedule schedule)
        {
            _scheduleFormViewModel.EditMode = true;
            _scheduleFormViewModel.SetSchedule(schedule);
            CurrentViewModel = _scheduleFormViewModel;
        }

        private void NavToAddSchedule(Schedule schedule)
        {
            _scheduleFormViewModel.EditMode = false;
            _scheduleFormViewModel.SetSchedule(schedule);
            CurrentViewModel = _scheduleFormViewModel;
        }
        #endregion

        #region SportNav Functions
        private void NavToSportList()
        {
            CurrentViewModel = _sportListViewModel;
        }

        private void NavToSportDetail(int sportId)
        {
            //_sportDetailViewModel.sportId = sportId;
            //CurrentViewModel = _sportDetailViewModel;
        }

        private void NavToEditSport(Sport sport)
        {
            _sportFormViewModel.EditMode = true;
            _sportFormViewModel.SetSport(sport);
            CurrentViewModel = _sportFormViewModel;
        }

        private void NavToAddSport(Sport sport)
        {
            _sportFormViewModel.EditMode = false;
            _sportFormViewModel.SetSport(sport);
            CurrentViewModel = _sportFormViewModel;
        }
        #endregion

        #region SportsEventNav Functions
        private void NavToSportsEventList()
        {
            CurrentViewModel = _sportsEventListViewModel;
        }

        private void NavToSportsEventDetail(int sportsEventId)
        {
            //_sportsEventDetailViewModel.sportsEventId = sportsEventId;
            //CurrentViewModel = _sportsEventDetailViewModel;
        }

        private void NavToEditSportsEvent(SportsEvent sportsEvent)
        {
            _sportsEventFormViewModel.EditMode = true;
            _sportsEventFormViewModel.SetSportsEvent(sportsEvent);
            CurrentViewModel = _sportsEventFormViewModel;
        }

        private void NavToAddSportsEvent(SportsEvent sportsEvent)
        {
            _sportsEventFormViewModel.EditMode = false;
            _sportsEventFormViewModel.SetSportsEvent(sportsEvent);
            CurrentViewModel = _sportsEventFormViewModel;
        }
        #endregion
    }
}
