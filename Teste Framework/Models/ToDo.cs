using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Teste_Framework.Models
{
    public class ToDo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Titulo { get; set; }

        [JsonPropertyName("completed")]
        public bool Concluido { get; set; }

        public string ConcluidoTexto { get
            {
                if (Concluido)
                {
                    return "Sim";
                }
                else
                {
                    return "Não";
                }
            } 
        }
    }
}
