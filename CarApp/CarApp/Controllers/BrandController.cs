using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helper;

namespace CarApp.Controllers
{
    internal class BrandController
    {
        private BrandService _brandService;

        public BrandController()
        {
            _brandService = new BrandService();
        }
        public void ModelAddBrand()
        {

            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Brand id: ");
            int id = Extention.TryParseMethod();           
            Extention.Print(ConsoleColor.DarkCyan, "Model id: ");
            int id1 = Extention.TryParseMethod();
            //ModelController ModelController = new ModelController();

            //BrandService.CreateBrandModels(ModelController.GetModel(id1), id);

        }


        public void AddModelInBrand()
        {

            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Brand id: ");
            int id = Extention.TryParseMethod();
            
            //ModelController ModelController = new ModelController();
            //Model Model = ModelController.CreatModel();

            //BrandService.CreateBrandModels(Model, id);

        }

        public void CreateBrand()
        {

            Extention.Print(ConsoleColor.DarkCyan, "Brand Name: ");
            string name = Extention.TryEmptyMethod();            

            Brand brand = new Brand()
            {
                Name = name,                
            };
           
            _brandService.Create(brand);
            Extention.Print(ConsoleColor.Green, $"{brand.Name} created");

        }

        public void UpdateBrand()
        {
            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Brand ID: ");
            int id = Extention.TryParseMethod();
            _brandService.GetOne(id);
            Extention.Print(ConsoleColor.DarkCyan, "Brand Name: ");
            string name = Extention.TryEmptyMethod();
            

            Brand brand = new Brand()
            {
                Name = name,              
            };
            _brandService.Update(brand, id);
        }
        public void GetAllBrand()
        {
            foreach (var item in _brandService.GetAll())
            {
                Extention.Print(ConsoleColor.Green, $"{item.Name}");
            }
        }
        public void GetBrand()
        {
            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Brand ID: ");
            int id = Extention.TryParseMethod();
            Extention.Print(ConsoleColor.Green, "Brand Name");
            Extention.Print(ConsoleColor.Green, $"{_brandService.GetOne(id).Name}");
           
            foreach (var item in _brandService.GetOne(id).Model)
            {               
                Extention.Print(ConsoleColor.Green, $"Model name: {item.Name}\n" +
                    $"Model price: {item.Price}\n" +
                    $"Model production: {item.Production}\n" +
                    $"Model color: {item.Color}\n" +
                    $"Model MPH: {item.Mph}");
            }

        }

        public void RemoveBrand()
        {
            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Brand Id: ");
            int id = Extention.TryParseMethod();
            Brand brand = _brandService.Delete(id);
            Extention.Print(ConsoleColor.Green, $"{brand.Name}");
        }
    }
}
