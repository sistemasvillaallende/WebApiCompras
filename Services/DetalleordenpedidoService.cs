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
    public class DetalleordenpedidoService : IDetalleordenpedidoService
    {
        public DetalleOrdenpedido getByPk(int Id)
        {
            try
            {
                return DetalleOrdenpedido.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DetalleOrdenpedido> read()
        {
            try
            {
                return DetalleOrdenpedido.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(DetalleOrdenpedido obj)
        {
            try
            {
                return DetalleOrdenpedido.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(DetalleOrdenpedido obj)
        {
            try
            {
                DetalleOrdenpedido.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(DetalleOrdenpedido obj)
        {
            try
            {
                DetalleOrdenpedido.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

