using System;
using System.Collections.Generic;

namespace ApiDemo.Domain.Model.ClienteAggregate
{
    /// <summary>
    /// 
    /// </summary>
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public void Add(Cliente cliente)
        {
            try
            {
                _repository.Add(cliente);
                _repository.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Cliente> GetAll()
        {
            return _repository.GetAll();
        }

        public Cliente GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public void Remove(Cliente cliente)
        {
            _repository.Remove(cliente);
            _repository.SaveChanges();
        }
        public void Update(Cliente cliente)
        {
            _repository.Update(cliente);
            _repository.SaveChanges();
        }
    }
}
