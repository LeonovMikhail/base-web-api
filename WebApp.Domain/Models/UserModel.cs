using System.Collections.Generic;

namespace WebApp.Domain.Models
{
    public class UserModel : BaseModel
    {
        public string Login { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<BookingModel> Booking { get; set; } 
    }
}