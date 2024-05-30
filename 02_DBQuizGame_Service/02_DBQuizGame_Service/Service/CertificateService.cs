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
    public class CertificateService : ICertificateService
    {
        private readonly DBQuizGameContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;

        public CertificateService(DBQuizGameContext dbQuizGameContext, IMapper mapper)
        {
            _context = dbQuizGameContext;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Certificate, DTO.Certificate>().ReverseMap();
            });
            _mapper = _mapperConfig.CreateMapper();
        }

        #region Generic Functions

        public IEnumerable<DTO.Certificate> GetAll()
        {
            return _mapper.Map<IEnumerable<Certificate>, IEnumerable<DTO.Certificate>>(
                _context.Certificates.ToList()
                );
        }

        public IEnumerable<DTO.Certificate> GetActive()
        {
            return _mapper.Map<IEnumerable<Certificate>, IEnumerable<DTO.Certificate>>(
                _context.Certificates.Where(x => x.IdObjectState == 1).ToList()
                );
        }
        public IEnumerable<DTO.Certificate> GetTerminated()
        {
            return _mapper.Map<IEnumerable<Certificate>, IEnumerable<DTO.Certificate>>(
                _context.Certificates.Where(x => x.IdObjectState == 2).ToList()
                );
        }

        public DTO.Certificate GetById(Guid id)
        {
            return _mapper.Map<Certificate, DTO.Certificate>(
                 _context.Certificates.SingleOrDefault(x => x.IdCertificate == id)
                );
        }

        public DTO.Certificate GetByName(string name)
        {
            return _mapper.Map<Certificate, DTO.Certificate>(
                 _context.Certificates.SingleOrDefault(x => x.Name == name)
                );
        }

        public IEnumerable<DTO.Certificate> ContainsName(string keyword)
        {
            return _mapper.Map<IEnumerable<Certificate>, IEnumerable<DTO.Certificate>>(
                _context.Certificates.Where(x => x.Name.Contains(keyword)).ToList()
                );
        }

        public IEnumerable<DTO.Certificate> ContainsDescription(string keyword)
        {
            return _mapper.Map<IEnumerable<Certificate>, IEnumerable<DTO.Certificate>>(
                _context.Certificates.Where(x => x.Description.Contains(keyword)).ToList()
                );
        }

        public void Create(DTO.Certificate entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _context.Add(_mapper.Map<DTO.Certificate, Certificate>(entity));
            _context.SaveChanges();
        }

        public void Update(DTO.Certificate updatedEntity)
        {
            updatedEntity.UpdatedDate = DateTime.UtcNow;
            _context.Update(_mapper.Map<DTO.Certificate, Certificate>(updatedEntity));
            _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                _context.Remove(_mapper.Map<DTO.Certificate, Certificate>(entity));
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
