using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;

namespace WebApiCompras.Services
{
    public interface IOrdencompraService
    {
        public List<OrdenCompra> read();
        public OrdenCompra getByPk(int Id);
        public int insert(OrdenCompra obj);
        public void update(OrdenCompra obj);
        public void delete(OrdenCompra obj);
    }
}

