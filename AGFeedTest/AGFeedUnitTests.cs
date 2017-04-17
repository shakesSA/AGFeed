using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGFeedTest
{
    [TestClass]
    public class AGFeedUnitTests
    {
        [TestMethod]
        public void CanTheUserFileBeRead()
        {
            AGFeed.FileReader fileReader = new AGFeed.FileReader();
            Assert.IsNotNull(fileReader.ReadFile(@"/DataFiles/users.txt"));
        }

        [TestMethod]
        public void CanTheweetFileBeRead()
        {
            AGFeed.FileReader fileReader = new AGFeed.FileReader();
            Assert.IsNotNull(fileReader.ReadFile(@"/DataFiles/tweets.txt"));
        }

        [TestMethod]
        public void UserRecordIsValidated()
        {
            AGFeed.LoadInputs loadInputs = new AGFeed.LoadInputs();
            String userRec = "Ward follows Alan";
            Assert.IsTrue(loadInputs.ValidatUserRecord(userRec));
        }
        
        [TestMethod]
        public void TweetRecordIsValidated()
        {
            AGFeed.LoadInputs loadInputs = new AGFeed.LoadInputs();
            String tweetRec = "Alan> Tweet validation";
            Assert.IsTrue(loadInputs.ValidatTweetRecord(tweetRec));
        }
    }
}
