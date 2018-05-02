using SportingEventManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace SportingEventManager
{
    public static class ContainerHelper
    {
        private static IUnityContainer _container;

        static ContainerHelper()
        {
            _container = new UnityContainer();
            _container.RegisterType<IAgeRangesRepository, AgeRangesRepository>(
                new ContainerControlledLifetimeManager());

            _container.RegisterType<ICoachesRepository, CoachesRepository>(
                new ContainerControlledLifetimeManager());

            _container.RegisterType<IGendersRepository, GendersRepository>(
                new ContainerControlledLifetimeManager());

            _container.RegisterType<IGuardiansRepository, GuardiansRepository>(
               new ContainerControlledLifetimeManager());

            _container.RegisterType<ILocationsRepository, LocationsRepository>(
               new ContainerControlledLifetimeManager());

            _container.RegisterType<IOrganizersRepository, OrganizersRepository>(
               new ContainerControlledLifetimeManager());

            _container.RegisterType<IPlayersRepository, PlayersRepository>(
               new ContainerControlledLifetimeManager());

            _container.RegisterType<ISchedulesRepository, SchedulesRepository>(
               new ContainerControlledLifetimeManager());

            _container.RegisterType<ISportsRepository, SportsRepository>(
               new ContainerControlledLifetimeManager());

            _container.RegisterType<ISportsEventsRepository, SportsEventsRepository>(
               new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer Container
        {
            get { return _container; }
        }
    }
}
