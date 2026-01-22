using Microsoft.Data.SqlClient;
using Dapper;
using WebApplicationCsharp.Domain.Entities;

namespace WebApplicationCsharp.InfraStructure.Repository
{
    public class PessoaRepository
    {

        
        private string _connectionString = "Server=localhost,1433;Database=master;User Id=sa;Password=Coti@2025;TrustServerCertificate=True;Encrypt=False;";
                public void Inserir(Pessoa pessoa)
        {
            string query = "INSERT INTO Pessoa (ID,NOME, DATANASCIMENTO) VALUES (@Id, @Nome, @DataNascimento)";
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, pessoa);
            }
        }
        public void Atualizar(Pessoa pessoa)
        {
            string query = "UPDATE Pessoa SET NOME = @Nome, DATANASCIMENTO = @DataNascimento WHERE ID = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, pessoa);
            }
        
        }
        public List<Pessoa> Consultar()
        {
            string query = "SELECT * FROM Pessoa ORDER BY NOME";

            using(var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Pessoa>(query).ToList();
            }
        }
        public void Excluir(Guid id)
        {
            
            
            string query = "DELETE FROM Pessoa WHERE ID = @Id";

            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query,new {id});
            }
        }

    }
}