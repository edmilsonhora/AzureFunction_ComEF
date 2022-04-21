using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFuncComEF.Domain.Models;

namespace TestFuncComEF.Domain.DataAcces
{
    public class ContatoRepository : IContatoRepository
    {
        Contexto _contexto;
        public ContatoRepository()
        {
            _contexto = new Contexto();
        }

        public void Excluir(int id)
        {
            var obj = _contexto.Contatos.FirstOrDefault(p => p.Id == id);
            _contexto.Contatos.Remove(obj);
            _contexto.SaveChanges();
        }

        public Contato ObterPor(int id)
        {
            return _contexto.Contatos.FirstOrDefault(p => p.Id == id);
        }

        public List<Contato> ObterTodos()
        {
            return _contexto.Contatos.AsNoTracking().ToList();
        }

        public void Salvar(Contato entity)
        {
            if (entity.Id == 0)
                _contexto.Contatos.Add(entity);

            _contexto.SaveChanges();
        }
    }
}
