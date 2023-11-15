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
    public class DetalleordencompraService : IDetalleordencompraService
    {
        public DetalleOrdenCompra getByPk(int Id)
        {
            try
            {
                return DetalleOrdenCompra.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DetalleOrdenCompra> read()
        {
            try
            {
                return DetalleOrdenCompra.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(DetalleOrdenCompra obj)
        {
            try
            {
                return DetalleOrdenCompra.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(DetalleOrdenCompra obj)
        {
            try
            {
                DetalleOrdenCompra.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(DetalleOrdenCompra obj)
        {
            try
            {
                DetalleOrdenCompra.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DetalleOrdenCompra> getByOrdenCompra(int idOrdenCompra)
        {
            try
            {
                return DetalleOrdenCompra.getByOrdenCompra(idOrdenCompra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

