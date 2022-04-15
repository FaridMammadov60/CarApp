using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ModelRepository : IRepository<Model>
    {
        /// <summary>
        /// Servisden gelen modeli yaratmaq ucun
        /// </summary>
        /// <param name="entity">Servisden gelen model</param>
        /// <returns></returns>
        public bool Create(Model entity)
        {
            try
            {
                DataContext.Models.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// servisden gelen modeli modellerden silmek ucun
        /// </summary>
        /// <param name="entity">Servisden gelen model</param>
        /// <returns></returns>
        public bool Delete(Model entity)
        {
            try
            {
                DataContext.Models.Add(entity);
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Butun modelleri tapmaq ucun
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Model> GetAll(Predicate<Model> filter = null)
        {
            try
            {
                return filter==null?null:
                    DataContext.Models.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Modellerden birin tapmaq ucun
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Model GetOne(Predicate<Model> filter = null)
        {
            try
            {
                return filter == null ? null :
                DataContext.Models.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Servisden gelen modeli deyismek ucun
        /// </summary>
        /// <param name="entity">Servisden gelen model</param>
        /// <returns></returns>
        public bool Update(Model entity)
        {
            try
            {
                Model isExist = GetOne(s => s.Id == entity.Id);
                isExist = entity;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
