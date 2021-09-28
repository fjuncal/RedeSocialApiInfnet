namespace rede_social_api_at.Models.Dto
{
    public class ComentarioDTO
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Texto { get; set; }

        public int PostId { get; set; }
    }
}