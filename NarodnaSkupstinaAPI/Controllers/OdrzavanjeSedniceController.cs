using Microsoft.AspNetCore.Mvc;
using NarodnaSkupstina;

namespace NarodnaSkupstinaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OdrzavanjeSedniceController : ControllerBase
    {
        [HttpGet]
        [Route("SviDaniKadJeOdrzanaSednica/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult sviDaniKadaJeOdrzanaSednicaa([FromRoute(Name = "id")] string id)
        {
            try
            {
                if (int.TryParse(id, out var id2))
                {
                    return new JsonResult(DTOManager.sviDaniKadaJeOdrzanaSednica(id2));
                }
                else
                {
                    return BadRequest("Unesi validan id organizacije za koju " +
                        "zelite da vidite kada je odrzana");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        [Route("SazoviSednicu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult sazoviSednicu([FromQuery(Name ="id")] int id, [FromQuery(Name = "datum")] string datum, [FromQuery(Name = "brp")] int brp)
        {
            try
            {
                if (DateTime.TryParse(datum, out var datum2))
                {
                    DTOManager.SazoviSednicu(datum2,id,brp);
                    return Ok();
                }
                else { return BadRequest("Nevalidan format datuma"); }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPatch]
        [Route("IzmeniSednicu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniPoslanika([FromQuery(Name = "idSednice")] int idSednice, [FromQuery(Name = "datum")] string datum, [FromQuery(Name = "brp")] int brp, [FromQuery(Name = "idOdrzavanjeSednice")] int idOdrzavanjeSednice)
        {
            try
            {
                if (DateTime.TryParse(datum, out var datum2))
                {
                    DTOManager.IzmeniOdrzavanjeSednice(datum2, idSednice, brp,idOdrzavanjeSednice);
                    return Ok();
                }
                else { return BadRequest("Nevalidan format datuma"); }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("ObrisiOdrzavanjeSednice/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult obrisiOdrzavanjeSednice([FromRoute(Name = "id")] string id)
        {
            try
            {
                if (int.TryParse(id, out var id2))
                {
                    DTOManager.ObrisiOdrzavanjeSednice(id2);
                    return Ok();
                }
                else
                {
                    return BadRequest("Unesite validnu vrednost za id");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}
