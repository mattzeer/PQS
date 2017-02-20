using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using Microsoft.Practices.Unity;
using PQS.Dal.SqlServer.Manager;
using PQS.Dal.SqlServer.DataModel;
using System.Configuration;
using LinqKit;

namespace Dds.Join2Ship.Dal.SqlServer.Manager
{
    public class ManagerData : IManagerData
    {
        /// <summary>
        /// this object is used to do all access to database with EF6
        /// </summary>
        private pqsEntities context;

        /// <summary>
        /// Initialise une nouvelle instance de ManagerImpl
        /// </summary>
        /// <param name="context"> Entity Framework ObjectContext</param>
        public ManagerData(pqsEntities context)
        {
            string message = "Context Null";
            if (context == null)
                throw new ArgumentNullException(message);
            try
            {
                var objectContext = (this.context as IObjectContextAdapter).ObjectContext;

            }
            catch (ArgumentNullException)
            {
                throw;

            }
        }
        /// <summary>
        /// Initialise une nouvelle instance de ManagerImpl
        /// </summary>
        /// 
        [InjectionConstructor]
        public ManagerData()
        {
            context = new pqsEntities(ConfigurationManager.AppSettings["CONNEXION_STRING"]);
            //context.Configuration.AutoDetectChangesEnabled = false;
            var objectContext = (this.context as IObjectContextAdapter).ObjectContext;
        }


        /// <summary>
        /// Retourne une instance d' IQueryable liée à une classe de type TEntity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>().AsExpandable();
        }

        public IEnumerable<TEntity> WhereAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }
        

        /// <summary>
        /// Retourne toutes les entrées de type TEntity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return GetQuery<TEntity>().AsEnumerable();
        }
        /// <summary>
        /// Retourne les entrées de la table TEntity selon les critères passés en paramètres 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            try
            {
                return GetQuery<TEntity>().AsExpandable().Where(predicate).AsEnumerable();
            }
            catch (Exception e)
            {
                throw;
            }
        }

      

        /// <summary>
        /// Retourne les entrées de la table TEntity selon les critères passés en paramètres 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Where<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
           
            try
            {
                return GetQuery<TEntity>().Where(predicate).AsEnumerable();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Retourne une entrée de la table TEntity selon les critères passés en paramètres 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity Single<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            try
            {
                return GetQuery<TEntity>().SingleOrDefault<TEntity>(predicate);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<TEntity> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            try
            {
                return await context.Set<TEntity>().SingleAsync(predicate);
            }
           catch(Exception e)
            {
                throw;
            
            }
        }

        public async Task<TEntity> SingleOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Retourne une entrée de la table TEntity selon les critères passés en paramètres 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
           
            try
            {
                return GetQuery<TEntity>().Where(predicate).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<TEntity> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await context.Set<TEntity>().FirstAsync();
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                context.Set<TEntity>().Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            try
            {
                return await context.Set<TEntity>().CountAsync(predicate);
            }
            catch(Exception e)
            {
                throw;
            }
           
        }


        /// <summary>
        /// Ajout d'une entrée à la table {entity}
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            
            try
            {
                //string baseEntityName = GetEntitySetName<TEntity>(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Modification d'une entrée de la table {entity}
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <remarks></remarks>
        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        /// <summary>
        /// Supprime une entrée de la table entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                //context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.Set<TEntity>().Remove(entity);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IQueryable<TEntity> FindQueryable<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            try
            {
                return GetQuery<TEntity>().AsExpandable().Where(predicate);
            }
            catch (Exception e)
            {
                throw;
            }
        }



        /// <summary>
        /// Sauvegarde  tous les changements après modification
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (ArgumentNullException argEx)
            {
                throw;
            }

        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            try
            {
                return await context.Set<TEntity>().AnyAsync(predicate);
            }
            #region Exception
            catch (Exception e)
            {
                throw;
            }
            #endregion Exception
        }


        /// <summary>
        /// Libère toutes les ressources
        /// </summary>
        public void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Libère toutes les ressources
        /// </summary>
        /// <param name="disposing">  true :  Libère toutes les ressources </param>
        protected virtual void Dispose(bool disposing)
        {
        }

       
    }
}
