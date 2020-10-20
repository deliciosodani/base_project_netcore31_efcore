using eClinica.Core.Interfaces;
using eClinica.Models.Atenciones.AtencionesDelDia;
using eClinica.WebApi.Models;
using eClinica.WebApi.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace eClinica.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtencionesController : ControllerBase
    {

        private readonly IAtencionDelDiaService _atencionesDelDia;

        public AtencionesController(IAtencionDelDiaService atencionesDelDia)
        {
            _atencionesDelDia = atencionesDelDia;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ApiResponse>> GetCurrentAsync()
        {
            return Ok(new ApiResponse(true, string.Empty, await _atencionesDelDia.GetAllAsync()));
        }

        [HttpGet]
        [Route("AtencionesDelDia/user/{id}")]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<ApiResponse> GetAllByUserAsync(long id)
        {
            if (id == 0) return BadRequest("ID Vacio");

            var zona = _atencionesDelDia.GetAllByUserAsync(id);
            if (zona == null) return NotFound();

            return Ok(new ApiResponse(true, string.Empty, zona));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ApiResponse>> GetByIdAsync(long id)
        {
            if (id == 0) return BadRequest("ID Vacio");

            var zona = await _atencionesDelDia.GetByIdAsync(id);
            if (zona == null) return NotFound();

            return Ok(new ApiResponse(true, string.Empty, zona));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ApiResponse>> CreateAsync(AtencionDelDiaRequestModel entity)
        {
            var validationResult = await new AtencionDelDiaValidator().ValidateAsync(entity);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            return Ok(new ApiResponse(true, "Atencion del dia creada correctamente.", await _atencionesDelDia.AddAsync(entity)));
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdateAsync(AtencionDelDiaRequestModel entity, long id)
        {
            var validationResult = await new AtencionDelDiaValidator().ValidateAsync(entity);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            await _atencionesDelDia.UpdateAsync(entity, id);
            return Ok(new ApiResponse(true, "Atencion modificada correctamente.", true));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ApiResponse>> DeleteAsync(int id)
        {
            if (id == 0) return BadRequest("ID Vacio");

            await _atencionesDelDia.DeleteAsync(id);
            return Ok(new ApiResponse(true, "Atenciones del dia eliminadas correctamente.", true));
        }
    }
}
