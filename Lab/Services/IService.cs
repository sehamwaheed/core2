using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Services
{
    public interface IService<T>
    {
        public List<T> GetAll();
        public T Add(T elment);
        public void Edit(T elment);
        public void Delete(int elment);
        public T Details(int id);
       
    }
}
