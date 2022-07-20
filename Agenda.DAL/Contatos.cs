using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Agenda.Domain;
using Dapper;

namespace Agenda.DAL
{
    public class Contatos
    {
        private readonly string _strCon;

        public Contatos()
        {
            _strCon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public void Adicionar(Contato contato)
        {
            using (var con = new SqlConnection(_strCon))
            {
                con.Execute("Insert into Contato (Id, Nome) Values (@Id, @Nome);", contato);
            }
        }

        public Contato Obter(Guid id)
        {

            var contato = new Contato();

            using (var con = new SqlConnection(_strCon))
            {
                contato = con.QueryFirst<Contato>("Select * from Contato where Id = @Id", new { Id = id });
            }

            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();

            using (var con = new SqlConnection(_strCon))
            {
                var sql = string.Format("Select * from Contato;");
                contatos = con.Query<Contato>(sql).ToList();
            }



            return contatos;

        }
    }
}
