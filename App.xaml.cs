using assetDevelopment.DbContexts;
using assetDevelopment.Models;
using assetDevelopment.Services;
using assetDevelopment.Services.ReservationConflictValidators;
using assetDevelopment.Services.ReservationCreators;
using assetDevelopment.Services.ReservationProviders;
using assetDevelopment.Stores;
using assetDevelopment.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using System.Data;
using System.Windows;

namespace assetDevelopment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data source=reservroom.db";
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;
        private readonly ReservroomDbContextFactory _reservroomDbContextFactory;
        public App()
        {
            _reservroomDbContextFactory = new ReservroomDbContextFactory(CONNECTION_STRING);
            IReservationProvider reservationProvider = new DatabaseReservationProvider(_reservroomDbContextFactory);
            IReservationConflictValidator reservationConflictValidator = new DatabaseReservationConflictValidator(_reservroomDbContextFactory);
            IReservationCreator reservationCreator = new DatabaseReservationCreator(_reservroomDbContextFactory);

            ReservationBook reservationBook = new ReservationBook(reservationProvider, reservationCreator, reservationConflictValidator);
            _hotel = new Hotel("Shmotel", reservationBook);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        { 

            using (ReservroomDbContext dbContext = _reservroomDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            

            _navigationStore.CurrentViewModel = CreateMakeReservationViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
            // Initialize application resources or services here if needed
        }

        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_hotel, new NavigationService(_navigationStore, CreateReservationViewModel));
        }

        private ReservationListingViewModel CreateReservationViewModel()
        {
            return ReservationListingViewModel.LoadViewModel(_hotel ,new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }

}
