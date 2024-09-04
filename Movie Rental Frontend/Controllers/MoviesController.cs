using Microsoft.AspNetCore.Mvc;
using Movie_Rental_Frontend.Models;

using Newtonsoft.Json;
using System.Text;

namespace MovieRentalFrontend.Controllers
{
	public class MoviesController : Controller
	{
		private readonly HttpClient _client;
		private string baseUri = "https://localhost:7127/";
		public MoviesController(HttpClient client)
		{
			_client = client;
		}

		public async Task<IActionResult> Index()
		{
			ViewData["Title"] = "Available Movies";

			// Anropar APIets endpoint för att hämta alla filmer
			var response = await _client.GetAsync($"{baseUri}api/Movies");

			// läser av JSON som en string från bodyn
			var json = await response.Content.ReadAsStringAsync();

			// Omvandlar JSON till ett objekt av typen List<Movie>();
			var movieList = JsonConvert.DeserializeObject<List<Movie>>(json);

			// returnera listan till vyn som tar emot det för att arbeta med datan.
			return View(movieList);
		}

		
	}
}