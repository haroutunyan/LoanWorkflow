using LoanWorkflow.Core.Constants;
using LoanWorkflow.Core.Enums;
using LoanWorkflow.Core.Helpers;
using LoanWorkflow.Core.Options;
using LoanWorkflow.Services.DTO.Acra;
using LoanWorkflow.Services.Interfaces.Acra;
using Microsoft.Extensions.Options;

namespace LoanWorkflow.Services.Acra
{
    public class AcraService(
        HttpClient httpClient,
        IOptions<AcraCredentials> options)
        : IAcraService
    {
        const string RowDataAttributeName = "ROWDATA";
        public async Task<AcraResult> GetAcraData(AcraRequest model, bool isMonitoring)
        {
            var loginRequest = new SoleLoginRequestModel
            {
                Password = options.Value.Password,
                ReqID = options.Value.ReqID,
                User = options.Value.UserName
            };
            var loginResult = await httpClient.PostXml<SoleLoginRequestModel, SoleLoginResponse>(string.Empty, loginRequest, RowDataAttributeName);
            if (loginResult.Error is not null)
                throw new Exception(loginResult.Error);

            string monitoringUrl = isMonitoring ? "?mon=1" : string.Empty;

            var request1 = ConstructRequest1(model, isMonitoring, loginResult.SessionId, "99999999", options.Value);
            var response1 = await httpClient.PostXml<SoleRequest1Model, SoleRequest1Response>(monitoringUrl, request1, RowDataAttributeName);
            if (response1.Error is not null)
                return null;

            if (response1.Participient.ThePresenceData == ACRAThePresenceData.CreditReportBlocked)
                return null;

            if (response1?.Participient?.Person?.Count == 0)
                return null;

            var request2 = ConstructRequest2(model, response1, isMonitoring);
            var response2 = await httpClient.PostXml<SoleRequest2Model, AcraResult>(monitoringUrl, request2, RowDataAttributeName);

            if (response2.Error is not null)
                return null;

            return response2;
        }

        private static SoleRequest1Model ConstructRequest1(AcraRequest model, bool isMonitoring, string sessionId, string requestId, AcraCredentials credentials) 
        {
            var participient = new SoleParticipientRequest1Model
            {
                UsageRange = isMonitoring ? UsageRange.OtherTest : model.UsageRange,
                RequestTarget = isMonitoring ? RequestTarget.NewLoanAppTest : model.RequestTarget,
                LastName = model.LastName,
                FirstName = model.FirstName,
                DateofBirth = model.BirthDate.ToString(DateTimeFormats.DDMMYYYY),
                SocCardNumber = model.SocialCard,
                PassportNumber = model.Passport,
                IdCardNumber = model.IdCard,
                Id = requestId
            };

            if (string.IsNullOrEmpty(model.Passport) && !string.IsNullOrEmpty(model.IdCard))
                participient.PassportNumber = model.IdCard;

            participient.PassportNumber ??= string.Empty;
            participient.IdCardNumber ??= string.Empty;
            participient.KindBorrower = KindBorrower.Individual;

            var request = new SoleRequest1Model
            {
                ReqID = credentials.ReqID,
                AppNumber = credentials.AppNumber,
                ApplicationDate = DateTime.UtcNow.AddHours(4).ToString(DateTimeFormats.DDMMYYYYhhmmss),
                SessionId = sessionId,
                Participient = participient,
                ReportType = model.ACRAReportType
            };

            if (model.RequestType == AvhRequestType.Legal)
                request.ReportType = ACRAReportTypes.AVH;

            return request;
        }

        private static SoleRequest2Model ConstructRequest2(AcraRequest model, SoleRequest1Response request1Response, bool isMonitoring)
        {
            var persons = request1Response.Participient.Person;
            var newPersons = new List<SoleRequest2Person>();
            for (int i = 0, count = persons.Count; i < count; ++i)
            {
                SoleResponse1Person person = persons[i];

                if ((!string.IsNullOrWhiteSpace(person.SocCardNumber) && person.SocCardNumber == model.SocialCard) ||
                    (!string.IsNullOrWhiteSpace(person.PassportNumber) && person.PassportNumber == model.Passport) ||
                    (!string.IsNullOrWhiteSpace(person.IdCardNumber) && person.IdCardNumber == model.IdCard))
                {
                    newPersons.Add(new SoleRequest2Person
                    {
                        Identificator = person.Identificator
                    });
                }
            }

            var participient = new SoleParticipientRequest2Model
            {
                UsageRange = isMonitoring ? UsageRange.OtherTest : model.UsageRange,
                RequestTarget = isMonitoring ? RequestTarget.NewLoanAppTest : model.RequestTarget,
                Id = request1Response.Participient.Id,
                Persons = newPersons,
                KindBorrower = KindBorrower.Individual
            };

            var request = new SoleRequest2Model
            {
                ReqID = request1Response.ReqID,
                AppNumber = request1Response.AppNumber,
                ApplicationDate = request1Response.ApplicationDate,
                SessionId = request1Response.SessionId,
                Participient = participient,
                ReportType = model.ACRAReportType
            };

            if (model.RequestType == AvhRequestType.Legal)
                request.ReportType = ACRAReportTypes.AVH;

            return request;
        }
    }
}
