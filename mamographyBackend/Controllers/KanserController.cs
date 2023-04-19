using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using mamographyBackend.Context;
using System.Linq;
using mamographyBackend.Context.user;
using mamographyBackend.Infrastructure;
using mamographyBackend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using mamographyBackend.Models;
using System.Collections.Generic;

namespace mamographyBackend.Controllers
{
    [ApiController]
  
    [Route("api/[controller]")]
    public class KanserController : ControllerBase
    {






        [HttpPost("MemeTarama")]
        public IEnumerable<MemeTarama> MemeTarama([FromBody] Sorgula request)
        {

            var dc = new ApplicationDbContext();
            var sorgu = (from rhs in dc.RPAC_VW_PatientHL7Requests
                          
                         where rhs.PatientName.Contains(request.username) && rhs.Description.Contains("meme")
                         select new MemeTarama
                         {
                             Patient=rhs.PatientName,
                             AccessionNumber=rhs.AccessionNumber,
                             SutCode=rhs.SutCode,
                             Description=rhs.Description,
                             Anamnesis=rhs.Anamnesis,
                             HospitalName=rhs.HospitalName,
                             ModalityCode=rhs.ModalityCode
                         }
                         ).ToList();

            return sorgu;




        }
        [HttpPost("ServikalTarama")]
        public IEnumerable<MemeTarama> ServikalTarama([FromBody] Sorgula request)
        {

            var dc = new ApplicationDbContext();

            var sorgu = (from rhs in dc.RPAC_VW_PatientHL7Requests

                         where rhs.PatientName.Contains(request.username) && rhs.Description.Contains("servi")
                         select new MemeTarama
                         {
                             Patient = rhs.PatientName,
                             AccessionNumber = rhs.AccessionNumber,
                             SutCode = rhs.SutCode,
                             Description = rhs.Description,
                             Anamnesis = rhs.Anamnesis,
                             HospitalName = rhs.HospitalName,
                             ModalityCode = rhs.ModalityCode
                         }
                        ).ToList();

            return sorgu;




        }


    }

   

   
}
