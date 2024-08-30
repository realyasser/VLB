using System.Text.RegularExpressions;

namespace VLN
{
    static class VanityBreaker {

        static HttpClientHandler handler = new HttpClientHandler()
        {
            AllowAutoRedirect = false
        };
        static HttpClient client = new(handler);
        static Regex URLRegex = new Regex("^(https?:\\/\\/)([\\da-z\\.-]+\\.[a-z\\.]{2,6}|[\\d\\.]+)([\\/:?=&#]{1}[\\da-z\\.-]+)*[\\/\\?]?$");

        static string Request(string url)
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[*] Finding the origin....\r");

            HttpResponseMessage response = client.Send(new HttpRequestMessage(HttpMethod.Head, url));

            IEnumerable<String> location;

            if (response.Headers.TryGetValues("Location", out location))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[⤷] The link redirects to: " + location.First());
                return Request(location.First());
            }
            else
            {
                Console.WriteLine("                          ");
                return url;
            }
        }

        public static void FindOrigin(string link)
        {

            if (!URLRegex.IsMatch(link))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[-] Please input a valid link that includes protocol.");
                return;
            }

            string result;
            try { 
                result = Request(link);
            } catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[-] Error: {e.Message}");
                return;
            }
            if (result == link)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[-] The link does not redirect to any website or page.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[+] Final location: {result}");
            }
        }
    }
}