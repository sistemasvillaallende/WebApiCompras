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
    public class DetalleRequerimientoService : IDetalleRequerimientoService
    {
        public DetalleRequerimiento getByPk(int Id)
        {
            try
            {
                return DetalleRequerimiento.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DetalleRequerimiento> read()
        {
            try
            {
                return DetalleRequerimiento.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(DetalleRequerimiento obj)
        {
            try
            {
                return DetalleRequerimiento.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(DetalleRequerimiento obj)
        {
            try
            {
                DetalleRequerimiento.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(DetalleRequerimiento obj)
        {
            try
            {
                DetalleRequerimiento.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

