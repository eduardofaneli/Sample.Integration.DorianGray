using Dapper;
using Sample.Integration.Api.Data;
using Sample.Integration.Api.Models;
using System.Collections.Generic;

namespace Sample.Integration.Api.Repositories
{
    public class TesteDapperRepository
    {
        private DbSession _session;

        public TesteDapperRepository(DbSession session)
        {
            _session = session;
        }

        public IEnumerable<TesteDapper> Get()
        {
            return _session.Connection.Query<TesteDapper>("SELECT ID AS IDHEX, DESCRICAO FROM SIGAM.TESTE_DAPPER", null, _session.Transaction);
        }

        public void Save(TesteDapper model)
        {
            _session.Connection.Execute("INSERT INTO SIGAM.TESTE_DAPPER (DESCRICAO) VALUES(:DESCRICAO)", model, _session.Transaction);
        }

    }
}
