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
    public class DetallepresupuestoordencompraService : IDetallepresupuestoordencompraService
    {
        public DetallePresupuestoOrdenCompra getByPk(int Id)
        {
            try
            {
                return DetallePresupuestoOrdenCompra.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DetallePresupuestoOrdenCompra> read()
        {
            try
            {
                return DetallePresupuestoOrdenCompra.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(DetallePresupuestoOrdenCompra obj)
        {
            try
            {
                return DetallePresupuestoOrdenCompra.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(DetallePresupuestoOrdenCompra obj)
        {
            try
            {
                DetallePresupuestoOrdenCompra.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(DetallePresupuestoOrdenCompra obj)
        {
            try
            {
                DetallePresupuestoOrdenCompra.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DetallePresupuestoOrdenCompra> getByIdPresupuestoOrdenCompra(int idPresupuestoRequerimiento)
        {
            try
            {
                return DetallePresupuestoOrdenCompra.getByIdPresupuestoOrdenCompra(idPresupuestoRequerimiento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

