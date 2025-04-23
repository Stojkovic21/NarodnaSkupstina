using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using NarodnaSkupstina;

namespace NarodnaSkupstinaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NarodniPoslanikController : ControllerBase
    {
        [HttpGet]
        [Route("SviPoslanici")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult getPoslanici()
        {
            try
            {
                return new JsonResult(DTOManager.SviPoslanici());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        [Route("DodajPoslanika")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult dodajPoslanika([FromBody]NarodniPoslanikWork poslanik)
        {
            try
            {
                DTOManager.DodajPoslanika(poslanik);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("IzmeniPoslanika")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniPoslanika([FromBody] NarodniPoslanikWork poslanik)
        {
            try
            {
                DTOManager.IzmeniPoslanika(poslanik);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("ObrisiPoslanika/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult obrisiPoslanika([FromRoute(Name ="JMBG")] string JMBG)
        {
            try
            {
                if (long.TryParse(JMBG, out long jmbg))
                { 
                    DTOManager.ObrisiPoslanika(jmbg);
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