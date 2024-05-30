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
    public class QuizCertificateService : IQuizCertificateService
    {
        private readonly DBQuizGameContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;

        public QuizCertificateService(DBQuizGameContext dbQuizGameContext, IMapper mapper)
        {
            _context = dbQuizGameContext;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuizCertificate, DTO.QuizCertificate>().ReverseMap();
            });
            _mapper = _mapperConfig.CreateMapper();
        }

        #region Generic Functions

        public IEnumerable<DTO.QuizCertificate> GetAll()
        {
            return _mapper.Map<IEnumerable<QuizCertificate>, IEnumerable<DTO.QuizCertificate>>(
                _context.QuizCertificates.ToList()
                );
        }

        public IEnumerable<DTO.QuizCertificate> GetActive()
        {
            return _mapper.Map<IEnumerable<QuizCertificate>, IEnumerable<DTO.QuizCertificate>>(
                _context.QuizCertificates.Where(x => x.IdObjectState == 1).ToList()
                );
        }
        public IEnumerable<DTO.QuizCertificate> GetTerminated()
        {
            return _mapper.Map<IEnumerable<QuizCertificate>, IEnumerable<DTO.QuizCertificate>>(
                _context.QuizCertificates.Where(x => x.IdObjectState == 2).ToList()
                );
        }

        public DTO.QuizCertificate GetById(Guid id)
        {
            return _mapper.Map<QuizCertificate, DTO.QuizCertificate>(
                 _context.QuizCertificates.SingleOrDefault(x => x.IdQuizCertificate == id)
                );
        }

        public void Create(DTO.QuizCertificate entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _context.Add(_mapper.Map<DTO.QuizCertificate, QuizCertificate>(entity));
            _context.SaveChanges();
        }

        public void Update(DTO.QuizCertificate updatedEntity)
        {
            updatedEntity.UpdatedDate = DateTime.UtcNow;
            _context.Update(_mapper.Map<DTO.QuizCertificate, QuizCertificate>(updatedEntity));
            _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                _context.Remove(_mapper.Map<DTO.QuizCertificate, QuizCertificate>(entity));
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
