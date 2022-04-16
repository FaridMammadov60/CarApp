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
    public class AvtoSalonService : IService<AvtoSalon>
    {
        //Brand yaranan zaman fərqli id-də olması üçün Create methodunda count++ qeyd edilib
        public static int Count { get; set; }
        //yaradılmış brand-lərin sayın tapmaq və brand sıfırdısa remove update kimi methodların istifadəsinin
        //qarşısın almaq üçün create methodunda counter ++ remove methodunda isə counter-- qeyd edilib
        public static int Counter { get; set; }

        //BrandRepository-dəki methodları çagırmaq üçün istifade edilecək
        private AvtoSalonRepository _avtoSalonRepository;

        public AvtoSalonService()
        {
            _avtoSalonRepository=new AvtoSalonRepository();
        }
        /// <summary>
        /// Method çağrılarkın Avtosalon isteyir və avtosalon.id counta bərabər edir
        /// Avtosalon yaratmaq üçün avtosalonrepositoriyə gonderir və
        /// Count və counteri ++ edir
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public AvtoSalon Create(AvtoSalon entity)
        {
            try
            {
                entity.Id = Count;
                _avtoSalonRepository.Create(entity);
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
        /// Method çağrılarkın id isteyir və id-yə uyğun avtosalon tapır əgər id-yə uyğun brand yoxdursa null qaytarır
        /// Tapılmış Avtosalon silmək üçün avtoSalonrepositoriyə gonderir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AvtoSalon Delete(int id)
        {
            try
            {
                AvtoSalon isExist = _avtoSalonRepository.GetOne(g => g.Id == id);
                if (isExist == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return null;
                }
                _avtoSalonRepository.Delete(isExist);
                Counter--;
                return isExist;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Butun avtosalonları geri qaytarmaq üçün avtoSalonRepositorinin getAll methodun çağırır
        /// </summary>
        /// <returns></returns>
        public List<AvtoSalon> GetAll()
        {
            try
            {
                return _avtoSalonRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Method çağrılarkən id istəyir və həmin id üzrə avtosalonu geri qaytarmaq üçün avtoSalonRepository çağı
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AvtoSalon GetOne(int id)
        {
            try
            {
                return _avtoSalonRepository.GetOne(g => g.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Methodu çağırarkən AvtoSalon və id istəyir və id üzrə avtSalonRepositor.getOne methodun çağırır
        /// əgər id-yə uyğun avtosalon yoxdursa null qaytarır
        /// Tapılmış avtosalona yeni məlumatlar mənimsədilir və update üçün avtosalonrepositoriyə göndərilir  
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public AvtoSalon Update(AvtoSalon entity, int id)
        {
            try
            {
                AvtoSalon isExist = _avtoSalonRepository.GetOne(g => g.Id == id);
                if (isExist == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return null;
                }
                isExist.Name = entity.Name;
                _avtoSalonRepository.Update(entity);
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
