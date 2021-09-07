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
    public class ToDosModel : PageModel
    {
        public List<ToDo> ToDos { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ToDos = new List<ToDo>();
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            var result = await httpClient.GetAsync("todos");
            var resultString = await result.Content.ReadAsStringAsync();

            ToDos = JsonSerializer.Deserialize<List<ToDo>>(resultString);

            return Page();
        }
    }
}
