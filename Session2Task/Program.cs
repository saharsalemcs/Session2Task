using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2Task
{
    internal class Program
    {
        static void MasterFun()
        {
            Contact contactManager = new Contact();   // instance from class Contact => to apply functionalities
            int choice;

            do
            {
                Console.WriteLine("\n------------------Contact Management System------------------");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Show All Contacts");
                Console.WriteLine("5. Exit\n");

                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1: 
                        // Add New Contact
                        User newUser = new User();
                        Console.Write("Enter first name: ");
                        newUser.FName = Console.ReadLine();
                        Console.Write("Enter last name: ");
                        newUser.LName = Console.ReadLine();
                        Console.Write("Enter phone number: ");
                        newUser.PhoneNumber = Console.ReadLine();
                        contactManager.AddContact(newUser);
                        break;
                  
                    case 2:
                        // Edit Contact
                        Console.Write("Enter phone number to search for: ");
                        string newPhone = Console.ReadLine();
                        contactManager.EditContact(newPhone);
                        break;

                        case 3:
                        // Delete Contact
                        Console.Write("Enter phone number to search for: ");
                        string deletePhone = Console.ReadLine();    
                        contactManager.DeleteContact(deletePhone);
                        break;

                        case 4:
                        // Show All Contacts
                        contactManager.DisplayAllContacts();
                        break;

                        case 5:
                        // Exit 
                        Console.WriteLine("Exiting Contact Management System.. ");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice, Try agian.");
                        break;
                }

            } while (choice != 5);

            
        }
        static void Main(string[] args)
        {
            MasterFun();
        }
    }

    // class user to store contacr details 
    public class User
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }

        public void DisplayContactDetails()
        {
            Console.WriteLine($"Name: {FName} {LName}, Phone: {PhoneNumber}");
        }


    }
    
    // class Contact to manage the collection of users
    public class  Contact 
    {
        private List<User> users = new List<User>();
        
        // Method to add a new contact:)
        public void AddContact(User user)
        {

            users.Add(user);
            Console.WriteLine("Contact Added Successfully!");
        }

        // Method to edit an existing contact by phone number:)
        public void EditContact(string phoneNum)
        {
            User user = users.Find(u => u.PhoneNumber == phoneNum);
            if (user != null)
            {
                Console.Write("Enter new first name: ");
                user.FName = Console.ReadLine();
                Console.Write("Enter new Last name: ");
                user.LName = Console.ReadLine();
                Console.Write("Enter new Phone Number: ");
                user.PhoneNumber = Console.ReadLine();
                Console.WriteLine("Contact Updated Succesfully!");
            }
            else
            {
                Console.WriteLine("this contact is not found!");
            }
        }

        // Method to delete the contact by phone number:)
        public void DeleteContact(string phoneNum)
        {
            User user = users.Find(u => u.PhoneNumber == phoneNum);
            if (user != null)
            {
                users.Remove(user);
                Console.WriteLine("Contact Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("this contact is not found!");
            }
        }

        // Method to Display all contacts 
        public void DisplayAllContacts()
        {
            if (users.Count > 0)
            {
                Console.WriteLine("All Contacts: ");
                foreach (User user in users)
                {
                    user.DisplayContactDetails();
                }
            }
            else
            {
                Console.WriteLine("No Contacts To Display!");
            }
        }
    }
}
