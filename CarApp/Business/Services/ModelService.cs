using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helper;

namespace Business.Services
{
    public class ModelService:IService<Model>
    {
        //Model yaranan zaman fərqli id-də olması üçün Create methodunda count++ qeyd edilib
        public static int Count { get; set; }
        //yaradılmış model-lərin sayın tapmaq və model sıfırdısa remove update kimi methodların istifadəsinin
        //qarşısın almaq üçün create methodunda counter ++ remove methodunda isə counter-- qeyd edilib
        public static int Counter { get; set; }

        //ModelRepository-daki methodlari cagirmaq ucun istifade eedilecek
        private ModelRepository _modelRepository;

        //Constructor
        public ModelService()
        {
            _modelRepository = new ModelRepository();
        }
        /// <summary>
        /// Method çağrılarkın Model isteyir və model.id counta bərabər edir
        /// Model yaratmaq üçün modelepositoriyə gonderir və
        /// Count və counteri ++ edir
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Model Create(Model entity)
        {
            try
            {
                entity.Id = Count;
                _modelRepository.Create(entity);
                Count++;
                Counter++;
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Method çağrılarkın id isteyir və id-yə uyğun modeli tapır əgər id-yə uyğun model yoxdursa null qaytarır
        /// Tapılmış modeli silmək üçün modelrepositoriyə gonderir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model Delete(int id)
        {
            try
            {
                Model isExist = _modelRepository.GetOne(g => g.Id == id);
                if (isExist == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return null;
                }
                _modelRepository.Delete(isExist);
                if (isExist.BrandId!=null)
                {
                    //baxilmali
                }
                Counter--;
                return isExist;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Butun modelləri geri qaytarmaq üçün modelRepositorinin getAll methodun çağırır
        /// </summary>
        /// <returns></returns>
        public List<Model> GetAll()
        {
            try
            {
                return _modelRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Method çağrılarkən id istəyir və həmin id üzrə modeli geri qaytarmaq üçün modelRepository çağırır
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model GetOne(int id)
        {
            try
            {
                return _modelRepository.GetOne(g => g.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Methodu çağırarkən Model və id istəyir və id üzrə modelRepositor.getOne methodun çağırır
        /// əgər id-yə uyğun brand yoxdursa null qaytarır
        /// Tapılmış modelə yeni məlumatlar mənimsədilir və update üçün modelrepositoryə göndərilir 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model Update(Model entity, int id)
        {
            try
            {
                Model isExist = _modelRepository.GetOne(g => g.Id == id);
                if (isExist == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return null;
                }
                isExist.Name = entity.Name;
                isExist.Price = entity.Price;
                isExist.Mph = entity.Mph;
                isExist.Color=entity.Color;
                isExist.Production=entity.Production;
                _modelRepository.Update(entity);
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
