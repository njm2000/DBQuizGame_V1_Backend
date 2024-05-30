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
    public class OptionService : IOptionService
    {
        private readonly DBQuizGameContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;

        public OptionService(DBQuizGameContext dbQuizGameContext, IMapper mapper)
        {
            _context = dbQuizGameContext;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Option, DTO.Option>().ReverseMap();
            });
            _mapper = _mapperConfig.CreateMapper();
        }

        #region Generic Functions

        public IEnumerable<DTO.Option> GetAll()
        {
            return _mapper.Map<IEnumerable<Option>, IEnumerable<DTO.Option>>(
                _context.Options.ToList()
                );
        }

        public IEnumerable<DTO.Option> GetActive()
        {
            return _mapper.Map<IEnumerable<Option>, IEnumerable<DTO.Option>>(
                _context.Options.Where(x => x.IdObjectState == 1).ToList()
                );
        }
        public IEnumerable<DTO.Option> GetTerminated()
        {
            return _mapper.Map<IEnumerable<Option>, IEnumerable<DTO.Option>>(
                _context.Options.Where(x => x.IdObjectState == 2).ToList()
                );
        }

        public DTO.Option GetById(Guid id)
        {
            return _mapper.Map<Option, DTO.Option>(
                 _context.Options.SingleOrDefault(x => x.IdOption == id)
                );
        }

        public DTO.Option GetByName(string name)
        {
            return _mapper.Map<Option, DTO.Option>(
                 _context.Options.SingleOrDefault(x => x.Name == name)
                );
        }

        public IEnumerable<DTO.Option> ContainsName(string keyword)
        {
            return _mapper.Map<IEnumerable<Option>, IEnumerable<DTO.Option>>(
                _context.Options.Where(x => x.Name.Contains(keyword)).ToList()
                );
        }

        public IEnumerable<DTO.Option> ContainsDescription(string keyword)
        {
            return _mapper.Map<IEnumerable<Option>, IEnumerable<DTO.Option>>(
                _context.Options.Where(x => x.Description.Contains(keyword)).ToList()
                );
        }

        public void Create(DTO.Option entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _context.Add(_mapper.Map<DTO.Option, Option>(entity));
            _context.SaveChanges();
        }

        public void Update(DTO.Option updatedEntity)
        {
            updatedEntity.UpdatedDate = DateTime.UtcNow;
            _context.Update(_mapper.Map<DTO.Option, Option>(updatedEntity));
            _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                _context.Remove(_mapper.Map<DTO.Option, Option>(entity));
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
