using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace Parser
{
    internal class Program
    {
        static void Main(string[] args)
        {
           WebClient webClient = new WebClient();
           Console.WriteLine(DownloadSkin(webClient));
        }

        static string DownloadSkin(WebClient webClient)
        {
            Console.WriteLine("Download begin");
            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    string id = "79" + i;

                    string name = GetNameOfSkin(webClient, id);

                    string path = "aimp.ru/index.php?do=download&sub=catalog&id=80" + id;

                    try
                    {
                        Process.Start(/*"chrome.exe",*/ path);

                        Console.WriteLine("Загрузка" + name + "выполнена");

                        Thread.Sleep(5000);

                    }
                    catch
                    {
                        Console.WriteLine("Не удалось, пшел вон");
                    }
                }
            }
            catch
            {
                return "\nSomething went is wrong";
            }
            return "\nDown comlete";
        }

        static string GetNameOfSkin(WebClient webClient, string id)
        {
            string html = webClient.DownloadString("http://www.aimp.ru/index.php?do=catalog&rec_id=" + id);
            string rightPartOfHtml = html.Substring(html.IndexOf(id) + 5);
            string name = rightPartOfHtml.Substring(0, rightPartOfHtml.IndexOf("<")).Replace(" ", "_");
            return name;
        }
    }
}
