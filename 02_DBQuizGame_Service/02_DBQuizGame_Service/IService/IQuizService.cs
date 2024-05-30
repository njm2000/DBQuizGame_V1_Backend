using _02_DBQuizGame_Service.Request;
using _02_DBQuizGame_Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.IService
{
    public interface IQuizService
    {
        #region Generic Functions
        public IEnumerable<DTO.Quiz> GetAll();
        public IEnumerable<DTO.Quiz> GetActive();
        public IEnumerable<DTO.Quiz> GetTerminated();
        public DTO.Quiz GetById(Guid id);
        public DTO.Quiz GetByName(string name);
        public IEnumerable<DTO.Quiz> ContainsName(string name);
        public IEnumerable<DTO.Quiz> ContainsDescription(string keyword);
        public void Create(DTO.Quiz entity);
        public void Update(DTO.Quiz updatedEntity);
        public void Delete(Guid id);
        public void Terminate(Guid id);
        public void Reactivate(Guid id);
        #endregion

        #region Custom Functions
        public GenerateRandomQuestionResponse GenerateRandomQuestion(GenerateRandomQuestionRequest request);

        #endregion
    }
}
