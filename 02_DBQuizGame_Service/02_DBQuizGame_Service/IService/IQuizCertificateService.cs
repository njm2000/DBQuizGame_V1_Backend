using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.IService
{
    public interface IQuizCertificateService
    {
        #region Generic Functions
        public IEnumerable<DTO.QuizCertificate> GetAll();
        public IEnumerable<DTO.QuizCertificate> GetActive();
        public IEnumerable<DTO.QuizCertificate> GetTerminated();
        public DTO.QuizCertificate GetById(Guid id);
        public void Create(DTO.QuizCertificate entity);
        public void Update(DTO.QuizCertificate updatedEntity);
        public void Delete(Guid id);
        public void Terminate(Guid id);
        public void Reactivate(Guid id);
        #endregion

        #region Custom Functions
        #endregion
    }
}
