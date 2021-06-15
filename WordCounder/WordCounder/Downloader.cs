using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WordCounder
{
    public class Downloader
    {
        public string DownloadPage(string pageUrl)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    return webClient.DownloadString(pageUrl);
                }
                catch
                {
                   Console.WriteLine("Какие-то проболемы со ссылкой");
                   return null;
                }
            }
        }

    }
}
