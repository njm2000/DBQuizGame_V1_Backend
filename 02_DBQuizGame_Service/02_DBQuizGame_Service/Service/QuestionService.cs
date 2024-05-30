using _01_DBQuizGame_Persistence.Entity;
using _02_DBQuizGame_Service.IService;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly DBQuizGameContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;

        public QuestionService(DBQuizGameContext dbQuizGameContext, IMapper mapper)
        {
            _context = dbQuizGameContext;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, DTO.Question>().ReverseMap();
            });
            _mapper = _mapperConfig.CreateMapper();
        }

        #region Generic Functions

        public IEnumerable<DTO.Question> GetAll()
        {
            return _mapper.Map<IEnumerable<Question>, IEnumerable<DTO.Question>>(
                _context.Questions.ToList()
                );
        }

        public IEnumerable<DTO.Question> GetActive()
        {
            return _mapper.Map<IEnumerable<Question>, IEnumerable<DTO.Question>>(
                _context.Questions.Where(x => x.IdObjectState == 1).ToList()
                );
        }
        public IEnumerable<DTO.Question> GetTerminated()
        {
            return _mapper.Map<IEnumerable<Question>, IEnumerable<DTO.Question>>(
                _context.Questions.Where(x => x.IdObjectState == 2).ToList()
                );
        }

        public DTO.Question GetById(Guid id)
        {
            return _mapper.Map<Question, DTO.Question>(
                 _context.Questions.SingleOrDefault(x => x.IdQuestion == id)
                );
        }

        public DTO.Question GetByName(string name)
        {
            return _mapper.Map<Question, DTO.Question>(
                 _context.Questions.SingleOrDefault(x => x.Name == name)
                );
        }

        public IEnumerable<DTO.Question> ContainsName(string keyword)
        {
            return _mapper.Map<IEnumerable<Question>, IEnumerable<DTO.Question>>(
                _context.Questions.Where(x => x.Name.Contains(keyword)).ToList()
                );
        }

        public IEnumerable<DTO.Question> ContainsDescription(string keyword)
        {
            return _mapper.Map<IEnumerable<Question>, IEnumerable<DTO.Question>>(
                _context.Questions.Where(x => x.Description.Contains(keyword)).ToList()
                );
        }

        public void Create(DTO.Question entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _context.Add(_mapper.Map<DTO.Question, Question>(entity));
            _context.SaveChanges();
        }

        public void Update(DTO.Question updatedEntity)
        {
            updatedEntity.UpdatedDate = DateTime.UtcNow;
            _context.Update(_mapper.Map<DTO.Question, Question>(updatedEntity));
            _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                _context.Remove(_mapper.Map<DTO.Question, Question>(entity));
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
        #endregion
    }
}
