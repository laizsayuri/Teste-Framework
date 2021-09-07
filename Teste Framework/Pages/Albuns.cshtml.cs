using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teste_Framework.Models;

namespace Teste_Framework.Pages
{
    public class AlbunsModel : PageModel
    {
        public List<Album> Albuns { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Albuns = new List<Album>();
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            var result = await httpClient.GetAsync("albums");
            var resultString = await result.Content.ReadAsStringAsync();

            Albuns = JsonSerializer.Deserialize<List<Album>>(resultString);

            return Page();
        }
    }
}
