using lcp_test_data.Context;
using lcp_test_data.Models;
using lcp_test_data.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lcp_test_data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientContext _context;

        public ClientRepository(ClientContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClient(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<int> CreateClient(Client client)
        {
            _context.Clients.Add(client);
            var createdClient = await _context.SaveChangesAsync();

            return createdClient;
        }

        public async Task<bool> EditClient(int id, Client client)
        {
            var isUpdateSuccessful = false;

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                isUpdateSuccessful = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return isUpdateSuccessful;
                }
                else
                {
                    throw;
                }
            }

            return isUpdateSuccessful;
        }

        public async Task<Client> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return null;
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return client;
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }

    }
}
