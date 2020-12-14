using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lcp_test_data.Context;
using lcp_test_data.Models;
using lcp_test.Services;
using lcp_test_data.DTOs;

namespace lcp_test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        // GET: api/Clients
        [HttpGet]
        public ActionResult<IEnumerable<ClientDTO>> GetClients()
        {
            return (ActionResult)_service.GetClients();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public ClientDTO GetClient(int id)
        {
            var client = _service.GetClient(id);

            if (client == null)
            {
                return null;
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public bool PutClient(int id, Client client)
        {
            var isUpdateSuccessful = _service.EditClient(id, client);

            //if (!ClientExists(id))
            //{
            //    return NotFound();
            //}

            return isUpdateSuccessful;
        }

        // POST: api/Clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Client> PostClient(Client client)
        {
            var createdId = _service.CreateClient(client);
            return CreatedAtAction("GetClient", new { id = createdId }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public ActionResult<ClientDTO> DeleteClient(int id)
        {
            var client = _service.DeleteClient(id);
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }
    }
}
