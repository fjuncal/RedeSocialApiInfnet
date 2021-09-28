using rede_social_api_at.DbContextConfig;
using rede_social_api_at.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rede_social_api_at.Models.Dto;

namespace rede_social_api_at.Repository.ComentarioRepository
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly ApiDbContext _dbContext;

        public ComentarioRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Comentario> GetAll()
        {
            var coments = _dbContext.Comentarios.ToList();
            return coments;
        }

        public void CriarComentario(Comentario comentario)
        {
            _dbContext.Comentarios.Add(comentario);
            _dbContext.SaveChanges();
        }
        
        /*public void CriarComentarioComPosts(ComentarioDTO comentario)
        {
            var comentarioCadastrar = new Comentario()
            {
                Autor = comentario.Autor,
                Texto = comentario.Texto,
                PostId = comentario.PostId
                
            };
            _dbContext.Comentarios.Add(comentarioCadastrar);
            _dbContext.SaveChanges();
        }*/

        public Comentario GetById(int id)
        {
            var coment = _dbContext.Comentarios.Find(id);
            return coment;
        }

        public void Delete(Comentario comentario)
        {
            _dbContext.Remove(comentario);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Comentario novo)
        {
            var coment = _dbContext.Comentarios.Find(id);
            coment.Autor = novo.Autor;
            coment.Texto = novo.Texto;
            _dbContext.SaveChanges();
        }
    }
}
