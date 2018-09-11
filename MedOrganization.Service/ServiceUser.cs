using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedOrganization.DAL.Model;
using MedOrganization.DAL;

namespace MedOrganization.Service
{
    public class ServiceUser
    {
        public void AddPatient(Patient patient)
        {
            AddToDB.CreatePatient(patient);
        }
        public void AddUser(User user)
        {
            AddToDB.CreateUser(user);
        }
        public void AddOrganization(Organization organization)
        {
            AddToDB.CreateOrganization(organization);
        }

        public void ShowUser(User user)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("ID: {0}\nФИО: {1} {2} {3}\nДата рождения: {4:dd/MM/yyyy}\nЛогин: {5}\nПароль: {6}\nРоль: {7}",
                user.UserId, user.LName, user.FName, user.MName, user.DoB, user.Login, user.Password, user.Role);
            Console.WriteLine(new string('-', 50));
        }
        public void ShowPatient(Patient patient)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("ID: {0}\nФИО: {1} {2} {3}\nДата рождения: {4:dd/MM/yyyy}\nИИН: {5}\nОрганизация: {6}",
                patient.PatientId, patient.LName, patient.FName, patient.MName, patient.DoB, patient.IIN, patient.Organization.Name);
            Console.WriteLine(new string('-', 50));
        }
        public void ShowOrganization(Organization organization)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("ID: {0}\nНаименование: {1}\nАдрес: {2}\nТелефон {3}",
                organization.OrganizationId, organization.Name, organization.Address, organization.Phone);
            Console.WriteLine(new string('-', 50));
        }
    }
}
