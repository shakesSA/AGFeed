using System;
using System.Collections.Generic;

namespace AGFeed
{
    /// <summary>
    /// This Is The Interface For Input Loading
    /// </summary>
    interface ILoadInputs
    {
        /// <summary>
        /// Loads The User Data
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        List<User> LoadAllUsers(String[] users);

        /// <summary>
        /// Loads The Tweet Data
        /// </summary>
        /// <param name="users"></param>
        /// <param name="tweets"></param>
        void LoadAllTweets(List<User> users, String[] tweets);
    }
}
