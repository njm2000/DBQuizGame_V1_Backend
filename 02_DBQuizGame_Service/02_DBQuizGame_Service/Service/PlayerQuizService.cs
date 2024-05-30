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
    public class PlayerQuizService : IPlayerQuizService
    {
        private readonly DBQuizGameContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;
        private readonly IQuizService _quizService;
        private readonly IPlayerService _playerService;

        public PlayerQuizService(DBQuizGameContext dbQuizGameContext, IMapper mapper, IQuizService quizService, IPlayerService playerService)
        {
            _context = dbQuizGameContext;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlayerQuiz, DTO.PlayerQuiz>().ReverseMap();
            });
            _mapper = _mapperConfig.CreateMapper();
            _quizService = quizService;
            _playerService = playerService;
        }

        #region Generic Functions

        public IEnumerable<DTO.PlayerQuiz> GetAll()
        {
            return _mapper.Map<IEnumerable<PlayerQuiz>, IEnumerable<DTO.PlayerQuiz>>(
                _context.PlayerQuizzes.ToList()
                );
        }

        public IEnumerable<DTO.PlayerQuiz> GetActive()
        {
            return _mapper.Map<IEnumerable<PlayerQuiz>, IEnumerable<DTO.PlayerQuiz>>(
                _context.PlayerQuizzes.Where(x => x.IdObjectState == 1).ToList()
                );
        }
        public IEnumerable<DTO.PlayerQuiz> GetTerminated()
        {
            return _mapper.Map<IEnumerable<PlayerQuiz>, IEnumerable<DTO.PlayerQuiz>>(
                _context.PlayerQuizzes.Where(x => x.IdObjectState == 2).ToList()
                );
        }

        public DTO.PlayerQuiz GetById(Guid id)
        {
            return _mapper.Map<PlayerQuiz, DTO.PlayerQuiz>(
                 _context.PlayerQuizzes.SingleOrDefault(x => x.IdPlayerQuiz == id)
                );
        }

        public void Create(DTO.PlayerQuiz entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _context.Add(_mapper.Map<DTO.PlayerQuiz, PlayerQuiz>(entity));
            _context.SaveChanges();
        }

        public void Update(DTO.PlayerQuiz updatedEntity)
        {
            updatedEntity.UpdatedDate = DateTime.UtcNow;
            _context.Update(_mapper.Map<DTO.PlayerQuiz, PlayerQuiz>(updatedEntity));
            _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                _context.Remove(_mapper.Map<DTO.PlayerQuiz, PlayerQuiz>(entity));
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
        public ViewQuizResponse ViewQuiz(ViewQuizRequest request)
        {
            ViewQuizResponse response = new ViewQuizResponse();
            List<DTO.PlayerQuiz> playerQuizRecords = new List<DTO.PlayerQuiz>();

            var availableQuizzes = _quizService.GetAll().ToList();
            var allQuizRecords = GetAll().ToList();

            foreach (var quiz in availableQuizzes)
            {
                var playerQuizRecord = allQuizRecords.SingleOrDefault(x => x.IdQuiz == quiz.IdQuiz && x.IdPlayer == request.IdPlayer);

                if (playerQuizRecord != null)
                {
                    playerQuizRecords.Add(playerQuizRecord);
                }
            }

            response.Quizzes = availableQuizzes;
            response.PlayerQuizRecords = playerQuizRecords;

            return response;
        }

        public SavePlayerQuizResponse SavePlayerQuiz(SavePlayerQuizRequest request)
        {
            SavePlayerQuizResponse response = new SavePlayerQuizResponse();
            List<DTO.PlayerQuiz> quizList = new List<DTO.PlayerQuiz>();
            DTO.PlayerQuiz quiz = new DTO.PlayerQuiz();
            DTO.Player player = new DTO.Player();

            if (request.IdPlayer != Guid.Empty && request.QuizName != null && request.TotalScore != null && request.TimeTaken != null && request.PointsAcquired != null)
            {
                quiz.IdPlayer = request.IdPlayer;
                quiz.IdQuiz = _quizService.GetByName(request.QuizName).IdQuiz;
                quiz.TotalScore = request.TotalScore;
                quiz.TimeTaken = request.TimeTaken;
                quiz.PointsAcquired = request.PointsAcquired;
                quiz.IdObjectState = 1;

                quizList = GetAll().Where(x => x.IdPlayer == request.IdPlayer && x.IdQuiz == quiz.IdQuiz).ToList();
                player = _playerService.GetById(request.IdPlayer);

                if (quizList.Count > 0)
                {
                    quiz.IdPlayerQuiz = quizList[0].IdPlayerQuiz;

                    if (request.PointsAcquired > quizList[0].PointsAcquired)
                    {
                        _context.ChangeTracker.Clear();

                        Update(quiz);

                        if (player != null)
                        {
                            player.TotalPoints += (request.PointsAcquired - quizList[0].PointsAcquired);
                            _playerService.Update(player);
                        }

                        response.IsSaveSuccess = true;
                    }
                    else
                    {
                        response.IsSaveSuccess = false;
                    }

                }
                else
                {
                    quiz.IdPlayerQuiz = Guid.NewGuid();

                    Create(quiz);

                    if (player != null)
                    {
                        _context.ChangeTracker.Clear();

                        player.TotalPoints += request.PointsAcquired;
                        _playerService.Update(player);
                    }

                    response.IsSaveSuccess = true;
                }

                response.IdPlayerQuiz = quiz.IdPlayerQuiz;
            }
            else
            {
                response.IsSaveSuccess = false;
                response.ErrorMessage = "Invalid Request Detected! Unable to save Player's Quiz Result!";
            }

            return response;
        }
        #endregion
    }
}
