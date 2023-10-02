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
    public class RequerimientoService : IRequerimientoService
    {
        public Requerimiento getByPk(int Id)
        {
            try
            {
                return Requerimiento.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Requerimiento> read()
        {
            try
            {
                return Requerimiento.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Requerimiento obj)
        {
            try
            {
                return Requerimiento.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Requerimiento obj)
        {
            try
            {
                Requerimiento.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Requerimiento obj)
        {
            try
            {
                Requerimiento.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

