using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mamographyBackend.Models
{
    public class MemeTaram
    {
        public string Patient { get; set; }
        public string AccessionNumber { get; set; }
        public string SutCode { get; set; }
        public string Description  { get; set; }
        public string Anamnesis { get; set; }
        public string HospitalName { get; set; }
        public string ModalityCode { get; set; }

    }
}
