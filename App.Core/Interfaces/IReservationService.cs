using System.Collections.Generic;
using App.Core.Models;

namespace App.Core.Interfaces
{
    public interface IReservationService
    {
        List<Reservation> GetAllReservations();
        void AddReservation(Reservation reservation);
        void CancelReservation(int reservationId);
        void FulfillReservation(int reservationId);
        List<Reservation> GetReservationsByMember(int memberId);
    }
}