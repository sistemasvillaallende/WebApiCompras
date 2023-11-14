using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;

namespace WebApiCompras.Services
{
    public interface IOrdenpedidoService
    {
        public List<Ordenpedido> read();
        public Ordenpedido getByPk(int id);
        public int insert(Ordenpedido obj);
        public void update(Ordenpedido obj);
        public void delete(Ordenpedido obj);
        public Ordenpedido getByRequerimiento(int idRequerimiento);
        public List<Ordenpedido> getByDireccion(int idSecretaria);
        public List<Ordenpedido> getBySecretaria(int idDireccion);
        public List<Ordenpedido> getByOficina(int idOficina);
        public List<Ordenpedido> getByUsuario(int idUsuario);
    }
}

