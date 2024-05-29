using LoanWorkflow.Services.DTO.PersonalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.Interfaces.PersonalInfo
{
    public interface IPersonalInfoService
    {
        Task<PersonalInfoDTO> GetAllPersonalInfos(string ssn);
    }
}
