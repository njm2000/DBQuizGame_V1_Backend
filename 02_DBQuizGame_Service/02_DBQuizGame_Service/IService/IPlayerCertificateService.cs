using _02_DBQuizGame_Service.Request;
using _02_DBQuizGame_Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.IService
{
    public interface IPlayerCertificateService
    {
        #region Generic Functions
        public IEnumerable<DTO.PlayerCertificate> GetAll();
        public IEnumerable<DTO.PlayerCertificate> GetActive();
        public IEnumerable<DTO.PlayerCertificate> GetTerminated();
        public DTO.PlayerCertificate GetById(Guid id);
        //public IEnumerable<DTO.PlayerCertificate> GetByIdPlayer(Guid id);
        //public DTO.PlayerCertificate GetByIdCertificate(Guid id);
        public void Create(DTO.PlayerCertificate entity);
        public void Update(DTO.PlayerCertificate updatedEntity);
        public void Delete(Guid id);
        public void Terminate(Guid id);
        public void Reactivate(Guid id);
        #endregion

        #region Custom Functions
        public SavePlayerCertificateResponse SavePlayerCertificate(SavePlayerCertificateRequest request);
        public ViewPlayerCertificateResponse ViewPlayerCertificate(ViewPlayerCertificateRequest request);

        #endregion
    }
}
