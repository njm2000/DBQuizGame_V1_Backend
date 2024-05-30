using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.IService
{
    public interface IObjectStateService
    {
        #region Generic Functions
        public IEnumerable<DTO.ObjectState> GetAll();
        public DTO.ObjectState GetById(int id);
        public DTO.ObjectState GetByName(string name);
        public IEnumerable<DTO.ObjectState> ContainsName(string name);
        public IEnumerable<DTO.ObjectState> ContainsDescription(string keyword);
        public void Create(DTO.ObjectState entity);
        public void Update(DTO.ObjectState updatedEntity);
        public void Delete(int id);
        #endregion

        #region Custom Functions
        #endregion
    }
}

