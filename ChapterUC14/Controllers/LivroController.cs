using ChapterUC14.Interfaces;
using ChapterUC14.Models;
using ChapterUC14.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterUC14.Controllers
{
    [Produces ("application/json")]//formato de resposta do tipo json.
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _iLivroRepository;
        public LivroController(ILivroRepository iLivro) 
        {
            _iLivroRepository = iLivro;
        }

        [HttpGet]

        public IActionResult Listar()
        {
            try{
                return Ok(_iLivroRepository.Ler());
                
            }catch(Exception error){

                throw new Exception(error.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles ="7")] //O parâmetro Roles define quem tem a autorização para acessar a funcionalidade.
        public IActionResult Cadastrar(Livro livro)
        {
            try 
            {
                _iLivroRepository.Cadastrar(livro);
                return Ok(livro);

            } catch (Exception e){
                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _iLivroRepository.Deletar(id);
                return StatusCode(204);
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPut]
        public IActionResult Update(int id, Livro livro)
        {
            try
            {
                _iLivroRepository.Atualizar(id, livro);
                return StatusCode(204);


            }
            catch(Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Livro livro = _iLivroRepository.BuscarPorId(id);
                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
