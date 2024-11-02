using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TargetCustomer.Models;
using TargetCustomer.Repository.Interface;

namespace TargetCustomer.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository cliente)
        {
            _clienteRepository = cliente;
        }
        /// <summary>
        /// ENDPOINT que retorna todos os clientes sem nenhum parametro!
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de clientes sem parametros</response>
        /// <response code="500"> Erro ao obter clientes</response>
        /// <response code="404"> Clientes não encontrados</response>
        [HttpGet]
        
        public async Task<ActionResult<Cliente>> GetCliente()
        {
            try
            {
                return Ok(await _clienteRepository.GetClientes());
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os clientes!");
            }
        }
        /// <summary>
        /// ENDPOINT que retorna clientes pelo ID!
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna clientes pelo ID</response>
        /// <response code="500"> Erro ao obter cliente</response>
        /// <response code="404"> Cliente não encontrado</response>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            try
            {
                var result = await _clienteRepository.GetCliente(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter cliente!");
            }
        }
        ///<summary>
        ///ENDPOINT para cadastrar novos clientes!
        /// </summary>
        /// <returns></returns>
        /// <response code="201"> Cliente cadastrado com sucesso!</response>
        /// <response code="500"> Erro ao obter clientes</response>
        /// <response code="404"> Cliente não encontrado</response>
        [HttpPost]
        public async Task<ActionResult<Cliente>> AddClientes([FromBody]Cliente cliente)
        {
            try
            {
                if (cliente == null) return BadRequest();

                var createCliente = await _clienteRepository.AddCliente(cliente);

                return CreatedAtAction(nameof(GetCliente),
                    new { id = createCliente.ClienteId }, createCliente);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao cadastrar");
            }
        }
        /// <summary>
        /// ENDPOINT que atualiza clientes!
        /// </summary>
        /// <returns></returns>
        /// <response code="204"> Cliente atualizado com sucesso!</response>
        /// <response code="500"> Erro ao atualizar cliente!</response>
        /// <response code="404"> Cliente não atualizado</response>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Cliente>> UpdateCliente([FromBody]Cliente cliente)
        {
            try
            {
                var clienteUpdate = await _clienteRepository.GetCliente(cliente.ClienteId);

                if (clienteUpdate == null) return NotFound($"Cliente com id {cliente.ClienteId} não encontrado");

                return await _clienteRepository.UpdateCliente(cliente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro para atualizar o cliente");
            }
        }
        /// <summary>
        /// ENDPOINT que deleta o cliente!
        /// </summary>
        /// <returns></returns>
        /// <response code="201"> Deletar o cliente</response>
        /// <response code="500"> Erro ao deletar cliente</response>
        /// <response code="404"> Cliente não deletado</response>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            try
            {
                var clienteDelete = await _clienteRepository.GetCliente(id);

                if (clienteDelete == null) return NotFound($"Cliente com id {id} não encontrado");

                _clienteRepository.DeleteCliente(id);

                return Ok($"Empregado com id {id} deletado");
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar cliente");
            }
        }
    }
}
