using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    public class InvalidHotelReservationException:Exception
    {
        public InvalidHotelReservationException(string message) : base(message) { 
        
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
