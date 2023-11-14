using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;

namespace WebApiCompras.Services
{
    public interface IDetalleordenpedidoService
    {
        public List<DetalleOrdenpedido> read();
        public DetalleOrdenpedido getByPk(int Id);
        public int insert(DetalleOrdenpedido obj);
        public void update(DetalleOrdenpedido obj);
        public void delete(DetalleOrdenpedido obj);
        public List<DetalleOrdenpedido> getByOrdenPedido(int idOrdenPedido);
    }
}

