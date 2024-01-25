using Microsoft.EntityFrameworkCore;
using TarefasBackEnd.Models;

namespace TarefasBackEnd.Repositories
{
    public interface ITarefaRepository
    {
        void Create(Tarefa tarefa);
        List<Tarefa> Read(Guid id);
        void Update(Guid id, Tarefa tarefa);
        void Delete(Guid id);
    }

    public class TarefaRepository : ITarefaRepository
    {
        private readonly DataContext _context;

        public TarefaRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Tarefa tarefa)
        {
            tarefa.Id = Guid.NewGuid();
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var tarefa = _context.Tarefas.Find(id);
            //Verificando se o Resultado de Find não é nulo
            if (tarefa != null)
            {
                _context.Entry(tarefa).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public List<Tarefa> Read(Guid id)
        {
            return _context.Tarefas.Where(tarefas => tarefas.IdUsuario == id).ToList();
        }

        public void Update(Guid id, Tarefa tarefa)
        {
            var _tarefa = _context.Tarefas.Find(id);

            if (_tarefa != null)
            {
                _tarefa.Nome = tarefa.Nome;
                _tarefa.Concluida = tarefa.Concluida;

                _context.Entry(_tarefa).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}