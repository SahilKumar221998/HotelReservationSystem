using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    public class HotelReservation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("______________________________________________________________________________________________");
            Console.WriteLine("_____________________________WELCOME TO HOTEL RESERVATION SYSTEM______________________________");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            HotelServiceImpl hotelService = new HotelServiceImpl();
            hotelService.hotel_Based_OnRange();
        }
    }
}
