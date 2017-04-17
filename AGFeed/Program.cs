using System;
using System.Collections.Generic;
using System.Linq;

namespace AGFeed
{
    class Program
    {
        /// <summary>
        /// Main method of the application
        /// </summary>
        static void Main(string[] args)
        {
            // Local Variables
            IFileReader fileReader = new FileReader();
            ILoadInputs loadInputs = new LoadInputs();
            String[] users = null;
            String[] tweets = null;

            try
            {
                // Read User Records
                users = fileReader.ReadFile(@"DataFiles/user.txt");

                // Read Tweet Records
                tweets = fileReader.ReadFile(@"DataFiles/tweet.txt");
            
                // Load User Accounts
                List<User> userList = loadInputs.LoadAllUsers(users);

                // Load Tweets To User Account
                loadInputs.LoadAllTweets(userList, tweets);

                // Write User And Tweets To Console
                List<User> sortedUsersList =  userList.OrderBy(x => x.Handle).ToList();
                foreach (var user in sortedUsersList)
                {
                    Console.WriteLine(user.Handle + "\n");
                    foreach (var tweet in user.Tweets)
                    {
                        Console.WriteLine(tweet + "\n");
                    }
                }
            }
            catch (Exception e)
            {
                HandleException(e.Message);
            }

            // Wait For User Inut To Exit Application
            Console.WriteLine("\nPlease press Enter to exit the program\n");
            Console.Read();
        }

        /// <summary>
        /// This Method handles The Exceptions
        /// </summary>
        /// <param name="exception"></param>
        public static void HandleException(String exception)
        {
            // Write Exception To The Console
            Console.WriteLine("Program terminating : " + exception);
            Console.WriteLine("\nPlease press Enter to exit the program\n");

            Console.Read();
            System.Environment.Exit(999);
        }
    }
}
