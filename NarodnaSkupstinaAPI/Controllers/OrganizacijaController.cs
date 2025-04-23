using Microsoft.AspNetCore.Mvc;
using NarodnaSkupstina;

namespace NarodnaSkupstinaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizacijaController : ControllerBase
    {
        [HttpGet]
        [Route("SveOrganizacije")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult getOrganizacije()
        {
            try
            {
                return new JsonResult(DTOManager.VratiSveOrganizacije());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        [Route("KreirajOrganizaciju")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult kreirajOrganizaciju([FromBody] OrganizacijaWork organizacija)
        {
            try
            {
                DTOManager.KreirajOrganizaciju(organizacija);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("IzmeniOrganizacuju")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniOrganizacujy([FromBody] OrganizacijaWork Organizacija, [FromQuery(Name = "id")] string id)
        {
            try
            {
                if (int.TryParse(id, out int id2))
                {
                    DTOManager.IzmeniOrganizaciju(id2, Organizacija);
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
        [HttpPut]
        [Route("DodajPoslanikaUOrganizacuju")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult dodajPoslanikaUOrganizacuju([FromQuery(Name = "imeOrganizacije")] string imeOrganizacije, [FromQuery(Name = "JMBGPoslanika")] string JMBGPoslanika)
        {
            try
            {
                if (long.TryParse(JMBGPoslanika, out long JMBG))
                {
                    DTOManager.DodajClanaOrganizacije(imeOrganizacije, JMBG);
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
        [HttpPut]
        [Route("IzbaciPoslanikaUOrganizacuju")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult IzbaciPoslanikaUOrganizacuju([FromQuery(Name = "imeOrganizacije")] string imeOrganizacije, [FromQuery(Name = "JMBGPoslanika")] string JMBGPoslanika)
        {
            try
            {
                if (long.TryParse(JMBGPoslanika, out long JMBG))
                {
                    DTOManager.IzbaciClanaIzOrganizacije(imeOrganizacije, JMBG);
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
        //[HttpPut]
        //[Route("IzbaciPoslanikaUOrganizacuju")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public IActionResult IzbaciPoslanikaUOrganizacuju([FromQuery(Name = "imeOrganizacije")] string imeOrganizacije, [FromQuery(Name = "JMBGPoslanika")] string JMBGPoslanika)
        //{
        //    try
        //    {
        //        if (long.TryParse(JMBGPoslanika, out long JMBG))
        //        {
        //            DTOManager.IzbaciClanaIzOrganizacije(imeOrganizacije, JMBG);
        //            return Ok();
        //        }
        //        else
        //        {
        //            return BadRequest("Unesite validnu vrednost za id");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }
        //}
        [HttpDelete]
        [Route("ObrisiOrganizaciju/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult obrisiOrganizaciju([FromRoute(Name = "id")] string id)
        {
            try
            {
                if (int.TryParse(id, out int ID))
                {
                    DTOManager.ObrisiOrganizaciju(ID);
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
