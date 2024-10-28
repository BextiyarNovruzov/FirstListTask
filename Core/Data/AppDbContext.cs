using Core.Helpers.Enums;
using Core.Helpers.Exceptions;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class AppDbContext
    {
        // Hotel List- içində Hotel obyektləri saxlayır və private-dır
        private static List<Hotel> hotels = new List<Hotel>();
        public static void CreatHotel(Hotel hotel)
        {
            hotels.Add(hotel);
        }
  
       
        //- Rooms List - içində Room obyektləri saxlayır və private-dır.
        public static List<Room> rooms = new List<Room>();

        public static bool IsAvialable { get; private set; }
        public static int? personcapacity { get; private set; }
        public static Room Id { get;  set; }

        //- AddRoom() - Parametr olaraq Room obyekti qəbul edib rooms arrayinə əlavə edir.

        public static void AddRoom(Room room)
        {
            rooms.Add(room);
            
        }
        public static void  AddedRooms(params Room[] addedrooms)
        {
            for (int i = 0;i<addedrooms.Length;i++)
            {
                rooms.Add(addedrooms[i]);
            }
        }
        //-FindAllRoom()-Parametr olaraq bir şərt qebul edecek ve gelen serte uygun olaraq otaqlari geriye qaytaracaq;
        public static void FindAllHotel()
        {
        foreach (Hotel hotel in hotels)
            {
                 Console.WriteLine(hotel); 
              
            }

        }

        public static void FindAllRooms()
        {
            foreach(Room room in rooms)
            {
                Console.WriteLine(room);
            }

        }
        // - MakeReservation() - Parametr olaraq nullable int tipindən bir roomId ve musteri sayi qəbul edir
        //əgər roomId null olaraq geriyə NullReferanceException qaytarır əks halda göndərilən roomId-li otaq tapılır
        //IsAvailable dəyəri ve Personal Capacity yoxlanılır
        //əgər IsAvailable dəyəri false-dusa geriyə yuxarıda yaratdığınız NotAvailableException qaytarılır
        //əgər true-dursa Personal Capacityde uygun gelirse həmin room-un IsAvailable dəyəri true olur.


        public static void MakeReservation(int? roomid, int? personcount)    
        {
            for (int i = 0; i < rooms.Count; i++) ;
            {
                try
                {
                    foreach (Room room in rooms)
                    {
                        if (room.Id == roomid)
                        {
                            Console.WriteLine($"{room.Name}");
                        }
                        
                    }
                }
                catch (NullReferanceException ex)
                {

                    Console.WriteLine("Bu id-li otaq tapilmadi."+ex.Message);
                }

                try
                {
                    foreach (Room room in rooms)
                    {
                        
                        
                            if (personcount == personcapacity)
                            {
                                Console.WriteLine("Bu otaq bosdur.");
                            }
                        
                    }
                } 
                catch (NotAvailableException ex)
                {

                    Console.WriteLine("Bu otaq doludur. "+ex.Message); 
                }
               
            }
        }
        public static bool GetHotel(string NAME)
        {
            bool result = false;
            foreach (Hotel hotel in hotels)
            {
                if (NAME == hotel.Name)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
