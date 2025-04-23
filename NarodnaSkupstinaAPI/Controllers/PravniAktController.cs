using Microsoft.AspNetCore.Mvc;
using NarodnaSkupstina;

namespace NarodnaSkupstinaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PravniAktController : ControllerBase
    {
        [HttpGet]
        [Route("SviPravniAkti")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult getPravniAkt()
        {
            try
            {
                return new JsonResult(DTOManager.VratiSvePravneAkte());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]
        [Route("SviPoslaniciKojiPredlazuAkt/{idAkta}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SviPoslaniciKojiPredlazuAkt([FromRoute(Name ="idAkta")] string idAkta)
        {
            try
            {
                if (int.TryParse(idAkta, out var id))
                {
                    return new JsonResult(DTOManager.PoslaniciKojiPredlazuAkt(id));
                }
                else
                {
                    return BadRequest("Unesite validnu vrednost za id akta");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        [Route("PredloziAkt")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult predloziAkt([FromBody] PravniAktWork pravniAkt)
        {
            try
            {
                DTOManager.PredloziAkt(pravniAkt);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("IzmeniAkt/{idAkta}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniAkt([FromRoute(Name ="idAkta")] string idAkta,[FromBody] PravniAktWork sednica)
        {
            try
            {
                if (int.TryParse(idAkta, out int id))
                {
                    DTOManager.IzmeniAkt(id,sednica);
                    return Ok();
                }
                else
                {
                    return BadRequest("Unesite validnu brednost za id Akta");
                }
                }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("ObrisiAkt/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult obrisiAkt([FromRoute(Name = "id")] string id)
        {
            try
            {
                if (int.TryParse(id, out int ID))
                {
                    DTOManager.ObrisiAkt(ID);
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
