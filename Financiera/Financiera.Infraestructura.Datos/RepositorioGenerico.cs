using Financiera.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Financiera.Infraestructura.Datos
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        FinancieraContexto io_contexto;
        public IDbSet<T> Entidad { get; set; } 
        public RepositorioGenerico(FinancieraContexto ao_contexto)
        {
            this.io_contexto = ao_contexto;
            this.Entidad = ao_contexto.Set<T>(); 
        } 
        public RepositorioGenerico() : this(new FinancieraContexto()) 
        { 
        //this.Entidad = System.Reflection.Assembly.GetAssembly(typeof(C)).CreateInstance(typeof(C)); 
        } 
        public T ObtenerPorCodigo(params object[] ao_llaves)
        { 
           return Entidad.Find(ao_llaves); 
        } 
        public IList<T> ObtenerPorExpresion(Expression<Func<T, bool>> ao_llaves, string as_incluir, byte aby_limite)
        {
            if (ao_llaves == null)
                return Entidad.ToList();
            else 
                return Entidad.Where(ao_llaves).ToList();
        }
        public IQueryable<T> Listar()
        { 
            return Entidad; 
        }
        public bool Adicionar(T ao_entidad)
        { 
            Entidad.Add(ao_entidad); 
            return true; 
        }
        public bool Actualizar(T ao_entidad)
        {
            throw new NotImplementedException();
        }
        public bool GuardarCambios()
        {
            io_contexto.SaveChanges();
            return true;
        }
    }
}
