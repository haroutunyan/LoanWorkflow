using LoanWorkflow.Services.DTO.Acra;
using LoanWorkflow.Services.DTO.Ekeng.AVV;
using LoanWorkflow.Services.DTO.Ekeng.BusinessRegister;
using LoanWorkflow.Services.DTO.Ekeng.Ces;
using LoanWorkflow.Services.DTO.Ekeng.ECivil;
using LoanWorkflow.Services.DTO.Ekeng.Police;
using LoanWorkflow.Services.DTO.Ekeng.TaxInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.PersonalInfo
{
    public record PersonalInfoDTO
    {
        public long ApplicantId { get; set; }
        public AvvResult Avv { get; set; }
        public PhysicalPersonBusinessDTO BusinessRegister { get; set; }
        public IEnumerable<EInquestDTO> Ces { get; set; }
        public IEnumerable<ECivilAct> Acts { get; set; }
        public IEnumerable<EVehicleDTO> Vehicles { get; set; }
        public DrivingLicenseDTO DrivingLicense { get; set; }
        public IEnumerable<TaxPayerInfoDTO> TaxInfo { get; set; }
        public AcraResult Acra { get; set; }
    }
}
