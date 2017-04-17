using System;

namespace AGFeed
{
    /// <summary>
    /// This Is The Implementation Of The IFileReader Interface
    /// </summary>
    public class FileReader : IFileReader
    {
        /// <summary>
        /// Reads In The Files
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public String[] ReadFile(String fileName)
        {
            // Read The File
            return System.IO.File.ReadAllLines(fileName);
        }
    }
}
