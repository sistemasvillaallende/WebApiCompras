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
        public Detalleordenpedido getByPk(int Id)
        {
            try
            {
                return Detalleordenpedido.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Detalleordenpedido> read()
        {
            try
            {
                return Detalleordenpedido.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Detalleordenpedido obj)
        {
            try
            {
                return Detalleordenpedido.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Detalleordenpedido obj)
        {
            try
            {
                Detalleordenpedido.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Detalleordenpedido obj)
        {
            try
            {
                Detalleordenpedido.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

