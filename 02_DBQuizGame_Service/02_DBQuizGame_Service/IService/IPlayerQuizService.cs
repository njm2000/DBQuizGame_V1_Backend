using _02_DBQuizGame_Service.Request;
using _02_DBQuizGame_Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.IService
{
    public interface IPlayerQuizService
    {
        #region Generic Functions
        public IEnumerable<DTO.PlayerQuiz> GetAll();
        public IEnumerable<DTO.PlayerQuiz> GetActive();
        public IEnumerable<DTO.PlayerQuiz> GetTerminated();
        public DTO.PlayerQuiz GetById(Guid id);
        public void Create(DTO.PlayerQuiz entity);
        public void Update(DTO.PlayerQuiz updatedEntity);
        public void Delete(Guid id);
        public void Terminate(Guid id);
        public void Reactivate(Guid id);
        #endregion

        #region Custom Functions
        public ViewQuizResponse ViewQuiz(ViewQuizRequest request);

        public SavePlayerQuizResponse SavePlayerQuiz(SavePlayerQuizRequest request);

        #endregion
    }
}
