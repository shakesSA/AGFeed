using System;

namespace AGFeed
{
    /// <summary>
    /// This Is The Interface For File Read Functionality
    /// </summary>
    interface IFileReader
    {
        /// <summary>
        /// Reads In The Files
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        String[] ReadFile(String fileName);
    }
}
