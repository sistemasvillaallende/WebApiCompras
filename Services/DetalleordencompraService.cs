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
        public Detalleordencompra getByPk(int Id)
        {
            try
            {
                return Detalleordencompra.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Detalleordencompra> read()
        {
            try
            {
                return Detalleordencompra.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Detalleordencompra obj)
        {
            try
            {
                return Detalleordencompra.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Detalleordencompra obj)
        {
            try
            {
                Detalleordencompra.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Detalleordencompra obj)
        {
            try
            {
                Detalleordencompra.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

