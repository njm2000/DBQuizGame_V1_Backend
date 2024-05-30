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
    public class ObjectStateService : IObjectStateService
    {
        private readonly DBQuizGameContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;

        public ObjectStateService(DBQuizGameContext dbQuizGameContext, IMapper mapper)
        {
            _context = dbQuizGameContext;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ObjectState, DTO.ObjectState>().ReverseMap();
            });
            _mapper = _mapperConfig.CreateMapper();
        }

        #region Generic Functions

        public IEnumerable<DTO.ObjectState> GetAll()
        {
            return _mapper.Map<IEnumerable<ObjectState>, IEnumerable<DTO.ObjectState>>(
                _context.ObjectStates.ToList()
                );
        }

        public DTO.ObjectState GetById(int id)
        {
            return _mapper.Map<ObjectState, DTO.ObjectState>(
                 _context.ObjectStates.SingleOrDefault(x => x.IdObjectState == id)
                );
        }

        public DTO.ObjectState GetByName(string name)
        {
            return _mapper.Map<ObjectState, DTO.ObjectState>(
                 _context.ObjectStates.SingleOrDefault(x => x.Name == name)
                );
        }

        public IEnumerable<DTO.ObjectState> ContainsName(string keyword)
        {
            return _mapper.Map<IEnumerable<ObjectState>, IEnumerable<DTO.ObjectState>>(
                _context.ObjectStates.Where(x => x.Name.Contains(keyword)).ToList()
                );
        }

        public IEnumerable<DTO.ObjectState> ContainsDescription(string keyword)
        {
            return _mapper.Map<IEnumerable<ObjectState>, IEnumerable<DTO.ObjectState>>(
                _context.ObjectStates.Where(x => x.Description.Contains(keyword)).ToList()
                );
        }

        public void Create(DTO.ObjectState entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _context.Add(_mapper.Map<DTO.ObjectState, ObjectState>(entity));
            _context.SaveChanges();
        }

        public void Update(DTO.ObjectState updatedEntity)
        {
            updatedEntity.UpdatedDate = DateTime.UtcNow;
            _context.Update(_mapper.Map<DTO.ObjectState, ObjectState>(updatedEntity));
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                _context.Remove(_mapper.Map<DTO.ObjectState, ObjectState>(entity));
                _context.SaveChanges();
            }
        }

        #endregion

        #region Custom Functions
        #endregion
    }
}
