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
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly DBQuizGameContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;

        public QuestionTypeService(DBQuizGameContext dbQuizGameContext, IMapper mapper)
        {
            _context = dbQuizGameContext;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuestionType, DTO.QuestionType>().ReverseMap();
            });
            _mapper = _mapperConfig.CreateMapper();
        }

        #region Generic Functions

        public IEnumerable<DTO.QuestionType> GetAll()
        {
            return _mapper.Map<IEnumerable<QuestionType>, IEnumerable<DTO.QuestionType>>(
                _context.QuestionTypes.ToList()
                );
        }

        public IEnumerable<DTO.QuestionType> GetActive()
        {
            return _mapper.Map<IEnumerable<QuestionType>, IEnumerable<DTO.QuestionType>>(
                _context.QuestionTypes.Where(x => x.IdObjectState == 1).ToList()
                );
        }
        public IEnumerable<DTO.QuestionType> GetTerminated()
        {
            return _mapper.Map<IEnumerable<QuestionType>, IEnumerable<DTO.QuestionType>>(
                _context.QuestionTypes.Where(x => x.IdObjectState == 2).ToList()
                );
        }

        public DTO.QuestionType GetById(int id)
        {
            return _mapper.Map<QuestionType, DTO.QuestionType>(
                 _context.QuestionTypes.SingleOrDefault(x => x.IdQuestionType == id)
                );
        }

        public DTO.QuestionType GetByName(string name)
        {
            return _mapper.Map<QuestionType, DTO.QuestionType>(
                 _context.QuestionTypes.SingleOrDefault(x => x.Name == name)
                );
        }

        public IEnumerable<DTO.QuestionType> ContainsName(string keyword)
        {
            return _mapper.Map<IEnumerable<QuestionType>, IEnumerable<DTO.QuestionType>>(
                _context.QuestionTypes.Where(x => x.Name.Contains(keyword)).ToList()
                );
        }

        public IEnumerable<DTO.QuestionType> ContainsDescription(string keyword)
        {
            return _mapper.Map<IEnumerable<QuestionType>, IEnumerable<DTO.QuestionType>>(
                _context.QuestionTypes.Where(x => x.Description.Contains(keyword)).ToList()
                );
        }

        public void Create(DTO.QuestionType entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _context.Add(_mapper.Map<DTO.QuestionType, QuestionType>(entity));
            _context.SaveChanges();
        }

        public void Update(DTO.QuestionType updatedEntity)
        {
            updatedEntity.UpdatedDate = DateTime.UtcNow;
            _context.Update(_mapper.Map<DTO.QuestionType, QuestionType>(updatedEntity));
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                _context.Remove(_mapper.Map<DTO.QuestionType, QuestionType>(entity));
                _context.SaveChanges();
            }
        }

        public void Terminate(int id)
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

        public void Reactivate(int id)
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
