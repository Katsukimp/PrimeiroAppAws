using Microsoft.AspNetCore.Mvc;
using PrimeiroAppAws.Controllers.V1.Base;
using PrimeiroAppAws.Domain.Entities;
using PrimeiroAppAws.Domain.Interfaces;
using PrimeiroAppAws.Infrastructure.Data.Commom.Interfaces;

namespace PrimeiroAppAws.Controllers.V1
{
    public class PostController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;

        public PostController(IUnitOfWork unitOfWork, IPostRepository postRepository)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id)
                return BadRequest("O Código informado é inválido.");

            try
            {
                var blog = await _postRepository.GetAsync(id, cancellationToken);

                if (blog is null)
                    return BadRequest("Nenhum registro com esse código foi encontrado.");

                return Ok(blog);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao buscar informações do post.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAllAsync(cancellationToken);

            return posts.Any() is false ? BadRequest("Nenhum registro encontrado") : Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync([FromBody] Post post, CancellationToken cancellationToken)
        {
            if (post is null)
                return BadRequest("Nenhuma post foi enviado para ser criado.");


            try
            {
                await _postRepository.AddAsync(post, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                return Created("Created", post);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                return BadRequest("Não foi possível criar o post.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostAsync([FromBody] Post post, CancellationToken cancellationToken)
        {
            if (post is null)
                return BadRequest("Nenhuma post foi enviado para ser criado.");

            try
            {
                await _postRepository.UpdateAsync(post, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                return Ok("Registro atualizado com sucesso.");
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                return BadRequest("Não foi possível atualizar as informações do post.");
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletePostAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id)
                return BadRequest("O Código informado é inválido.");

            var post = await _postRepository.GetAsync(id, cancellationToken);

            if (post is null)
                return BadRequest("Nenhum registro com esse código foi encontrado.");

            try
            {
                await _postRepository.DeleteAsync(post, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                return Ok("Registro deletado com sucesso.");
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                return BadRequest("Ocorreu um erro ao excluir o post.");
            }
        }
    }
}
