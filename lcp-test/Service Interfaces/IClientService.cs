using lcp_test_data.DTOs;
using lcp_test_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lcp_test.Services
{
    public interface IClientService
    {

        public IEnumerable<ClientDTO> GetClients();

        public ClientDTO GetClient(int id);

        public int CreateClient(Client client);

        public bool EditClient(int id, Client client);

        public ClientDTO DeleteClient(int id);
    }
}
