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
    public class QuizService : IQuizService
    {
        private readonly DBQuizGameContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;
        private readonly IQuestionService _questionService;
        private readonly IOptionService _optionService;
        private readonly IQuestionTypeService _questionTypeService;
        private readonly ICertificateService _certificateService;
        private readonly IPlayerCertificateService _playerCertificateService;
        private readonly IQuizCertificateService _quizCertificateService;

        public QuizService(DBQuizGameContext dbQuizGameContext, IMapper mapper, IQuestionService questionService, IOptionService optionService, IQuestionTypeService questionTypeService, ICertificateService certificateService, IPlayerCertificateService playerCertificateService, IQuizCertificateService quizCertificateService)
        {
            _context = dbQuizGameContext;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Quiz, DTO.Quiz>().ReverseMap();
            });
            _mapper = _mapperConfig.CreateMapper();
            _questionService = questionService;
            _optionService = optionService;
            _questionTypeService = questionTypeService;
            _certificateService = certificateService;
            _playerCertificateService = playerCertificateService;
            _quizCertificateService = quizCertificateService; ;
        }

        #region Generic Functions

        public IEnumerable<DTO.Quiz> GetAll()
        {
            return _mapper.Map<IEnumerable<Quiz>, IEnumerable<DTO.Quiz>>(
                _context.Quizzes.ToList()
                );
        }

        public IEnumerable<DTO.Quiz> GetActive()
        {
            return _mapper.Map<IEnumerable<Quiz>, IEnumerable<DTO.Quiz>>(
                _context.Quizzes.Where(x => x.IdObjectState == 1).ToList()
                );
        }
        public IEnumerable<DTO.Quiz> GetTerminated()
        {
            return _mapper.Map<IEnumerable<Quiz>, IEnumerable<DTO.Quiz>>(
                _context.Quizzes.Where(x => x.IdObjectState == 2).ToList()
                );
        }

        public DTO.Quiz GetById(Guid id)
        {
            return _mapper.Map<Quiz, DTO.Quiz>(
                 _context.Quizzes.SingleOrDefault(x => x.IdQuiz == id)
                );
        }

        public DTO.Quiz GetByName(string name)
        {
            return _mapper.Map<Quiz, DTO.Quiz>(
                 _context.Quizzes.SingleOrDefault(x => x.Name == name)
                );
        }

        public IEnumerable<DTO.Quiz> ContainsName(string keyword)
        {
            return _mapper.Map<IEnumerable<Quiz>, IEnumerable<DTO.Quiz>>(
                _context.Quizzes.Where(x => x.Name.Contains(keyword)).ToList()
                );
        }

        public IEnumerable<DTO.Quiz> ContainsDescription(string keyword)
        {
            return _mapper.Map<IEnumerable<Quiz>, IEnumerable<DTO.Quiz>>(
                _context.Quizzes.Where(x => x.Description.Contains(keyword)).ToList()
                );
        }

        public void Create(DTO.Quiz entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _context.Add(_mapper.Map<DTO.Quiz, Quiz>(entity));
            _context.SaveChanges();
        }

        public void Update(DTO.Quiz updatedEntity)
        {
            updatedEntity.UpdatedDate = DateTime.UtcNow;
            _context.Update(_mapper.Map<DTO.Quiz, Quiz>(updatedEntity));
            _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                _context.Remove(_mapper.Map<DTO.Quiz, Quiz>(entity));
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
        public GenerateRandomQuestionResponse GenerateRandomQuestion(GenerateRandomQuestionRequest request)
        {
            GenerateRandomQuestionResponse response = new GenerateRandomQuestionResponse();
            List<DTO.Question> questionList = new List<DTO.Question>();
            List<DTO.Question> randomQuestionList = new List<DTO.Question>();
            List<DTO.Option> questionOptionList = new List<DTO.Option>();
            List<DTO.Certificate> missingCertificateList = new List<DTO.Certificate>();


            int noOfCertified = 0;

            var quiz = GetByName(request.QuizName);
            var requiredCertificates = _quizCertificateService.GetAll().Where(x => x.IdQuiz == quiz.IdQuiz);

            foreach (var reqCert in requiredCertificates)
            {
                if(_playerCertificateService.GetAll().Any(x => x.IdCertificate == reqCert.IdCertificate && x.IdPlayer == request.IdPlayer))
                {
                    noOfCertified++;
                }
                else
                {
                    var missingCert = _certificateService.GetById(reqCert.IdCertificate);
                    missingCertificateList.Add(missingCert);
                }
            }

            if(requiredCertificates.Count() == noOfCertified)
            {
                if (quiz != null)
                {
                    questionList = _questionService.GetAll().Where(x => x.IdQuiz == quiz.IdQuiz).ToList();

                    if (questionList.Count > 0)
                    {
                        Random rnd = new Random();
                        randomQuestionList = questionList.OrderBy(x => rnd.Next()).Take(quiz.TotalQuestion).ToList();

                        if (randomQuestionList.Count == quiz.TotalQuestion)
                        {
                            foreach (var question in randomQuestionList)
                            {
                                var options = _optionService.GetAll().Where(x => x.IdQuestion == question.IdQuestion).ToList();
                                if (options.Count == _questionTypeService.GetById(question.IdQuestionType).TotalOption)
                                {
                                    questionOptionList.AddRange(options);
                                }
                                else
                                {
                                    response.IsGenerationSuccess = false;
                                    response.ErrorMessage = "Invalid Number of Question Options Generated!\nQuestion ID: " + question.IdQuestion + "\nTotal Options Found: " + options.Count;
                                }
                            }

                            response.Questions = randomQuestionList;
                            response.Options = questionOptionList;
                            response.IsGenerationSuccess = true;
                        }
                        else
                        {
                            response.IsGenerationSuccess = false;
                            response.ErrorMessage = "Invalid Number of Questions Generated!\nTotal Questions Generated: " + randomQuestionList.Count;
                        }
                    }
                }
            }
            else
            {
                response.IsGenerationSuccess = false;
                response.MissingCertificateList = missingCertificateList;
                response.ErrorMessage = "Player not certified for this Quiz!\nMissing Certificate(s): ";
            }

            return response;
        }
        #endregion
    }
}
