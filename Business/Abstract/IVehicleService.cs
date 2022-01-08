using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> GetAll();
        void Insert(Vehicle vehicle);
        void Delete(int id);
        void Update(Vehicle vehicle);
    }
}
