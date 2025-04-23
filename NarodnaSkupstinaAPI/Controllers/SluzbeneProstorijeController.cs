using Microsoft.AspNetCore.Mvc;
using NarodnaSkupstina;
using System;

namespace NarodnaSkupstinaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SluzbeneProstorijeController : ControllerBase
    {
        [HttpGet]
        [Route("SveSluzbeneProstorije")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult getSluzbeneProstorije()
        {
            try
            {
                return new JsonResult(DTOManager.SveSluzbeneProstorije());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        [Route("NovaSluzbenaProstorija")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult novaSluzbenaProstorija([FromQuery(Name ="broj")] string broj, [FromQuery(Name ="sprat")] string sprat)
        {
            try
            {
                if((int.TryParse(broj, out int br))&&(int.TryParse(sprat, out int sprat2)))
                {
                    DTOManager.NovaSluzbenaProstorija(br,sprat2);
                    return Ok();
                }
                else
                {
                    return BadRequest("Unesite validne vrednosti za spret i broj prostorije");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        //Dodeli sluzbenu prostoriju
        [HttpPatch]
        [Route("DodeliProstorijuOrganizaciji")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniSluzbenuProstoriji([FromQuery(Name = "brojProstorije")] string brojProstorije, [FromQuery(Name = "imeOrganizacije")] string imeOrganizacije)
        {
            try
            {
                if (int.TryParse(brojProstorije, out int br))
                {
                    DTOManager.DodeliProstoriju(br,imeOrganizacije);
                    return Ok();
                }
                else
                {
                    return BadRequest("Unesite validne vrednosti za broj prostorije");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        //oslobodu prostoriju
        [HttpPatch]
        [Route("OslobodiProstorijuOrganizaciji")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult oslobodiSluzbenuProstoriji([FromQuery(Name = "brojProstorije")] string brojProstorije)
        {
            try
            {
                if (int.TryParse(brojProstorije, out int br))
                {
                    DTOManager.OslobodiProstoriju(br);
                    return Ok();
                }
                else
                {
                    return BadRequest("Unesite validne vrednosti za broj prostorije");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("IzmeniSluzbenuProstoriji")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniSluzbenuProstoriji([FromQuery(Name ="id")] string id, [FromQuery(Name = "broj")] string broj, [FromQuery(Name = "sprat")] string sprat)
        {
            try
            {
                if((int.TryParse(broj, out int br))&&(int.TryParse(sprat, out int sprat2))&&(int.TryParse(id, out int ID)))
                {
                    DTOManager.IzmeniSluzbenuProstoriji(ID,br, sprat2);
                    return Ok();
                }
                else
                {
                    return BadRequest("Unesite validne vrednosti za id prostorije, spret i broj prostorije");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("ObrisiSluzbenuProstoriji/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult obrisiSluzbenuProstoriji([FromRoute(Name = "id")] string id)
        {
            try
            {
                if (int.TryParse(id, out int ID))
                {
                    DTOManager.ObrisiSluzbenuProstoriji(ID);
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
