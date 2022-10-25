using RegistroAlunos.Data;
using RegistroAlunos.Models;

namespace RegistroAlunos.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public AlunoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public AlunoModel Adicionar(AlunoModel aluno)
        {
            _bancoContext.Alunos.Add(aluno);
            _bancoContext.SaveChanges();
            return aluno;
        }

        public AlunoModel Atualizar(AlunoModel aluno)
        {
            AlunoModel alunoDB = ListarPorId(aluno.Id);

            if (alunoDB == null) throw new Exception("Problemas na edição do registro :(");

            alunoDB.Nome = aluno.Nome;
            alunoDB.Email = aluno.Email;
            alunoDB.Matricula = aluno.Matricula;
            _bancoContext.Alunos.Update(alunoDB);
            _bancoContext.SaveChanges();

            return alunoDB;
        }

        public List<AlunoModel> BuscarTodos()
        {
            return _bancoContext.Alunos.ToList();
        }

        public bool Deletar(int id)
        {
            AlunoModel alunoDB = ListarPorId(id);
            if (alunoDB == null) throw new Exception("Problemas na exclusão do registro :(");
            _bancoContext.Alunos.Remove(alunoDB);
            _bancoContext.SaveChanges();

            return true;

        }

        public AlunoModel ListarPorId(int id)
        {
            return _bancoContext.Alunos.FirstOrDefault(x => x.Id == id);
        }
    }
}
