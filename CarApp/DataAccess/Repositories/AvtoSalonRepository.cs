using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AvtoSalonRepository : IRepository<AvtoSalon>
    {
        /// <summary>
        /// Method çağrılarkən Avtosalon istəyir və DataContext-dəki AvtoSalon listində Avtosalon yaradır və ya əlavə edir
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Create(AvtoSalon entity)
        {
            try
            {
                DataContext.AvtoSalons.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Method çağrılarkən Avtosalon istəyir və DataContext-dəki Avtosalon listindəki seçilmiş avtosalon-i silir
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(AvtoSalon entity)
        {
            try
            {
                DataContext.AvtoSalons.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// DataContext-dəki Avtosalon listinin hamısın geri qaytarır
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        
        public List<AvtoSalon> GetAll(Predicate<AvtoSalon> filter = null)
        {
            try
            {
                return filter == null ? DataContext.AvtoSalons :
                    DataContext.AvtoSalons.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// DataContext-dəki Avtosalon listindəki bir avtosalonu geri qaytarır
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        
        public AvtoSalon GetOne(Predicate<AvtoSalon> filter = null)
        {
            try
            {
                return filter == null ? null :
                    DataContext.AvtoSalons.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Method çağrılarkən Avtosalon istəyir və DataContext-dəki Avtosalon listindəki seçilmiş 
        /// avtosalon-un məlumatların dəyişir
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
       
        public bool Update(AvtoSalon entity)
        {
            try
            {
                AvtoSalon isExsist = GetOne(g => g.Id == entity.Id);
                isExsist = entity;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool CreateModelIntoAvtoSalon(Model entity)
        {
            try
            {
                List<AvtoSalon> isExist = DataContext.AvtoSalons.FindAll(s => s.Id == entity.AvtoSalonId);
                AvtoSalon avto = DataContext.AvtoSalons.Find(f => f.Id == entity.AvtoSalonId);
                avto.Model.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteModel(AvtoSalon brand, Model model)
        {
            try
            {
                foreach (var item in DataContext.AvtoSalons)
                {
                    if (brand.Id == model.AvtoSalonId)
                    {
                        item.Model.Remove(model);
                    }
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
