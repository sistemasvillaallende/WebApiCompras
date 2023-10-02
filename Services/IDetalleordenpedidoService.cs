using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;
namespace WebApiCompras.Services
{
    public interface IDetalleordenpedidoService
    {
        public List<Detalleordenpedido> read();
        public Detalleordenpedido getByPk(int Id);
        public int insert(Detalleordenpedido obj);
        public void update(Detalleordenpedido obj);
        public void delete(Detalleordenpedido obj);
    }
}

