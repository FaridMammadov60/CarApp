using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private AvtoSalonRepository _avtoRepository;

        public AvtoSalonService()
        {
            _avtoRepository=new AvtoSalonRepository();
        }
        public AvtoSalon Create(AvtoSalon entity)
        {
            throw new NotImplementedException();
        }

        public AvtoSalon Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AvtoSalon> GetAll()
        {
            throw new NotImplementedException();
        }

        public AvtoSalon GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public AvtoSalon Update(AvtoSalon entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
