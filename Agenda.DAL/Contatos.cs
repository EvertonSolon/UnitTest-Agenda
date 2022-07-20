using System.Data.SqlClient;

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

        public void Adicionar(string id, string nome)
        {
            _con.Open();

            var sql = string.Format("Insert into Contato (Id, Nome) Values ('{0}', '{1}');", id, nome);

            SqlCommand cmd = new SqlCommand(sql, _con);

            cmd.ExecuteNonQuery();
            _con.Close();
        }

        public string Obter(string id)
        {
            _con.Open();

            var sql = string.Format("Select Nome from Contato where Id = '{0}';", id);
            
            var cmd = new SqlCommand(sql, _con);

            return cmd.ExecuteScalar().ToString();
        }
    }
}
