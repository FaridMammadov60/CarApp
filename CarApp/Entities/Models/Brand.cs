using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Brand:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Model> Model { get; set; }
        
        public Brand()
        {
            Model = new List<Model>();
        }
    }
}
