using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;

namespace WebApiCompras.Services
{
    public interface IDetalleordencompraService
    {
        public List<DetalleOrdenCompra> read();
        public DetalleOrdenCompra getByPk(int Id);
        public int insert(DetalleOrdenCompra obj);
        public void update(DetalleOrdenCompra obj);
        public void delete(DetalleOrdenCompra obj);
    }
}

