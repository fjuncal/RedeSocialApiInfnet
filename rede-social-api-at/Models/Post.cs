using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rede_social_api_at.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Foto { get; set; }
        public string Texto { get; set; }
        public string Autor { get; set; }

        public string Assunto { get; set; }
        public DateTime DataPost { get; set; }

        /*
        public List<Comentario> Comentarios { get; set; }
        */

    }
}
