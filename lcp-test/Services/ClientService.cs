using lcp_test_data.DTOs;
using lcp_test_data.Models;
using lcp_test_data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lcp_test.Services
{
    public class ClientService : IClientService
    {
        private readonly ClientRepository _repository;

        public ClientService(ClientRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ClientDTO> GetClients()
        {
            var clients = _repository.GetClients().Result;

            var clientsList = from taskLog in clients
                              select new ClientDTO()
                              {
                                  Id = taskLog.Id,
                                  FirstName = taskLog.FirstName,
                                  LastName = taskLog.LastName,
                              };

            return clientsList;

        }

        public ClientDTO GetClient(int id)
        {
            var client = _repository.GetClient(id).Result;

            var clientDTO = new ClientDTO()
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
            };

            return clientDTO;
        }

        public int CreateClient(Client client)
        {
            return _repository.CreateClient(client).Result;
        }

        public bool EditClient(int id, Client client)
        {
            return _repository.EditClient(id, client).Result;
        }

        public ClientDTO DeleteClient(int id)
        {
            var client = _repository.DeleteClient(id).Result;

            var clientDTO = new ClientDTO()
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
            };

            return clientDTO;
        }


    }
}
