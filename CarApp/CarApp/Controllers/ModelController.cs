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
    internal class ModelController
    {
        public ModelService _modelService;
        public ModelController()
        {
            _modelService = new ModelService();
        }
        public Model CreatModelinBrand()
        {
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Name: ");
            string name = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Color: ");
            string color = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Production: ");
            int production = Extention.TryParseMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Mph: ");
            int mph = Extention.TryParseMethod();
            //baxilmali
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Price: ");
            int price = Extention.TryParseMethod();

            Model model = new Model()
            {
                Name = name,
                Color = color,
                Production = production,
                Mph = mph,
                Price = price
            };

            _modelService.Create(model);
            Extention.Print(ConsoleColor.Green, $"{model.Name} created");
            return model;
        }
        public void ModelCreat()
        {
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Name: ");
            string name = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Color: ");
            string color = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Production: ");
            int production = Extention.TryParseMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Mph: ");
            int mph = Extention.TryParseMethod();
            //baxilmali
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Price: ");
            int price = Extention.TryParseMethod();

            Model model = new Model()
            {
                Name = name,
                Color = color,
                Production = production,
                Mph = mph,
                Price = price
            };

            _modelService.Create(model);
            Extention.Print(ConsoleColor.Green, $"{model.Name} created");
        }

        public void GetAllModel()
        {
            foreach (var item in _modelService.GetAll())
            {
                Extention.Print(ConsoleColor.Green, $"Model name: {item.Name}\n" +
                    $"Model price: {item.Price}$\n" +
                    $"Model production: {item.Production}\n" +
                    $"Model color: {item.Color}\n" +
                    $"Model MPH: {item.Mph}mph");
            }
        }
        public void UpdateModel()
        {
            if (ModelService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Model not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Id: ");
            int id = Extention.TryParseMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Name: ");
            string name = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Color: ");
            string color = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Production: ");
            int production = Extention.TryParseMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Mph: ");
            int mph = Extention.TryParseMethod();
            //baxilmali
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Price: ");
            int price = Extention.TryParseMethod();

            Model model = new Model()
            {
                Name = name,
                Color = color,
                Production = production,
                Mph = mph,
                Price = price
            };
            model.BrandId = _modelService.GetOne(id).BrandId;
            _modelService.Update(model, id);
        }

        public void RemoveModel()
        {
            if (ModelService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Model not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Model Id: ");
            int id = Extention.TryParseMethod();
            Model Model = _modelService.Delete(id);
            Extention.Print(ConsoleColor.Green, $"{Model.Name}");
        }

        public Model GetModel(int id)
        {
            if (ModelService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Model not available");
                return null;
            }            
            return _modelService.GetOne(id);

        }
    }
}
