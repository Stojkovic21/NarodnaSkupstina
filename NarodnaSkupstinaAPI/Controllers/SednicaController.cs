using Microsoft.AspNetCore.Mvc;
using NarodnaSkupstina;

namespace NarodnaSkupstinaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SednicaController : ControllerBase
    {
        [HttpGet]
        [Route("SveSednice")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult getSednice()
        {
            try
            {
                return new JsonResult(DTOManager.VratiSveSednice());
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
        public IActionResult sazoviSednicu([FromBody] SednicaWork sednica)
        {
            try
            {
                DTOManager.SazoviSednicu(sednica);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("IzmeniSednicu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniPoslanika([FromBody] SednicaWork sednica)
        {
            try
            {
                DTOManager.IzmeniSednicu(sednica);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("KojiPoslaniciSazivajuSednicu/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult kojiPoslaniciSazivajuSednicu([FromRoute(Name ="JMBG")] string JMBG)
        {
            try
            {
                if (long.TryParse(JMBG, out long JMBG2))
                {
                    DTOManager.KojiPoslaniciSazivajuSednicu(JMBG2);
                    return Ok();
                }
                else { return BadRequest("Unesite validnu vrednost za jmbg"); }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]
        [Route("PoslaniciKojiSazivajuSednicu/{idSednice}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult poslaniciKojiSazivajuSednicu([FromRoute(Name ="idSednice")] string idSednice)
        {
            try
            {
                if (int.TryParse(idSednice, out int id))
                {
                    return new JsonResult(DTOManager.PoslaniciKojiSazivajuSednicu(id));
                }
                else
                {
                    return BadRequest("Unesite validnu vrednost za idsednice");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("ObrisiSednicu/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult obrisiSednicu([FromRoute(Name = "id")] string id)
        {
            try
            {
                if (int.TryParse(id, out int ID))
                {
                    DTOManager.ObrisiSednicu(ID);
                    return Ok();
                }
                else { return BadRequest("Unesite validnu vrednost za id sednice"); }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}
