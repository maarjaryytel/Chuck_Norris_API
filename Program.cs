using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nancy.Json;

namespace Jack_API
{
	class Program
	{
		static void Main(string[] args)
		{
			ShowCategories();
			Console.WriteLine("Vali kategooria: ");			
			string userCategory = Console.ReadLine();
			string userCategoryUrl = "https://api.chucknorris.io/jokes/random?category=" + userCategory; 

			userCategory();

			Console.ReadLine();
		}

		public static void ShowRandomJoke()
		{
			string randomJokeUrl = "https://api.chucknorris.io/jokes/random";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(randomJokeUrl);
			request.Method = "GET";

			var webResponce = request.GetResponse();
			var webStream = webResponce.GetResponseStream();

			using (var responceReader = new StreamReader(webStream))
			{

				var responce = responceReader.ReadToEnd();
				Joke randomJoke = JsonConvert.DeserializeObject<Joke>(responce);
				Console.WriteLine(randomJoke.Value);
			}
		}
		public static void ShowCategories()
		{
			string categoryUrl = "https://api.chucknorris.io/jokes/categories";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(categoryUrl);
			request.Method = "GET";

			var webResponce = request.GetResponse();
			var webStream = webResponce.GetResponseStream();

		    using (var responceReader = new StreamReader(webStream))
			{
						
			var responce = responceReader.ReadToEnd();						
			Console.WriteLine(responce);
									
			JavaScriptSerializer ser = new JavaScriptSerializer(); 
																			   
			var categories = ser.Deserialize<List<string>>(responce); 
																				  
			foreach (string category in categories)
				{
					Console.WriteLine(category);
				}
			}
		}

		public static void userCategory(string category)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(category);
			request.Method = "GET";

			var webResponce = request.GetResponse();
			var webStream = webResponce.GetResponseStream();

			using (var responceReader = new StreamReader(webStream))
			{
				var responce = responceReader.ReadToEnd();
				Joke randomJoke = JsonConvert.DeserializeObject<Joke>(responce);
				Console.WriteLine(randomJoke.Value);

			}
		}
	}
}