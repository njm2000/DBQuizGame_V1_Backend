using _01_DBQuizGame_Persistence.Entity;
using _02_DBQuizGame_Service.IService;
using _02_DBQuizGame_Service.Request;
using _02_DBQuizGame_Service.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly DBQuizGameContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;

        public PlayerService(DBQuizGameContext dbQuizGameContext, IMapper mapper)
        {
            _context = dbQuizGameContext;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Player, DTO.Player>().ReverseMap();
            });
            _mapper = _mapperConfig.CreateMapper();
        }

        #region Generic Functions

        public IEnumerable<DTO.Player> GetAll()
        {
            return _mapper.Map<IEnumerable<Player>, IEnumerable<DTO.Player>>(
                _context.Players.ToList()
                );
        }

        public IEnumerable<DTO.Player> GetActive()
        {
            return _mapper.Map<IEnumerable<Player>, IEnumerable<DTO.Player>>(
                _context.Players.Where(x => x.IdObjectState == 1).ToList()
                );
        }
        public IEnumerable<DTO.Player> GetTerminated()
        {
            return _mapper.Map<IEnumerable<Player>, IEnumerable<DTO.Player>>(
                _context.Players.Where(x => x.IdObjectState == 2).ToList()
                );
        }

        public DTO.Player GetById(Guid id)
        {
            return _mapper.Map<Player, DTO.Player>(
                 _context.Players.SingleOrDefault(x => x.IdPlayer == id)
                );
        }

        public DTO.Player GetByName(string name)
        {
            return _mapper.Map<Player, DTO.Player>(
                 _context.Players.SingleOrDefault(x => x.Name == name)
                );
        }

        public IEnumerable<DTO.Player> ContainsName(string keyword)
        {
            return _mapper.Map<IEnumerable<Player>, IEnumerable<DTO.Player>>(
                _context.Players.Where(x => x.Name.Contains(keyword)).ToList()
                );
        }

        public IEnumerable<DTO.Player> ContainsDescription(string keyword)
        {
            return _mapper.Map<IEnumerable<Player>, IEnumerable<DTO.Player>>(
                _context.Players.Where(x => x.Description.Contains(keyword)).ToList()
                );
        }

        public void Create(DTO.Player entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _context.Add(_mapper.Map<DTO.Player, Player>(entity));
            _context.SaveChanges();
        }

        public void Update(DTO.Player updatedEntity)
        {
            updatedEntity.UpdatedDate = DateTime.UtcNow;
            _context.Update(_mapper.Map<DTO.Player, Player>(updatedEntity));
            _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                _context.Remove(_mapper.Map<DTO.Player, Player>(entity));
                _context.SaveChanges();
            }
        }

        public void Terminate(Guid id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                entity.UpdatedDate = DateTime.UtcNow;
                entity.IdObjectState = 2;
                Update(entity);
            }
        }

        public void Reactivate(Guid id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                entity.UpdatedDate = DateTime.UtcNow;
                entity.IdObjectState = 1;
                Update(entity);
            }
        }

        #endregion

        #region Custom Functions
        public ValidatePlayerLoginResponse ValidatePlayerLogin(ValidatePlayerLoginRequest request)
        {
            ValidatePlayerLoginResponse response = new ValidatePlayerLoginResponse();

            var player = GetByName(request.Name);
            
            if (player != null && player.MatricsNo == request.MatricsNo)
            {
                response.Player = player;
                response.IsLoginValid = true;
            }
            else
            {
                response.IsLoginValid = false;
                response.ErrorMessage = "Invalid Player Credentials! Unable to login to game!";
            }

            return response;
        }

        public ViewLeaderboardResponse ViewLeaderboard()
        {
            ViewLeaderboardResponse response = new ViewLeaderboardResponse();

            var sortedPlayerList = GetAll().OrderByDescending(x => x.TotalPoints).ToList();

            response.SortedPlayerList = sortedPlayerList;

            return response;
        }

        #endregion
    }
}
