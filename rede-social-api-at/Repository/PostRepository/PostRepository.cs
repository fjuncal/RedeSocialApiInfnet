using rede_social_api_at.DbContextConfig;
using rede_social_api_at.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rede_social_api_at.Models.Dto;

namespace rede_social_api_at.Repository.PostRepository
{
    public class PostRepository : IPostRepository
    {

        private readonly ApiDbContext _dbContext;

        public PostRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        
        public async Task<IEnumerable<Post>> GetAll()
        {
            try
            {
                return await _dbContext.Posts.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<IEnumerable<PostsDTO>> GetAll2()
        {
            try
            {
                var posts = _dbContext.Posts.Select(n => new PostsDTO()
                {
                    Id = n.Id,
                    Assunto = n.Assunto,
                    Autor = n.Autor,
                    Foto = n.Foto,
                    Texto = n.Texto,
                    Titulo = n.Titulo,
                    DataPost = n.DataPost,
                }).ToList();
                return posts;


            }
            catch
            {
                throw;
            }
        }

        public void CriarPost(Post post)
        {
            //var post = new Post();
            //post.Id = create.;
            //post.Texto = create.Author;
            //post.Texto = create.Subject;
           
            post.DataPost = DateTime.Now;

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }
        
        public void CriarPost2(Post post)
        {
            var comentario = _dbContext.Comentarios.Single(c => c.Id == post.Id);
            //var post = new Post();
            //post.Id = create.;
            //post.Texto = create.Author;
            //post.Texto = create.Subject;
           
            post.DataPost = DateTime.Now;

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }

        public Post GetById(int id)
        {
            Post post = _dbContext.Posts.Find(id);
            return post;
        }

        public void Delete(Post post)
        {
            //var post = _dbContext.Posts.Find(id);
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Post novo)
        {
            var post = _dbContext.Posts.Find(id);
            post.Titulo = novo.Titulo;
            post.Foto = novo.Foto;
            post.Texto = novo.Texto;
            post.Autor = novo.Autor;
            post.DataPost = DateTime.Now;
            post.Assunto = novo.Assunto;
            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
        }
    }
}
