﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    public class HotelServiceImpl : IHotelService
    {
        Regex regex;
        public List<Hotels> addHotels()
        {
            List<Hotels> hotel_list = new List<Hotels>();
            hotel_list.Add(new Hotels("LakeWood",110.0, 80.0, 90.0, 80.0));
            hotel_list.Add(new Hotels("BridgeWood",160.0, 110.0, 60.0, 50.0));
            hotel_list.Add(new Hotels("RidgeWood", 220.0, 100.0, 150.0, 40.0));
            return hotel_list;  
        }

        public void hotel_Based_OnRange()
        {
            int week = 0;
            int weekend = 0;
            double total_Cost =int.MaxValue;
            string hotel_Name = "";
            while (true)
            {
                Console.WriteLine("Select The Type Of Customer:-");
                Console.WriteLine("______________________________________________________________________________________________");
                Console.WriteLine("1.Regular\n2.Rewards\n3.Logout");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 3)
                    break;
                Console.WriteLine("______________________________________________________________________________________________");
                Console.WriteLine("Enter the starting date(dd)");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
               
                Console.WriteLine("Enter the date");
                int dd = Convert.ToInt32(Console.ReadLine());
                string pattern = @"^(0[1-9]|[12][0-9]|3[01])$";
                string message = "Invalid date.Enter a valid day (01 T0 30)";
                regex= new Regex(pattern);
                string temp = dd.ToString();
                string data= dateCredentials(temp, message);
                dd=int.Parse(data);   
                
                Console.WriteLine("Enter the Month(MM)");
                int mm = Convert.ToInt32(Console.ReadLine());
                pattern = @"^(0[1-9]|1[0-2])$";
                message = "Invalid month. Please enter a valid month (01 to 12):";
                regex = new Regex(pattern);
                temp = mm.ToString();
                temp = dateCredentials(temp, message);
                mm = Convert.ToInt32(temp);
                
                Console.WriteLine("Enter the year(YYYY)");
                int yyyy = Convert.ToInt32(Console.ReadLine());
                pattern = @"^\d{4}$";
                message = "Invalid year. Please enter a valid year (e.g., 2012):";
                regex = new Regex(pattern);
                temp = yyyy.ToString();
                temp = dateCredentials(temp, message);
                yyyy = Convert.ToInt32(temp);
                DateTime date1 = new DateTime(yyyy, mm, dd);

                Console.WriteLine("______________________________________________________________________________________________");
                Console.WriteLine("Enter the ending date");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
               
                Console.WriteLine("Enter the date(dd)");
                dd = Convert.ToInt32(Console.ReadLine());
                pattern = @"^(0[1-9]|[12][0-9]|3[01])$";
                message = "Invalid date.Enter a valid day (01 T0 30)";
                regex = new Regex(pattern);
                temp = dd.ToString();
                temp = dateCredentials(temp, message);
                dd = Convert.ToInt32(temp);
               
                Console.WriteLine("Enter the Month(MM)");
                mm = Convert.ToInt32(Console.ReadLine());
                pattern = @"^(0[1-9]|1[0-2])$";
                message = "Invalid month. Please enter a valid month (01 to 12):";
                regex = new Regex(pattern);
                temp = mm.ToString();
                temp = dateCredentials(temp, message);
                mm = Convert.ToInt32(temp);
                
                Console.WriteLine("Enter the year(YYYY)");
                yyyy = Convert.ToInt32(Console.ReadLine());
                pattern = @"^\d{4}$";
                message = "Invalid year. Please enter a valid year (e.g., 2012):";
                regex = new Regex(pattern);
                temp = yyyy.ToString();
                temp = dateCredentials(temp, message);
                yyyy = Convert.ToInt32(temp);
                DateTime date2=new DateTime(yyyy, mm, dd);
                DateTime temps= date1.Date;
                
                //Calculating weekdays and weekends
                while(!temps.Equals(date2))
                {
                    
                    int day = (int)temps.DayOfWeek;
                    if (day >= 1 && day <= 5)
                        week++;
                    else
                        weekend++;
                    temps=temps.AddDays(1);
                }
                // Calculating cheap hotel based on rates
                if(date1.Date<date2.Date)
                {
                    IHotelService service = new HotelServiceImpl();
                    switch (choice)
                    {
                        case 1:

                            var min_Cost = (from hotel in service.addHotels()
                                            select new { weekRate = hotel.Weekday_Rates_For_Regular_Customer*week, 
                                            weekendRate = hotel.Weekend_Rates_For_Regular_Customers*weekend,Hotel_Name=hotel.HotelName })
                                            .GroupBy(x=>x.Hotel_Name);
                            foreach (var cost in min_Cost)
                            { 
                                double hotel_Cost = cost.Sum(i => i.weekRate + i.weekendRate);
                                if (total_Cost > hotel_Cost)
                                {
                                    total_Cost = hotel_Cost;
                                    hotel_Cost = 0;
                                    foreach (var item in cost)
                                    {
                                        hotel_Name = item.Hotel_Name;

                                    }
                                }
                               
                            }
                            Console.WriteLine("----------------------------------------------------------------------------------------------");
                            Console.WriteLine($"{hotel_Name}->{total_Cost}");
                            Console.WriteLine("----------------------------------------------------------------------------------------------");
                            break;
                        case 2:
                            min_Cost = (from hotel in service.addHotels()
                                            select new { weekRate = hotel.Weekday_Rates_For_Rewards_Customers*week, 
                                            weekendRate = hotel.Weekend_Rates_For_Rewards_Customers*weekend, Hotel_Name = hotel.HotelName})
                                            .GroupBy(x => x.Hotel_Name);
                            foreach (var cost in min_Cost)
                            { 
                                double hotel_Cost = cost.Sum(i => i.weekRate + i.weekendRate);
                                if (total_Cost > hotel_Cost)
                                {
                                    total_Cost = hotel_Cost;
                                    hotel_Cost = 0;
                                    foreach (var item in cost)
                                    {
                                        hotel_Name = item.Hotel_Name;
                                    }
                                }

                            }
                            Console.WriteLine("----------------------------------------------------------------------------------------------");
                            Console.WriteLine($"{hotel_Name}->{total_Cost}");
                            Console.WriteLine("----------------------------------------------------------------------------------------------");
                            break;
                    }
                }
                else
                {
                    try
                    {
                        throw new InvalidHotelReservationException("Invalid Dates");
                    }
                    catch(Exception e) { 
                        Console.WriteLine(e.Message);
                        hotel_Based_OnRange();
                    }
                }
            }
        }

        public string dateCredentials(string date,string message)
        {
            bool isCorrect = true;
            while(true)
            {
                isCorrect= false;
                if(!regex.IsMatch(date))
                {
                    isCorrect = true;
                    try
                    {
                        throw new InvalidHotelReservationException(message);
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                }
                if (isCorrect == false)
                    break;
               Console.WriteLine("Enter again in correct format");
               date=Console.ReadLine();
            }
            return date;
        }

    }
}