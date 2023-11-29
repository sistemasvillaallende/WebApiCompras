using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;

namespace WebApiCompras.Services
{
    public interface IDetallepresupuestoordencompraService
    {
        public List<DetallePresupuestoOrdenCompra> read();
        public DetallePresupuestoOrdenCompra getByPk(int Id);
        public int insert(DetallePresupuestoOrdenCompra obj);
        public void update(DetallePresupuestoOrdenCompra obj);
        public void delete(DetallePresupuestoOrdenCompra obj);
        public List<DetallePresupuestoOrdenCompra> getByIdPresupuestoOrdenCompra(int idPresupuestoRequerimiento);
    }
}

