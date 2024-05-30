using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.IService
{
    public interface IQuestionService
    {
        #region Generic Functions
        public IEnumerable<DTO.Question> GetAll();
        public IEnumerable<DTO.Question> GetActive();
        public IEnumerable<DTO.Question> GetTerminated();
        public DTO.Question GetById(Guid id);
        public DTO.Question GetByName(string name);
        public IEnumerable<DTO.Question> ContainsName(string name);
        public IEnumerable<DTO.Question> ContainsDescription(string keyword);
        public void Create(DTO.Question entity);
        public void Update(DTO.Question updatedEntity);
        public void Delete(Guid id);
        public void Terminate(Guid id);
        public void Reactivate(Guid id);
        #endregion

        #region Custom Functions
        #endregion
    }
}
