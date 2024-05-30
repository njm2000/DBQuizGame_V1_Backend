using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.IService
{
    public interface ICertificateService
    {
        #region Generic Functions
        public IEnumerable<DTO.Certificate> GetAll();
        public IEnumerable<DTO.Certificate> GetActive();
        public IEnumerable<DTO.Certificate> GetTerminated();
        public DTO.Certificate GetById(Guid id);
        public DTO.Certificate GetByName(string name);
        public IEnumerable<DTO.Certificate> ContainsName(string name);
        public IEnumerable<DTO.Certificate> ContainsDescription(string keyword);
        public void Create(DTO.Certificate entity);
        public void Update(DTO.Certificate updatedEntity);
        public void Delete(Guid id);
        public void Terminate(Guid id);
        public void Reactivate(Guid id);
        #endregion

        #region Custom Functions
        #endregion
    }
}
