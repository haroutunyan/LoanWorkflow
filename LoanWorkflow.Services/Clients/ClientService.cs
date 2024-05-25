using LoanWorkflow.Api.Models.Clients;
using LoanWorkflow.Core.Enums;
using LoanWorkflow.Core.Exceptions;
using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Clients;
using LoanWorkflow.Services.Interfaces.Ekeng;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.Services.Clients
{
    public class ClientService(IDbSetAccessor<Client> dbSetAccessor, 
        IEkengService _ekengService)
        : Service<Client>(dbSetAccessor), IClientService
    {
        public async Task Add(Client client)
            => await Repository.AddAsync(client);

        public async Task<Client?> GetById(long id)
            => await Repository.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<Client?> GetBySsnAsync(string ssn)
            => await Repository
            .FirstOrDefaultAsync(e => e.SSN == ssn);

        public async Task BorrowerInfo(BorrowerInfoRequestModel requestModel)
        {
            var client = await GetBySsnAsync(requestModel.SSN);

            if (client != null)
                throw new AlreadyExistException();

            var info = await _ekengService.GetClientData(requestModel.SSN) ?? throw new NotFoundException();

            await Repository.AddAsync(new Client 
            { 
                Email = requestModel.Email,
                Address = info.Address,
                ConsentDate = requestModel.ConsentDate,
                Created = DateTime.Now,
                Type = requestModel.ClientType,
                SSN = requestModel.SSN,
                PhoneNumber = requestModel.PhoneNumber,
                FirstName = info.FirstName,
                LastName = info.LastName,
                BirthDate = info.BirthDate,
                Gender = (Gender)Enum.Parse(typeof(Gender), info.Gender),
                Document = info.Document,
                DocIssuer = info.DocIssuer,
                DocIssuedDate = info.DocIssuedDate,
                DocValidityDate = info.DocValidityDate,
                MiddleName = info.MiddleName
            });
        }

        public async Task ConnectedClientInfo(ConnectedClientInfoRequestModel requestModel)
        {
            var client = await GetBySsnAsync(requestModel.SSN);

            if (client != null)
                throw new AlreadyExistException();

            var info = await _ekengService.GetClientData(requestModel.SSN) ?? throw new NotFoundException();

            await Repository.AddAsync(new Client
            {
                Email = requestModel.Email,
                Address = info.Address,
                ConsentDate = requestModel.ConsentDate,
                Created = DateTime.Now,
                Type = requestModel.ClientType,
                SSN = requestModel.SSN,
                PhoneNumber = requestModel.PhoneNumber,
                FirstName = info.FirstName,
                LastName = info.LastName,
                BirthDate = info.BirthDate,
                Gender = (Gender)Enum.Parse(typeof(Gender), info.Gender),
                Document = info.Document,
                DocIssuer = info.DocIssuer,
                DocIssuedDate = info.DocIssuedDate,
                DocValidityDate = info.DocValidityDate,
                MiddleName = info.MiddleName,
                ConnectionType = requestModel.ConnectionType,
                BorrowerSSN = requestModel.BorrowerSSN
            });
        }
    }
}
