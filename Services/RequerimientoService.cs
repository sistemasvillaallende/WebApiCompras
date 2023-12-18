using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Transactions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
                obj.Estado = "1";
                obj.Historia = Utils.EstadosJSON.AgregarEstado(1,"Enviado","Estados");
                using (TransactionScope scope = new TransactionScope())
                {
                    Requerimiento.insert(obj);
                    DetalleRequerimiento.insertList(obj.Items, obj.Id);
                    scope.Complete();
            }
                return obj.Id;
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
        public List<Requerimiento> getByUsuario(int idUsuario)
        {
            try
            {
                return Requerimiento.getByUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Requerimiento> getByOficina(int idOficina)
        {
            try
            {
                return Requerimiento.getByOficina(idOficina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Requerimiento> getByDireccion(int idDireccion)
        {
            try
            {
                return Requerimiento.getByDireccion(idDireccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Requerimiento> getBySecretaria(int idSecretaria)
        {
            try
            {
                return Requerimiento.getBySecretaria(idSecretaria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updatePrecios(List<DetalleRequerimiento> lista)
        {
            try
            {
                Requerimiento.updatePrecios(lista);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

