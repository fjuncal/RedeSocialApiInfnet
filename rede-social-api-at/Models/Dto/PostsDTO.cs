using System;
using System.Collections.Generic;

namespace rede_social_api_at.Models.Dto
{
    public class PostsDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Foto { get; set; }
        public string Texto { get; set; }
        public string Autor { get; set; }

        public string Assunto { get; set; }
        public DateTime DataPost { get; set; }
        public List<int> ComentariosId { get; set; }

    }
}