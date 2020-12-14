using lcp_test_data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcp_test_data.Context
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options)
            : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
    }
}
