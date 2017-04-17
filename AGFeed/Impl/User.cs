using System;
using System.Collections.Generic;

namespace AGFeed
{
    /// <summary>
    /// This Class Represents A User
    /// </summary>
    class User
    {
        // User Handle
        private String handle;
        // User Followers
        private List<String> followers;
        // User Followings
        private List<String> following;
        // User Tweets
        private List<String> tweets;

        // Constructor
        public User()
        {

        }

        // Constructor
        public User(String handle, List<String> following)
        {
            this.handle = handle;
            this.followers = new List<String>();
            if(following == null)
            {
                this.following = new List<String>();
            }
            else
            {
                this.following = following;
            }
            this.tweets = new List<String>();
        }

        /// <summary>
        /// Gets And Sets handle
        /// </summary>
        public String Handle
        {
            get { return handle; }
            set { handle = value; }
        }

        /// <summary>
        /// Gets And Sets followers
        /// </summary>
        public List<String> Followers
        {
            get { return followers; }
            set { followers = value; }
        }

        /// <summary>
        /// Gets And Sets following
        /// </summary>
        public List<String> Following
        {
            get { return following; }
            set { following = value; }
        }

        /// <summary>
        /// Gets And Sets tweets
        /// </summary>
        public List<String> Tweets
        {
            get { return tweets; }
            set { tweets = value; }
        }
    }
}
