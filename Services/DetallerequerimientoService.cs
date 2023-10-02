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
    public class DetallerequerimientoService : IDetallerequerimientoService
    {
        public Detallerequerimiento getByPk(int Id)
        {
            try
            {
                return Detallerequerimiento.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Detallerequerimiento> read()
        {
            try
            {
                return Detallerequerimiento.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Detallerequerimiento obj)
        {
            try
            {
                return Detallerequerimiento.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Detallerequerimiento obj)
        {
            try
            {
                Detallerequerimiento.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Detallerequerimiento obj)
        {
            try
            {
                Detallerequerimiento.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

