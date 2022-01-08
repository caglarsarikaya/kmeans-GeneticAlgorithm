using Business.Abstract;
using Core.Abstract;
using Data.Domain.Entities;
using Data.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<Vehicle> _repository;
        private readonly IUnitOfWork _uow;
        public VehicleService(IRepository<Vehicle> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public void Delete(int id)
        {
            _repository.RemoveById(id);
            _uow.SaveChanges();
        }

        public  IEnumerable<Vehicle> GetAll()
        {
            return  _repository.GetAll();
        }

        public  void Insert(Vehicle vehicle)
        {
             _repository.Add(vehicle);
             _uow.SaveChangesAsync();
        }

        public void Update(Vehicle vehicle)
        {
            _repository.Update(vehicle);
            _uow.SaveChanges();
        }
    }
}
