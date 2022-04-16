using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AvtoSalon:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Brand> Brand { get; set; }

        #region MyRegion
        public AvtoSalon()
        {
            Brand = new List<Brand>();
        }
        #endregion


    }
}
