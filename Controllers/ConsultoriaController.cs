using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TargetCustomer.Models;
using TargetCustomer.Repository.Interface;

namespace TargetCustomer.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ConsultoriaController : ControllerBase
    {
        private readonly IConsultoriaRepository  _consultoriaRepository;
        public ConsultoriaController(IConsultoriaRepository consultoria)
        {
            _consultoriaRepository = consultoria;       
        }
        /// <summary>
        /// ENDPOINT que retorna todas as consultorias sem nenhum parametro!
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de consultorias sem parametros</response>
        /// <response code="500"> Erro ao obter consultorias</response>
        /// <response code="404"> Consultorias não encontradas</response>
        [HttpGet]
        public async Task<ActionResult<Consultoria>> GetConsultoria()
        {
            try
            {
                return Ok(await _consultoriaRepository.GetConsultorias());
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro obter consultoria desejada!");
            }
        }
        /// <summary>
        /// ENDPOINT que retorna consultorias pelo ID!
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna consultorias pelo ID</response>
        /// <response code="500"> Erro ao obter consultoria</response>
        /// <response code="404"> Consultoria não encontrada</response>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Consultoria>> GetConsultoria(int id)
        {
            try
            {
                var result = await _consultoriaRepository.GetConsultoria(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter consultoria!");
            }
        }
        ///<summary>
        ///ENDPOINT para registrar novas consultorias!
        /// </summary>
        /// <returns></returns>
        /// <response code="201"> Consultoria registrada com sucesso!</response>
        /// <response code="500"> Erro ao obter consultoria</response>
        /// <response code="404"> Consultoria não encontrada</response>
        [HttpPost]
        public async Task<ActionResult<Consultoria>> AddConsultorias([FromBody] Consultoria consultoria)
        {
            try
            {
                if (consultoria == null) return BadRequest();

                var createConsultoria = await _consultoriaRepository.AddConsultoria(consultoria);

                return CreatedAtAction(nameof(GetConsultoria),
                    new { id = createConsultoria.ConsultoriaId }, createConsultoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar a consultoria!");
            }
        }
        /// <summary>
        /// ENDPOINT que atualiza consultoria!
        /// </summary>
        /// <returns></returns>
        /// <response code="204"> Consultoria atualizada com sucesso!</response>
        /// <response code="500"> Erro ao atualizar consultoria!</response>
        /// <response code="404"> Consultoria não atualizada</response>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Consultoria>> UpdateConsultoria([FromBody] Consultoria consultoria)
        {
            try
            {
                var consultoriaUpdate = await _consultoriaRepository.GetConsultoria(consultoria.ConsultoriaId);

                if (consultoriaUpdate == null) return NotFound($"Consultoria com id {consultoria.ConsultoriaId} não encontrada");

                return await _consultoriaRepository.UpdateConsultoria(consultoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar a consultoria!");
            }
        }
        /// <summary>
        /// ENDPOINT que deleta a consultoria!
        /// </summary>
        /// <returns></returns>
        /// <response code="201"> Consultoria deletada</response>
        /// <response code="500"> Erro ao deletar consultoria</response>
        /// <response code="404"> Consultoria não deletada</response>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteConsultoria(int id)
        {
            try
            {
                var consultoriaDelete = await _consultoriaRepository.GetConsultoria(id);

                if (consultoriaDelete == null) return NotFound($"Consultoria com id {id} não encontrado");

                _consultoriaRepository.DeleteConsultoria(id);

                return Ok($"Consultoria com id {id} deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar consultoria!");
            }
        }
    }
}
