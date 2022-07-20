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
                con.Open();

                var sql = string.Format("Insert into Contato (Id, Nome) Values ('{0}', '{1}');", contato.Id, contato.Nome);

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.ExecuteNonQuery();
            }
        }

        public Contato Obter(Guid id)
        {

            var contato = new Contato();

            using (var con = new SqlConnection(_strCon))
            {
                con.Open();

                var sql = string.Format("Select * from Contato where Id = '{0}';", id);

                var cmd = new SqlCommand(sql, con);

                var sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();

                contato.Id = Guid.Parse(sqlDataReader["Id"].ToString());
                contato.Nome = sqlDataReader["Nome"].ToString();
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

                //con.Open();

                //var sql = string.Format("Select * from Contato;");

                //var cmd = new SqlCommand(sql, con);

                //var sqlDataReader = cmd.ExecuteReader();
                //sqlDataReader.Read();

                //while (sqlDataReader.Read())
                //{
                //    var contato = new Contato();
                //    contato.Id = Guid.Parse(sqlDataReader["Id"].ToString());
                //    contato.Nome = sqlDataReader["Nome"].ToString();

                //    contatos.Add(contato);
                //}
            }



            return contatos;

        }
    }
}
