using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Agenda.Domain;

namespace Agenda.DAL
{
    public class Contatos
    {
        private readonly string _strCon;
        private readonly SqlConnection _con;

        public Contatos()
        {
            _strCon = @"Server=.\SQLEXPRESS;Database=Agenda;Trusted_Connection=True";
            _con = new SqlConnection(_strCon);
            
        }

        public void Adicionar(Contato contato)
        {
            _con.Open();

            var sql = string.Format("Insert into Contato (Id, Nome) Values ('{0}', '{1}');", contato.Id, contato.Nome);

            SqlCommand cmd = new SqlCommand(sql, _con);

            cmd.ExecuteNonQuery();
            _con.Close();
        }

        public Contato Obter(Guid id)
        {
            _con.Open();

            var sql = string.Format("Select * from Contato where Id = '{0}';", id);
            
            var cmd = new SqlCommand(sql, _con);

            var sqlDataReader = cmd.ExecuteReader();
            sqlDataReader.Read();

            var contato = new Contato();
            contato.Id = Guid.Parse(sqlDataReader["Id"].ToString());
            contato.Nome = sqlDataReader["Nome"].ToString();

            return contato;
        }

        public List<Contato> ObterTodos()
        {
            _con.Open();

            var sql = string.Format("Select * from Contato;");

            var cmd = new SqlCommand(sql, _con);

            var sqlDataReader = cmd.ExecuteReader();
            sqlDataReader.Read();

            var contatos = new List<Contato>();

            while (sqlDataReader.Read())
            {
                var contato = new Contato();
                contato.Id = Guid.Parse(sqlDataReader["Id"].ToString());
                contato.Nome = sqlDataReader["Nome"].ToString();

                contatos.Add(contato);
            }

            return contatos;

        }
    }
}
