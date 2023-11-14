using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;

namespace WebApiCompras.Services
{
    public interface ISurtidoService
    {
        public List<Surtido> read();
        public Surtido getByPk(int Id);
        public int insert(Surtido obj);
        public void update(Surtido obj);
        public void delete(Surtido obj);
        public List<Surtido> getByUsuario(int IdUsuario);
        public List<Surtido> getByOficina(int IdOficina);
        public List<Surtido> getByDireccion(int IdDireccion);
        public List<Surtido> getBySecretaria(int IdSecretaria);
    }
}

