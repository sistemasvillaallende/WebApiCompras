using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;
namespace WebApiCompras.Services
{
    public interface IDetalleordencompraService
    {
        public List<Detalleordencompra> read();
        public Detalleordencompra getByPk(int Id);
        public int insert(Detalleordencompra obj);
        public void update(Detalleordencompra obj);
        public void delete(Detalleordencompra obj);
    }
}

