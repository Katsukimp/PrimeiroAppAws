using Microsoft.AspNetCore.Mvc;
using PrimeiroAppAws.Domain.Entities;
using PrimeiroAppAws.Domain.Interfaces;
using PrimeiroAppAws.Infrastructure.Data.Commom.Interfaces;

namespace PrimeiroAppAws.Controllers.V1
{
    [ApiController]
    [Route("public/api/[Controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlogRepository _blogRepository;

        public BlogController(IUnitOfWork unitOfWork, IBlogRepository blogRepository)
        {
            _unitOfWork = unitOfWork;
            _blogRepository = blogRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id)
                return BadRequest("O Código informado é inválido.");

            try
            {
                var blog = await _blogRepository.GetAsync(id, cancellationToken);

                if (blog is null)
                    return BadRequest("Nenhum registro com esse código foi encontrado.");

                return Ok(blog);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao buscar informações do blog.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogAsync([FromBody] Blog blog, CancellationToken cancellationToken)
        {
            if (blog is null)
                return BadRequest("Nenhuma blog foi enviado para ser criado.");


            try
            {
                await _blogRepository.AddAsync(blog, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                return Created("Created", blog);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                return BadRequest("Não foi possível criar o blog.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlogAsync([FromBody] Blog blog, CancellationToken cancellationToken)
        {
            if (blog is null)
                return BadRequest("Nenhuma blog foi enviado para ser criado.");

            try
            {
                await _blogRepository.UpdateAsync(blog, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                return Ok("Registro atualizado com sucesso.");
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                return BadRequest("Não foi possível atualizar as informações do blog.");
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBlogAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id)
                return BadRequest("O Código informado é inválido.");

            var blog = await _blogRepository.GetAsync(id, cancellationToken);

            if (blog is null)
                return BadRequest("Nenhum registro com esse código foi encontrado.");

            try
            {
                await _blogRepository.DeleteAsync(blog, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                return Ok("Registro deletado com sucesso.");
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                return BadRequest("Ocorreu um erro ao excluir o blog.");
            }
        }
    }
}
