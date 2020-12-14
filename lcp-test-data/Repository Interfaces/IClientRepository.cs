using lcp_test_data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcp_test_data.Repository_Interfaces
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetClients();

        public Task<Client> GetClient(int id);

        public Task<int> CreateClient(Client client);

        public Task<bool> EditClient(int id, Client client);

        public Task<Client> DeleteClient(int id);
    }
}
