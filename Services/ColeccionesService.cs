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
    public class ColeccionesService : IColeccionesService
    {
        public Colecciones getByPk(int Id)
        {
            try
            {
                return Colecciones.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Colecciones> read()
        {
            try
            {
                return Colecciones.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Colecciones obj)
        {
            try
            {
                return Colecciones.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Colecciones obj)
        {
            try
            {
                Colecciones.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Colecciones obj)
        {
            try
            {
                Colecciones.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

