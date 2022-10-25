using RegistroAlunos.Models;
namespace RegistroAlunos.Repositorio
{
    public interface IAlunoRepositorio
    {
        AlunoModel ListarPorId(int id);
        List<AlunoModel> BuscarTodos();
        AlunoModel Adicionar(AlunoModel aluno);

        AlunoModel Atualizar(AlunoModel aluno);

        bool Deletar(int id);
    }
}
