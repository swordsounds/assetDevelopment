using assetDevelopment.Models;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("SHmotel");

            Reservation reservation1 = new Reservation(new RoomID(1, 101), "user1", DateTime.Now, DateTime.Now.AddDays(2));
            hotel.MakeReservation(reservation1);

            IEnumerable<Reservation> userReservations = hotel.GetAllReservations();

            base.OnStartup(e);
            // Initialize application resources or services here if needed
        }
    }

}
