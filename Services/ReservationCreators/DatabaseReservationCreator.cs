﻿using assetDevelopment.DbContexts;
using assetDevelopment.DTOs;
using assetDevelopment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assetDevelopment.Services.ReservationCreators
{
    public class DatabaseReservationCreator : IReservationCreator
    {
        private readonly ReservroomDbContextFactory _dbContextFactory;

        public DatabaseReservationCreator(ReservroomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateReservation(Reservation reservation)
        {
            using (ReservroomDbContext context = _dbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = ToReservationDTO(reservation);
                context.Reservations.Add(reservationDTO);
                await context.SaveChangesAsync();
            }
        }

        private ReservationDTO ToReservationDTO(Reservation reservation)
        {
            return new ReservationDTO
            {
                FloorNumber = reservation.RoomID?.FloorNumber ?? 0,
                RoomNumber = reservation.RoomID?.RoomNumber ?? 0,
                Username = reservation.Username,
                StartTime = reservation.StartTime,
                EndTime = reservation.EndTime
            };
        }
    }
}
