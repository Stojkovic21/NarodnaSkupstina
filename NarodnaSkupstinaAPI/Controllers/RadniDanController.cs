using Microsoft.AspNetCore.Mvc;
using NarodnaSkupstina;

namespace NarodnaSkupstinaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RadniDanController : ControllerBase
    {
        [HttpGet]
        [Route("SviRadniDani")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult sviRadniDani()
        {
            try
            {
                return new JsonResult(DTOManager.SviRadniDani());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        [Route("UnesiRadniDan")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UnesiRadniDan([FromQuery(Name ="radniDan")] string radniDan)
        {
            try
            {
                if (DateTime.TryParse(radniDan, out DateTime radniDan2))
                {
                    DTOManager.UnesiRadniDan(radniDan2);
                    return Ok();
                }
                else { return BadRequest("Unet je los font datuma"); }
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("ObrisiRadniDan/{datum}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult obrisiOrganizaciju([FromRoute(Name = "datum")] string datum)
        {
            try
            {
                if (DateTime.TryParse(datum, out DateTime Datum))
                {
                    DTOManager.ObrisiRadniDan(Datum);
                }
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}
