using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Model:IEntity
    {
        #region Properties
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Production { get; set; }
        public string Color { get; set; }
        public int Mph { get; set; }
        #endregion


    }
}
