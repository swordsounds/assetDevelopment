using assetDevelopment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace assetDevelopment.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 2), "Alice", DateTime.Now, DateTime.Now)));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(3, 2), "John", DateTime.Now, DateTime.Now)));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(2, 2), "Mark", DateTime.Now, DateTime.Now)));
        }
    }
}
