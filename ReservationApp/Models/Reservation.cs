using System;

namespace ReservationApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public string TableNumber { get; set; }
    }
}
