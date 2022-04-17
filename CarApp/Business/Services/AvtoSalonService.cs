using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using Utilities.Helper;

namespace Business.Services
{
    public class AvtoSalonService : IService<AvtoSalon>
    {
        //Brand yaranan zaman fərqli id-də olması üçün Create methodunda count++ qeyd edilib
        public static int Count { get; set; }
        //yaradılmış avtosalon-larin sayın tapmaq və avtosalon sıfırdısa remove update kimi methodların istifadəsinin
        //qarşısın almaq üçün create methodunda counter ++ remove methodunda isə counter-- qeyd edilib
        public static int Counter { get; set; }

        //BrandRepository-dəki methodları çagırmaq üçün istifade edilecək
        private AvtoSalonRepository _avtoSalonRepository;

        public AvtoSalonService()
        {
            _avtoSalonRepository = new AvtoSalonRepository();
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
        /// Method çağrılarkın id isteyir və id-yə uyğun avtosalon tapır əgər id-yə uyğun avtosalon yoxdursa null qaytarır
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
        /// Method çağrılarkən string name istəyir və həmin name üzrə avtosalonu geri qaytarmaq üçün avtoSalonRepository çağırir
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public AvtoSalon GetOne(string name)
        {
            try
            {
                return _avtoSalonRepository.GetOne(g => g.Name == name);
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
        /// <summary>
        /// Method çağrılarkəm model və id isteyir və Avtosalonda model yaratmaq ucun repositoriyə göndərir
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public AvtoSalon CreatModelIntoBrand(Model model, int id)
        {
            try
            {
                AvtoSalon avto = _avtoSalonRepository.GetOne(g => g.Id == id);
                
                if (avto == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return null;
                }
                else if (avto.Size<=avto.CarCount)
                {
                    Extention.Print(ConsoleColor.Red, "Limit");
                    return null;
                }
                avto.CarCount++;
                model.AvtoSalonId = id;
                _avtoSalonRepository.CreateModelIntoAvtoSalon(model);
                return avto;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Avtosalondaki modeli tapıb silinmek ucun repositoriyə gonderir
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public AvtoSalon RemoveModelInAvtoSalon(Model model)
        {
            try
            {
                AvtoSalon isExist = _avtoSalonRepository.GetOne(g => g.Id == model.AvtoSalonId);
                if (isExist == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return null;
                }
                _avtoSalonRepository.DeleteModel(isExist, model);
                isExist.CarCount--;
                return isExist;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
