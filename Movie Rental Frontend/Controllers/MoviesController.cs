using Microsoft.AspNetCore.Mvc;
using Movie_Rental_Frontend.Models;
using Newtonsoft.Json;

namespace Movie_Rental_Frontend.Controllers
{
	public class MoviesController : Controller
	{
		private readonly HttpClient _httpClient;
		private string baseUri = "http://localhost:7127/";

		public MoviesController(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<IActionResult> Index()
		{
			ViewData["Title"] = "Available Movies";
			
			var response = await _httpClient.GetAsync($"{baseUri}/api/Movies");

			var json = await response.Content.ReadAsStringAsync();

			var movieList = JsonConvert.DeserializeObject<List<Movie>>(json);

			return View(movieList);
		}
	}
}
