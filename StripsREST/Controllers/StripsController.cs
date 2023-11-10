using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripsBL.DTOs;
using StripsBL.Exceptions;
using StripsBL.Managers;
using StripsBL.Model;
using StripsREST.Exceptions;
using StripsREST.Model.Out;

namespace StripsREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripsController : ControllerBase
    {
        private StripsManager stripsManager;
        private string url = "";
        private IHttpContextAccessor httpContextAccessor;

        public StripsController(StripsManager stripsManager, IHttpContextAccessor httpContextAccessor)
        {
            this.stripsManager = stripsManager;
            this.httpContextAccessor = httpContextAccessor;
        }
        
        [HttpGet("beheer/Reeks/{id}")]
        public ActionResult<ReeksRESTOutputDTO> GetStripsReeksById(int id)
        {
            try
            {
                var reeks = stripsManager.GetStripsByReeksId(id);
                if (reeks == null || reeks.Count == 0)
                {
                    return NotFound(new { message = "Reeks not found" });
                }

                var baseUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
                var reeksUrl = $"{baseUrl}/api/Reeks/{id}";

                var stripDtos = new List<StripDTO>();

                string seriesName = null;
                int count = 0;
                foreach (var strip in reeks)
                {
                    string stripNaam = strip.Naam; 
                    string stripNr = strip.Nr.ToString();
                    string stripTitel = strip.Titel;
                    string stripUrl = $"{baseUrl}/api/Strips/beheer/strip/{strip.ID}";

                    stripDtos.Add(new StripDTO(
                        strip.ID,
                        stripNaam, // This is the 'Naam' parameter.
                        stripNr,
                        stripTitel,
                        stripUrl
                    ));

                    if (seriesName == null)
                    {
                        seriesName = stripNaam;
                    }

                    count++;
                }
                var aantal = stripDtos.Count;
                
                var reeksDto = new ReeksRESTOutputDTO(reeksUrl, seriesName, aantal, stripDtos);

                return Ok(reeksDto);
            }
            catch (RESTException)
            {
                return NotFound(new { message = "Reeks not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
            }
        }
    }
}
