using BookingsApi.Models;
using BookingsApi.Repositories;

namespace BookingsApi.Services
{
    public class BookingService : IBookingService
    {        
        private readonly IBookingRepository _repo;

        public BookingService(IBookingRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Booking> GetAll() => _repo.GetAll();

        public Booking? GetById(int id) => _repo.GetById(id);

        /// <summary>
        /// Returnerar true om tidsintervallet krockar med befintlig bokning
        /// </summary>
        public bool HasOverlap(int roomId, DateTime from, DateTime to)
        {
            return _repo.GetAll().Any(b => b.RoomId == roomId && !(b.To <= from || b.From >= to)); //Bug 1: ">" --> ">=" 
        }

        public Booking Create(Booking booking)
        {        
            if (HasOverlap(booking.RoomId, booking.From, booking.To))
                throw new InvalidOperationException("Booking overlaps");

            return _repo.Add(booking);
        }

        public void Cancel(int id) => _repo.Delete(id);
    }
}
