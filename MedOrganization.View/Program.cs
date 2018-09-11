using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedOrganization.DAL;
using MedOrganization.DAL.Model;
using MedOrganization.Service;
using GeneratorName;

namespace MedOrganization.View
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            bool inProgress = true;
            while (inProgress)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("\t\tМЕДИЦИНСКАЯ ОРГАНИЗАЦИЯ");
                Console.WriteLine(new string('-', 50));
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("\t\tВыберите пункт меню:");
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("1. Добавить User");
                Console.WriteLine("2. Добавить Organization");
                Console.WriteLine("3. Добавить Patient");
                Console.WriteLine("4. Получить все User");
                Console.WriteLine("5. Получить все Organization");
                Console.WriteLine("6. Получить все Patient");
                Console.WriteLine("7. Выход");
                Console.ForegroundColor = color;

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t1. Добавить User");
                            Console.WriteLine(new string('-', 50));

                            ServiceUser serviceUser = new ServiceUser();
                            User user = new User();

                            Console.Write("Введите имя: ");
                            user.FName = Console.ReadLine();
                            Console.Write("Введите фамилию: ");
                            user.LName = Console.ReadLine();
                            Console.Write("Введите отчество (при наличии): ");
                            user.MName = Console.ReadLine();
                            user.DoB = CreateDoB();
                            Console.Write("Назначьте роль: ");
                            user.Role = CreateRole();
                            Console.Write("Введите логин: ");
                            user.Login = Console.ReadLine();
                            Console.Write("Введите пароль: ");
                            user.Password = Console.ReadLine();

                            AddToDB.CreateUser(user);

                            Console.WriteLine(new string('-', 50));
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Создан новый User");
                            Console.ForegroundColor = color;
                            serviceUser.ShowUser(user);
                        }
                        break;

                    case 2:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t2. Добавить Organization");
                            Console.WriteLine(new string('-', 50));

                            ServiceUser serviceUser = new ServiceUser();
                            Organization organization = new Organization();

                            Console.Write("Введите название организации: ");
                            organization.Name = Console.ReadLine();
                            Console.Write("Введите адрес организации: ");
                            organization.Address = Console.ReadLine();
                            Console.Write("Введите телефон организации: ");
                            organization.Phone = Console.ReadLine();

                            AddToDB.CreateOrganization(organization);

                            Console.WriteLine(new string('-', 50));
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Создана новая Organization");
                            Console.ForegroundColor = color;
                            serviceUser.ShowOrganization(organization);
                        }
                        break;

                    case 3:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t3. Добавить Patient");
                            Console.WriteLine(new string('-', 50));

                            ServiceUser serviceUser = new ServiceUser();
                            Patient patient = new Patient();
                            User user = new User();
                            Organization organization = new Organization();

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Выберите User по Id: ");
                            Console.ForegroundColor = color;

                            foreach (var item in AddToDB.ReturnAllUsers())
                            {
                                serviceUser.ShowUser(item);
                            }

                            int id = Convert.ToInt32(Console.ReadLine());
                            foreach (User item in AddToDB.ReturnAllUsers())
                            {
                                if (item.UserId == id)
                                {
                                    user = item;
                                    break;
                                }
                            }
                            patient.FName = user.FName;
                            patient.LName = user.LName;
                            patient.MName = user.MName;
                            patient.IIN = CreateIIN();
                            patient.DoB = user.DoB;

                            Console.WriteLine(new string('-', 50));
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Выберите Organization по Id: ");
                            Console.ForegroundColor = color;

                            Console.WriteLine(new string('-', 50));
                            foreach (var item in AddToDB.ReturnAllOrganization())
                            {
                                serviceUser.ShowOrganization(item);
                            }

                            int idOrg = Convert.ToInt32(Console.ReadLine());
                            foreach (Organization item in AddToDB.ReturnAllOrganization())
                            {
                                if (item.OrganizationId == idOrg)
                                {
                                    organization = item;
                                    break;
                                }
                            }

                            patient.Organization = organization;

                            AddToDB.CreatePatient(patient);

                            Console.WriteLine(new string('-', 50));
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Создан новый Patient");
                            Console.ForegroundColor = color;
                            serviceUser.ShowPatient(patient);
                        }
                        break;

                    case 4:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t4. Получить все User");
                            Console.WriteLine(new string('-', 50));

                            ServiceUser serviceUser = new ServiceUser();

                            foreach (var user in AddToDB.ReturnAllUsers())
                            {
                                serviceUser.ShowUser(user);
                            }

                        }
                        break;

                    case 5:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t5. Получить все Organization");
                            Console.WriteLine(new string('-', 50));

                            ServiceUser serviceUser = new ServiceUser();

                            foreach (var org in AddToDB.ReturnAllOrganization())
                            {
                                serviceUser.ShowOrganization(org);
                            }

                        }
                        break;
                    case 6:
                        {

                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t6. Получить все Patient");
                            Console.WriteLine(new string('-', 50));

                            ServiceUser serviceUser = new ServiceUser();
                            foreach (Patient pat in AddToDB.ReturnAllPatient())
                            {
                                serviceUser.ShowPatient(pat);
                            }

                        }
                        break;
                    case 7:
                        {

                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t\t7. Выход");
                            Console.WriteLine(new string('-', 50));
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Спасибо!");
                            Console.ForegroundColor = color;
                            inProgress = false;
                            Console.WriteLine(new string('-', 50));
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Выберите пункт меню");
                        }
                        break;
                }
            }
        }

        static void CreatePatientList()
        {

            Random random = new Random();
            Generator generator = new Generator();

            int rr = random.Next(1, 10);
            for (int i = 0; i < rr; i++)
            {
                Patient patient = new Patient();
                string name = generator.GenerateDefault(Gender.man);
                name = name.Replace("<center><b><font size=7>", "");
                name = name.Replace("</font></b></center>", "");
                name = name.Replace("\n", "");
                string[] fullname = name.Split(' ');
                patient.FName = fullname[0];
                patient.LName = fullname[1];
                patient.DoB = DateTime.Now.AddYears((random.Next(20, 90) * -1));

                AddToDB.CreatePatient(patient);
            }
        }
        static DateTime CreateDoB()
        {
            Random random = new Random();
            return DateTime.Now.AddYears((random.Next(20, 90) * -1));
        }
        static int CreateIIN()
        {
            Random random = new Random();
            return random.Next(111111111, 999999999);
        }
        static Role CreateRole()
        {
            Role role = new Role();

            Console.Write("Выберите роль:\n" +
                "1. Admin\n" +
                "2. User\n" +
                "> ");
            int option = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                switch (option)
                {
                    case 1:
                        {
                            return Role.Admin;
                        }
                    case 2:
                        {
                            return Role.User;
                        }

                    default:
                        {
                            Console.WriteLine("Сделайте выбор еще раз.");
                        }
                        break;
                }
            }
        }
    }
}
