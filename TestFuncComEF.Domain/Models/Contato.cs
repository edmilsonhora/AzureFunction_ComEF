using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFuncComEF.Domain.Models
{
   public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }

    public interface IContatoRepository
    {
        void Salvar(Contato entity);
        void Excluir(int id);
        List<Contato> ObterTodos();
        Contato ObterPor(int id);
    }
}
