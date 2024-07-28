using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Classwork_Exception
{
    internal class Account
    {
        public string post;
        public string password;
        public string Post
        {
            get => post;
            set
            {
                Regex regex = new Regex(@"^[a-zA-Z0-9_]*@[a-zA-Z0-9_]*$");
                if (!(value.Length >= 4 && value.Length <= 50))
                    throw new Exception("Do not correct size [4;50] -> must be");
                if (!regex.IsMatch(value))
                    throw new Exception("Error value must be only number or leter or symbol \"_\"");
                post = value;

            }
        }     
        public string Password { get { return password; }
            set
            {
                Regex regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d_]+$");
                if (value.Length <= 6)
                {
                    throw new Exception("error password size");
                }
                if (!regex.IsMatch(value))
                    throw new Exception("Error passwaord must be more then one number or symbol");
                password = value;
            }
        }
        public Account(string post, string password) { 
            try
            {
                Post = post;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error initialization");
            }
            try
            {
                Password = password;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error initialization");
            } 
        }
        public void InputPost(string post)
        {
            try
            {
                Post = post;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("try again");
            }
        }
        public void InputPassword(string password)
        {
            try
            {
                Password = password;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("try again");
            }
        }
        public void InputInterface()
        {
            while (true)
            {
                Console.Write("Enter post for account :: ");
                try
                {
                    Post = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("try again");
                    continue;
                }
                break;
            }
            Console.WriteLine();

            while (true)
            {
                Console.Write("Enter password for account :: ");
                try
                {
                    Password = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("try again");
                    continue;
                }
                break;
            }
        }
    }
}
