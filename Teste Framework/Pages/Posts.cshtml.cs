using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teste_Framework.Models;

namespace Teste_Framework.Pages
{
    public class PostsModel : PageModel
    {
        public List<Post> Posts { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Posts = new List<Post>();
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            var result = await httpClient.GetAsync("posts");
            var resultString = await result.Content.ReadAsStringAsync();

            Posts = JsonSerializer.Deserialize<List<Post>>(resultString);

            return Page();
        }
    }
}
