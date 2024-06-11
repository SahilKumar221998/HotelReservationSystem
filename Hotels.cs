using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    //UC1
    public class Hotels
    {
        private string hotel_Name;
        public string HotelName
        {
            get { return hotel_Name; }  
            set { hotel_Name = value; }
        }

        private double weekday_Rates_For_Regular_Customer;
        public double Weekday_Rates_For_Regular_Customer
        {
            get { return weekday_Rates_For_Regular_Customer;}
            set {weekday_Rates_For_Regular_Customer = value;}
        }

        private double weekday_Rates_For_Reward_Customers;
        public double Weekday_Rates_For_Rewards_Customers
        {
            get { return weekday_Rates_For_Reward_Customers; }
            set { weekday_Rates_For_Reward_Customers = value; }
        }

        private double weekend_Rates_For_Regular_Customers;
        public double Weekend_Rates_For_Regular_Customers
        {
            get { return weekend_Rates_For_Regular_Customers; }
            set { weekend_Rates_For_Regular_Customers = value; }
        }
        private double weekend_Rates_For_Reward_Customers;
        public double Weekend_Rates_For_Rewards_Customers
        {
            get { return weekend_Rates_For_Reward_Customers; }
            set { weekend_Rates_For_Regular_Customers= value; }
        }
        //private double ratings;
        //public double Ratings
        //{
        //    get { return ratings; }
        //    set { ratings = value; }
        //}

        public Hotels(string hotel_Name, double weekday_Rates_For_Regular_Customer, double weekday_Rates_For_Reward_Customers, double weekend_Rates_For_Regular_Customers, double weekend_Rates_For_Reward_Customers)
        {
            this.hotel_Name = hotel_Name;
            this.weekday_Rates_For_Regular_Customer = weekday_Rates_For_Regular_Customer;
            this.weekday_Rates_For_Reward_Customers = weekday_Rates_For_Reward_Customers;
            this.weekend_Rates_For_Regular_Customers = weekend_Rates_For_Regular_Customers;
            this.weekend_Rates_For_Reward_Customers = weekend_Rates_For_Reward_Customers;
            
        }

        public override string? ToString()
        {
            Console.WriteLine("______________________________________________________________________________");
            return $"Hotel_Name:-{hotel_Name} Weekday Rates_Regualar_Customer:-{weekday_Rates_For_Regular_Customer} Weekday Rates_Reward_Customer:-{weekday_Rates_For_Reward_Customers} Weekend Rates_Regular_Customer:-{weekend_Rates_For_Regular_Customers} Weekend Rates_Rewards_Customer:-{weekend_Rates_For_Reward_Customers}";
        }
    }
}
