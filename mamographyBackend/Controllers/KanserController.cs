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
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace mamographyBackend.Controllers
{
    [ApiController]
  
    [Route("api/[controller]")]
    public class KanserController : ControllerBase
    {






        [HttpPost("MemeTarama")]
        public IEnumerable<MemeTaram> MemeTarama([FromBody] Sorgula request)
        {
            
            //BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            //binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            //CustomBinding customBinding = new CustomBinding(binding);
            //SecurityBindingElement element = customBinding.Elements.Find<SecurityBindingElement>();
            //element.IncludeTimestamp = false;
            //EndpointAddress MemeEndpointAddress = new EndpointAddress("https://mmtarama.saglik.gov.tr/HastaneWorklist/hastaneworklist.svc"); //canlı servis adresidir!
            //WorkList.HastaneWorkListServiceClient worklist = new WorkList.HastaneWorkListServiceClient(customBinding, MemeEndpointAddress);
            //WorkList.MamografiIsListesiIstek a = new WorkList.MamografiIsListesiIstek();
            //a.IstemciAeTitle = "pacs";
            //worklist.ClientCredentials.UserName.UserName = "5639";
            //worklist.ClientCredentials.UserName.Password = "hs5639";
            
            
            
            //var a1 = worklist.MamografiIsListesiAsync("5639", "hs5639", a).Result;
            var dc = new ApplicationDbContext();
            var sorgu = (from rhs in dc.RPAC_VW_PatientHL7Requests
                          
                         where rhs.PatientName.Contains(request.username) && rhs.Description.Contains("meme")
                         select new MemeTaram
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
        public IEnumerable<MemeTaram> ServikalTarama([FromBody] Sorgula request)
        {

            var dc = new ApplicationDbContext();

            var sorgu = (from rhs in dc.RPAC_VW_PatientHL7Requests

                         where rhs.PatientName.Contains(request.username) && rhs.Description.Contains("servi")
                         select new MemeTaram
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
