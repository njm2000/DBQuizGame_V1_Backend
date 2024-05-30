using _01_DBQuizGame_Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.IService
{
    public interface IAdminService
    {
        #region Generic Functions
        public IEnumerable<DTO.Admin> GetAll();
        public IEnumerable<DTO.Admin> GetActive();
        public IEnumerable<DTO.Admin> GetTerminated();
        public DTO.Admin GetById(Guid id);
        public DTO.Admin GetByName(string name);
        public IEnumerable<DTO.Admin> ContainsName(string name);
        public IEnumerable<DTO.Admin> ContainsDescription(string keyword);
        public void Create(DTO.Admin entity);
        public void Update(DTO.Admin updatedEntity);
        public void Delete(Guid id);
        public void Terminate(Guid id);
        public void Reactivate(Guid id);
        #endregion

        #region Custom Functions
        #endregion
    }
}
