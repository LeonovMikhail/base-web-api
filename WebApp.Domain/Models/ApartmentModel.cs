using System.Collections.Generic;

namespace WebApp.Domain.Models
{
    public class ApartmentModel : BaseModel
    {
        public string Address { get; set; }
        public double Area { get; set; }
        public int CountRoom { get; set; }
        public int MaxCountGuests { get; set; }
        public double BookingCost { get; set; }
        public virtual ICollection<BookingModel> Bookings { get; set; }
    }
}