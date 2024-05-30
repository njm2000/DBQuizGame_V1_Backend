using _01_DBQuizGame_Persistence.Entity;
using _02_DBQuizGame_Service.Request;
using _02_DBQuizGame_Service.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.IService
{
    public interface IPlayerService
    {
        #region Generic Functions
        public IEnumerable<DTO.Player> GetAll();
        public IEnumerable<DTO.Player> GetActive();
        public IEnumerable<DTO.Player> GetTerminated();
        public DTO.Player GetById(Guid id);
        public DTO.Player GetByName(string name);
        public IEnumerable<DTO.Player> ContainsName(string name);
        public IEnumerable<DTO.Player> ContainsDescription(string keyword);
        public void Create(DTO.Player entity);
        public void Update(DTO.Player updatedEntity);
        public void Delete(Guid id);
        public void Terminate(Guid id);
        public void Reactivate(Guid id);
        #endregion

        #region Custom Functions
        public ValidatePlayerLoginResponse ValidatePlayerLogin(ValidatePlayerLoginRequest request);
        public ViewLeaderboardResponse ViewLeaderboard();

        #endregion
    }
}
