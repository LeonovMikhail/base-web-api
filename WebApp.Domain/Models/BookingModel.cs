using System;

namespace BksTest.Domain.Models
{
    public class BookingModel : BaseModel
    {
        public int GuestCount { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid UserId { get; set; }
        public virtual UserModel User { get; set; }
        public Guid ApartmentId { get; set; }
        public virtual ApartmentModel Apartment { get; set; }
    }
}