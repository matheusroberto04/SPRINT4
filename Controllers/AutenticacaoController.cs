using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TargetCustomer.Dtos;
using TargetCustomer.Services.Autenticacao;

namespace TargetCustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;
        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }
        /// <summary>
        /// ENDPOINT que cadastra os clientes!
        /// </summary>
        /// <returns></returns>
        /// <response code="204"> Cadastro do cliente</response>
        /// <response code="400"> Falha no cadastro</response>
        [HttpPost("Cadastro")]
        public async Task<ActionResult<string>> Cadastro([FromBody] CadastroDto request)
        {   
            return await _autenticacaoService.CadastroAsync(request);
        }
        /// <summary>
        /// ENDPOINT de login dos clientes!
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Cliente inicia a sessao</response>
        /// <response code="400"> Erro ao iniciar sessao</response>
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto request)
        {
            return await _autenticacaoService.LoginAsync(request);
        }
    }
}

