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
        public Ordenpedido getByPk(int Id);
        public int insert(Ordenpedido obj);
        public void update(Ordenpedido obj);
        public void delete(Ordenpedido obj);
    }
}

