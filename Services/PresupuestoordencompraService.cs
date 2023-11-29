using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using WebApiCompras.Entities;

namespace WebApiCompras.Services
{
    public class PresupuestoOrdenCompraService : IPresupuestoOrdenCompraService
    {
        public PresupuestoOrdenCompra getByPk(int Id)
        {
            try
            {
                return PresupuestoOrdenCompra.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PresupuestoOrdenCompra> read()
        {
            try
            {
                return PresupuestoOrdenCompra.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(PresupuestoOrdenCompra obj)
        {
            try
            {
                return PresupuestoOrdenCompra.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(PresupuestoOrdenCompra obj)
        {
            try
            {
                PresupuestoOrdenCompra.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(PresupuestoOrdenCompra obj)
        {
            try
            {
                PresupuestoOrdenCompra.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PresupuestoOrdenCompra> getByDireccion(int idDireccion)
        {
            try
            {
                return PresupuestoOrdenCompra.getByDireccion(idDireccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PresupuestoOrdenCompra> getBySecretaria(int idSecretaria)
        {
            try
            {
                return PresupuestoOrdenCompra.getBySecretaria(idSecretaria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PresupuestoOrdenCompra> getByOficina(int idOficina)
        {
            try
            {
                return PresupuestoOrdenCompra.getByOficina(idOficina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PresupuestoOrdenCompra> getByUsuario(int idUsuario)
        {
            try
            {
                return PresupuestoOrdenCompra.getByUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PresupuestoOrdenCompra> getByOrdenCompra(int idOrdenCompra)
        {
            try
            {
                return PresupuestoOrdenCompra.getByOrdenCompra(idOrdenCompra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

