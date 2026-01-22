using WebApplicationCsharp.Domain.Entities;
using WebApplicationCsharp.InfraStructure.Repository;

namespace WebApplicationCsharp.Controllers
{
    public class PessoaController
    {
        public void CadastrarUsuario()
        {
            Pessoa entity = new Pessoa();
 
            entity.Id = Guid.NewGuid();
            Console.WriteLine("\nNome:\n");
            entity.Nome = Console.ReadLine();
            Console.WriteLine($"Olá, {entity.Nome}. Insira sua Data de Nascimento!");
            entity.DataNascimento = DateTime.Parse(Console.ReadLine());

            var repository = new PessoaRepository();

            repository.Inserir(entity);

            Console.WriteLine("\nPessoa Cadastrada com sucesso !");

            
        }
        public void AtualizarUsuario()
        {
            var pessoa = new Pessoa();

            Console.WriteLine("\nInsira um ID:\n");
            pessoa.Id = Guid.Parse(Console.ReadLine());

            Console.WriteLine("\nInsira Data de Nascimento\n");
            pessoa.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nNome\n");
            pessoa.Nome = Console.ReadLine();

            var repository = new PessoaRepository();

            repository.Atualizar(pessoa);

            Console.WriteLine("Atualizado com sucesso!");
        }
        public void ConsultarPessoa()
        {
            PessoaRepository repository = new PessoaRepository();
            var pessoas = repository.Consultar();

            foreach(var item in pessoas)
            {
                Console.WriteLine("ID: "+item.Id);
                Console.WriteLine("NOME: "+item.Nome);
                Console.WriteLine("DATA DE NASCIMENTO: "+item.DataNascimento);
            }

            
            
        }

        public void ExcluirPessoa()
        {
            Console.WriteLine("_______Para exluir usuário_______");
            Console.WriteLine("\nInsira o ID do usuario: \n");
            PessoaRepository repository = new PessoaRepository();
            var idExcluido = Guid.Parse(Console.ReadLine());
            repository.Excluir(idExcluido);
        
        Console.WriteLine("Usuario Excluido com sucesso!");
        }
    }
}