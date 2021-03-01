using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace Sample.Integration.Api.Data
{
    public sealed class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString").Value;

            _id = Guid.NewGuid();
            Connection = new  OracleConnection(connectionString);
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
    }
}
