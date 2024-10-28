using Core.Data;
using Core.Models;
using System.ComponentModel.Design;

namespace ConsoleApp_with_List_
{
    internal class Program
    {
        private static readonly bool f1;
        private static int switch_on;
        private static bool addedhotels;
        private static bool hotels;

        public static string name { get; private set; }

        static void Main(string[] args)
        {
            bool f = false;
            string options;

            do
            {
                Console.WriteLine("-------------------------------------MENU--------------------------------------");
                Console.WriteLine("1-Sisteme giris\r\n0-Sistemden Cixis");
                Console.WriteLine("Seciminizi daxil edin:");

                options = Console.ReadLine();

                switch (options)
                {
                    case "1":



                            Menu:
                            Console.Clear();
                            Console.WriteLine("--Sisteme giris etdiniz.Asagidaki Shortcut-lar movcuddur.");
                            Console.WriteLine("1-Hotel yarat (Hotel yarat secdikden sonra bir otel yaradirsiz. eyni adda hotel ola bilmez :D");
                            Console.WriteLine("2-Butun Hotelleri gormek\n3-Hotel sec (hotelin adini daxil ederek secilecek)\n0-Exit");


                        do
                        {
                           
                            bool HotelList = false;
                            Console.WriteLine("Seciminiz girin:");
                            string options1 = Console.ReadLine();
                            switch (options1)

                            {
                                case "1":
                                  
                                    Console.WriteLine("Yaratmaq istediyiniz Hotel adini daxil edin:");
                                    string name = Console.ReadLine();

                                    Hotel hotel = new Hotel(name);
                                    AppDbContext.CreatHotel(hotel);
                                    Console.WriteLine("Hotel Yaradildi.");
                                    break;
                                case "2":
                                    AppDbContext.FindAllHotel();
                                    break;
                                case "3":
                                    Console.WriteLine("Secdiyiniz Hotelin Adini yazin: ");
                                    string NAME = Console.ReadLine();
                                    AppDbContext.GetHotel(NAME);

                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("--Hotel secildi...");
                                        Console.WriteLine("1.Room yarat\n2.Roomlari gor");
                                        Console.WriteLine("3.Rezervasya et(eger hec bir otaq yoxdursa rezervasya xidmeti islemir)");
                                        Console.WriteLine("4.Evvelki menuya qayit.\n0.Exit");
                                        Console.WriteLine("Seciminiz girin: ");
                                        int option2 = int.Parse(Console.ReadLine());
                                        switch (option2)
                                        {
                                            case 1:
                                                //ps: Name, Price, PersonCapacity olmadan Room obyekti yaratmaq olmaz
                                                Console.WriteLine("room yaratmaq ucun asagidaki infolari doldurun. ");
                                                Console.WriteLine("id daxil edin.");
                                                int id = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Name: ");
                                                string roomname = Console.ReadLine();
                                                Console.WriteLine("Price:");
                                                double price = double.Parse(Console.ReadLine());
                                                Console.WriteLine("PersonCapacity: ");
                                                int personcapacity = int.Parse(Console.ReadLine()); 
                                                Console.WriteLine("Otaq yaradildi.");
                                                Room room = new Room(id,roomname,price,personcapacity);
                                                break;

                                            case 2:
                                                AppDbContext.FindAllRooms();
                                                break;
                                            case 3:
                                                //int? roomid, int? personcount
                                                Console.WriteLine("ID daxil edin: ");
                                                int roomid = int.Parse(Console.ReadLine());
                                                Console.WriteLine("person count elave edin: ");
                                                int personcount=int.Parse(Console.ReadLine());
                                                AppDbContext.MakeReservation(roomid, personcount);

                                                break;
                                            case 4:
                                                Console.WriteLine("Evvelki menuya qayidildi...");
                                                goto Menu;
                                                break;
                                            case 0:
                                                Console.WriteLine("Sistemden cixildi");
                                                f = true;
                                                break;

                                            default:
                                                Console.WriteLine("Invalid option..");
                                                break;
                                        }

                                    } while (!f);


                                    break;
                                case "0":
                                    f = true;
                                    break;

                                default:
                                    Console.WriteLine("Invalid Option...");
                                    break;

                            }
                        } while (!f);
                            
                      





                        break;

                    case "0":
                        f = true;
                        break;


                    default:
                        Console.WriteLine("Invalid Option...");
                        break;
                }
            } while (!f);



        }
    }
}
