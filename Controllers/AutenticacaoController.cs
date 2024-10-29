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

        [HttpPost("Cadastro")]
        public async Task<ActionResult<string>> Cadastro([FromBody] CadastroDto request)
        {
            return await _autenticacaoService.CadastroAsync(request);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto request)
        {
            return await _autenticacaoService.LoginAsync(request);
        }
    }
}
