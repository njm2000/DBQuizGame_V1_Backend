using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.IService
{
    public interface IOptionService
    {
        #region Generic Functions
        public IEnumerable<DTO.Option> GetAll();
        public IEnumerable<DTO.Option> GetActive();
        public IEnumerable<DTO.Option> GetTerminated();
        public DTO.Option GetById(Guid id);
        public DTO.Option GetByName(string name);
        public IEnumerable<DTO.Option> ContainsName(string name);
        public IEnumerable<DTO.Option> ContainsDescription(string keyword);
        public void Create(DTO.Option entity);
        public void Update(DTO.Option updatedEntity);
        public void Delete(Guid id);
        public void Terminate(Guid id);
        public void Reactivate(Guid id);
        #endregion

        #region Custom Functions
        #endregion
    }
}
