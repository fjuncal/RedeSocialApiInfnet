using rede_social_api_at.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using rede_social_api_at.Models.Dto;

namespace rede_social_api_at.Repository.PostRepository
{
    public interface IPostRepository
    {
        void CriarPost(Post post);
        void Delete(Post post);
        Task<IEnumerable<Post>> GetAll();
        Task<IEnumerable<PostsDTO>> GetAll2();
        Post GetById(int id);
        void Update(int id, Post novo);
    }
}