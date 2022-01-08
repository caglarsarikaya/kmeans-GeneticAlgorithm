﻿using Business.Abstract;
using Core.Abstract;
using Core.Clustering;
using Data.Domain.Entities;
using Data.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InformationService : IInformationService
    {
        private readonly IRepository<Container> _containerRepository;
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IRepository<ContainerCluster> _containerClusterRepository;
        private readonly IUnitOfWork _uow;

        public InformationService(
            IRepository<Container> containerRepository,
            IRepository<Vehicle> vehicleRepository,
            IRepository<ContainerCluster> containerClusterRepository,
             IUnitOfWork uow
            )
        {
            _containerRepository = containerRepository;
            _vehicleRepository = vehicleRepository;
            _containerClusterRepository = containerClusterRepository;
            _uow = uow;
        }

        public List<ContainerCluster> CreateClusters(int clusterCount)
        {
            var containers = _containerRepository.GetAll();
            var clusterList = new List<ContainerCluster>();
            foreach (var con in containers)
            {
                clusterList.Add(new ContainerCluster { ContainerId = con.Id, LocationX = con.LocationX, LocationY = con.LocationY });
            }

            var kmeans = new KMeans();
            var res = kmeans.Cluster(clusterList, clusterCount);



            var savedClusters = _containerClusterRepository.GetAll();
            _uow.TrackerClear();
             foreach(var willRecord in res)
            {
                var updateable = savedClusters.Where(x => x.ContainerId == willRecord.ContainerId).SingleOrDefault();
                if(updateable != null)
                {
                    willRecord.Id = updateable.Id;  
                    _containerClusterRepository.Update(willRecord);
                }
                else
                {
                    _containerClusterRepository.Add(willRecord);
                }
            }
            _uow.SaveChanges();


            return res;
        }

        public  List<Container> GetVehicleRoute(int id)
        {
            var containers =  _containerRepository.GetAll();
            return containers.Where(x => x.VehicleId == id).ToList();
        }
    }
}
