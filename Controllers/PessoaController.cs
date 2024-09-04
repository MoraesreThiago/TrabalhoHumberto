using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class PessoaController : Controller
    {
        private static List<Pessoa> pessoasList = new List<Pessoa>();



        [HttpPost]
        [Route("Adicionar")]
        public IActionResult Adicionar(Pessoa dados)
        {
            pessoasList.Add(dados);
            return Ok($"Pessoa(a) {dados.Nome} adicionado com sucesso.");
        }

        [HttpDelete]
        [Route("Remover")]
        public IActionResult Remover (string cpf)
        {
            var pessoaPesquisada = pessoasList.Where(a => a.CPF == cpf).FirstOrDefault();

            if (pessoaPesquisada is null)
                return NotFound($"Pessoa com o {cpf} não encontrado.");

            pessoasList.Remove(pessoaPesquisada);

            return NoContent();
        }


        [HttpGet]
        [Route("ObterTodos")]
        public IActionResult ObterTodos()
        {
            return Ok(pessoasList);
        }

        [HttpPut]
        [Route("Atualizar/{cpf}")]
        public IActionResult Atualizar(string cpf, Pessoa pessoaatualizada) 
        {
            var PessoaPesquisado = pessoasList.Where(a => a.CPF == cpf).FirstOrDefault();

            if (PessoaPesquisado is null)
                return NotFound($"Pessoa com cpf {cpf} não encontrado.");

            PessoaPesquisado.Nome = pessoaatualizada.Nome;
            PessoaPesquisado.CPF = pessoaatualizada.CPF;
            PessoaPesquisado.Altura = pessoaatualizada.Altura;
            PessoaPesquisado.Peso = pessoaatualizada.Peso;

            return NoContent();
        }

        [HttpGet]
        [Route("ObterPorCPF")]
        public IActionResult ObterPorCPF(string cpf)
        {
            var pessoaPesquisada = pessoasList.Where(a => a.CPF == cpf).FirstOrDefault();

            if (pessoaPesquisada is null)
                return NotFound($"Pessoa com o {cpf} não encontrado.");
            
            return Ok(pessoaPesquisada);

        }



    }
}