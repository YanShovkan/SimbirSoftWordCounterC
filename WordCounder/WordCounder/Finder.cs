using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace WordCounder
{
    public class Finder
    {
        private Downloader downloader = new Downloader();
        private Dictionary<string, int> dictionary = new Dictionary<string, int>();
        
        public void FindWords(string url)
        {
            dictionary.Clear();

            string pageHtmlText = downloader.DownloadPage(url);

            if (pageHtmlText != null)
            {
                Console.WriteLine("Страница содержит следующие слова: ");
                
                pageHtmlText = pageHtmlText.Substring(pageHtmlText.IndexOf("<body"));

                while (pageHtmlText.IndexOf("<style") > 0)
                {
                    pageHtmlText = pageHtmlText.Replace(pageHtmlText.Substring(pageHtmlText.IndexOf("<style"), pageHtmlText.IndexOf("</style>") - pageHtmlText.IndexOf("<style>") + "</style>".Length), "\n");
                }

                while (pageHtmlText.IndexOf("<script") > 0)
                {
                    pageHtmlText = pageHtmlText.Replace(pageHtmlText.Substring(pageHtmlText.IndexOf("<script"), pageHtmlText.IndexOf("</script>") - pageHtmlText.IndexOf("<script") + "</script>".Length), "\n");
                }

                pageHtmlText = Regex.Replace(pageHtmlText, @"<(.|\n)*?>", "\n");

                Char[] chars = { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };

                foreach (var word in pageHtmlText.Split(chars))
                {
                    if (word != string.Empty)
                    {
                        if (dictionary.ContainsKey(word))
                        {
                            dictionary[word]++;
                        }
                        else
                        {
                            dictionary.Add(word, 1);
                        }
                    }
                }

                foreach(var word in dictionary.OrderByDescending(word => word.Value))
                {
                    Console.WriteLine(word.Key.ToUpper() + " - " + word.Value);
                }
            }
        }
    }
}
