using assetDevelopment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assetDevelopment.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        //model
        private readonly Reservation _reservation;

        //properties the view needs, ? is null check
        public string RoomID => _reservation.RoomID.ToString();
        public string Username => _reservation.Username.ToString();
        public string StartDate => _reservation.StartTime.ToString("d");
        public string EndDate => _reservation.EndTime.ToString("d");

        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}
