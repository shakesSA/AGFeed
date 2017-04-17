using System;
using System.Collections.Generic;
using System.IO;

namespace AGFeed
{
    /// <summary>
    /// This Is The Implementation Of The ILoadInputs Interface
    /// </summary>
     public class LoadInputs : ILoadInputs
    {
        /// <summary>
        /// Loads The User Data
        /// </summary>
        /// <param name="users"></param>
        /// <returns> List Of User Objects </returns>
        List<User> ILoadInputs.LoadAllUsers(string[] users)
        {
            // Local Variables
            List<User> userList = new List<User>();
            List<String> followersList;
            List<String> currentFollowersList = new List<String>();

            // Use Dictionary as a map.
            var userMap = new Dictionary<String, List<String>>();

            foreach (var user in users)
            {
                followersList = new List<String>();

                // Validate User Record
                if(ValidatUserRecord(user))
                {
                    // Split String To Obtain User Date
                    String[] userDetails = user.Split(new string[] { "follows" }, StringSplitOptions.None);

                    var handle = userDetails[0].Trim();
                    String[] followers = userDetails[1].Split(',');

                    // Create List Of Followers
                    foreach (var following in followers)
                    {
                        followersList.Add(following.Trim());
                    }

                    // Add User And Followers To Map
                    try
                    {
                        if (!userMap.ContainsKey(handle))
                        {
                            userMap.Add(handle, followersList);
                            foreach (var follower in followersList)
                            {
                                if (!userMap.ContainsKey(follower))
                                {
                                    userMap.Add(follower, null);
                                }
                            }
                        }
                        else
                        {
                            foreach (var follower in followersList)
                            {
                                userMap.TryGetValue(handle, out currentFollowersList);
                                if (currentFollowersList == null)
                                {
                                    currentFollowersList = new List<String>();
                                }
                                if (!currentFollowersList.Contains(follower))
                                {
                                    currentFollowersList.Add(follower);
                                }
                                userMap[handle] = currentFollowersList;
                                if (!userMap.ContainsKey(follower))
                                {
                                    userMap.Add(follower, null);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error - " + e.Message);
                        throw new Exception("Error adding user details");
                    }
                }
            }

            // Read Map And Create User for Each Entry
            foreach (KeyValuePair<String, List<String>> singleUser in userMap)
            {
                User newUser = new User(singleUser.Key, singleUser.Value);
                userList.Add(newUser);
            }

            // Return List Of User
            return userList;
        }

        /// <summary>
        /// Loads The Tweet Data
        /// </summary>
        /// <param name="users"></param>
        /// <param name="tweets"></param>
        void ILoadInputs.LoadAllTweets(List<User> users, string[] tweets)
        {
            foreach (var tweet in tweets)
            {
                // Validate Tweet Record
                if(ValidatTweetRecord(tweet))
                {
                    // Split String To Obtain Tweet Date
                    String[] tweetDetails = tweet.Split(new string[] { "> " }, StringSplitOptions.None);

                    var handle = tweetDetails[0].Trim();

                    // Format Tweet
                    String tweetLine = String.Format("\t@{0}: {1}", handle, tweetDetails[1].Trim());

                    // Add Tweet To The User And All Followers
                    try
                    {
                        foreach (var user in users)
                        {
                            if (user.Handle == handle)
                            {
                                user.Tweets.Add(tweetLine);
                            }
                            foreach (var following in user.Following)
                            {
                                if (following == handle)
                                {
                                    user.Tweets.Add(tweetLine);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error adding Tweets: " + e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Validates The User Record
        /// </summary>
        /// <param name="userRec"></param>
        /// <returns> Valid User Record </returns>
        public bool ValidatUserRecord(String userRec)
        {
            bool validUserRec = false;

            String[] userdetails = userRec.Split(new string[] { " " }, StringSplitOptions.None);

            // Validate That The User Record Is In The Correct Format - Contains "Follows" In 2nd Position
            if (!userdetails[1].Equals("follows"))
            {
                WrtieErrorLog("Invalid User Record: " + userRec);
            }
            else
            {
                validUserRec = true;
            }

            // Return Valid User Record
            return validUserRec;
        }

        /// <summary>
        /// Validates The Tweet Record
        /// </summary>
        /// <param name="tweetRec"></param>
        /// <returns> Valid Tweet Record </returns>
        public bool ValidatTweetRecord(String tweetRec)
        {
            bool validTweetRec = false;

            String[] tweetdetails = tweetRec.Split(new string[] { "> " }, StringSplitOptions.None);

            // Validate That The Tweet Record Is In The Correct Format
            // Contains "> "
            if (tweetdetails.Length < 2 || tweetdetails.Length > 2)
            {
                WrtieErrorLog("Invalid Tweet Record, Incorrect format: " + tweetRec);
            }
            else
            // Is Less Than 140 Characters
            if (tweetdetails[1].Length > 140)
            {
                WrtieErrorLog("Invalid Tweet Record, length is > 140: " + tweetRec);
            }
            else
            {
                validTweetRec = true;
            }

            // Return Valid Tweet Record
            return validTweetRec;
        }

        /// <summary>
        /// Prints The Error Record To The Error Log File
        /// </summary>
        /// <param name="errorMessage"></param>
        private void WrtieErrorLog(String errorMessage)
        {
            string filePath = @"DataFiles/error.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Error Record:" + errorMessage);
            }
        }
     }
}
