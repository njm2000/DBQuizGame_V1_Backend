using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.IService
{
    public interface IQuestionTypeService
    {
        #region Generic Functions
        public IEnumerable<DTO.QuestionType> GetAll();
        public IEnumerable<DTO.QuestionType> GetActive();
        public IEnumerable<DTO.QuestionType> GetTerminated();
        public DTO.QuestionType GetById(int id);
        public DTO.QuestionType GetByName(string name);
        public IEnumerable<DTO.QuestionType> ContainsName(string name);
        public IEnumerable<DTO.QuestionType> ContainsDescription(string keyword);
        public void Create(DTO.QuestionType entity);
        public void Update(DTO.QuestionType updatedEntity);
        public void Delete(int id);
        public void Terminate(int id);
        public void Reactivate(int id);
        #endregion

        #region Custom Functions
        #endregion
    }
}
