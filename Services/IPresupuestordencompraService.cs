using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;

namespace WebApiCompras.Services
{
    public interface IPresupuestoOrdenCompraService
    {
        public List<PresupuestoOrdenCompra> read();
        public PresupuestoOrdenCompra getByPk(int Id);
        public int insert(PresupuestoOrdenCompra obj);
        public void update(PresupuestoOrdenCompra obj);
        public void delete(PresupuestoOrdenCompra obj);
        public List<PresupuestoOrdenCompra> getByDireccion(int idDireccion);
        public List<PresupuestoOrdenCompra> getBySecretaria(int idSecretaria);
        public List<PresupuestoOrdenCompra> getByOficina(int idOficina);
        public List<PresupuestoOrdenCompra> getByUsuario(int idUsuario);
        public List<PresupuestoOrdenCompra> getByOrdenCompra(int idOrdenCompra);
    }
}

