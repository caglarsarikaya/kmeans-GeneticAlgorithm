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
    public class ContainerService : IContainerService
    {
        private readonly IRepository<Container> _repository;
        private readonly IUnitOfWork _uow;

        public ContainerService(IRepository<Container> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }
        public void Delete(int id)
        {
            _repository.RemoveById(id);
            _uow.SaveChanges();
        }

        public  IEnumerable<Container> GetAll()
        {
            return  _repository.GetAll();
        }

        public   void Insert(Container container)
        {
             _repository.Add(container);
             _uow.SaveChangesAsync();    
        }

        public void Update(Container container)
        {
            _repository.Update(container);
            _uow.SaveChanges(); 
        }
    }
}
