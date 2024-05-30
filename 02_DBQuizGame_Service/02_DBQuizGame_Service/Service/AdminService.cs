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
    public class AdminService : IAdminService
    {
        private readonly DBQuizGameContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;

        public AdminService(DBQuizGameContext dbQuizGameContext, IMapper mapper)
        {
            _context = dbQuizGameContext;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, DTO.Admin>().ReverseMap();
            });
            _mapper = _mapperConfig.CreateMapper();
        }

        #region Generic Functions

        public IEnumerable<DTO.Admin> GetAll()
        {
            return _mapper.Map<IEnumerable<Admin>, IEnumerable<DTO.Admin>>(
                _context.Admins.ToList()
                );
        }

        public IEnumerable<DTO.Admin> GetActive()
        {
            return _mapper.Map<IEnumerable<Admin>, IEnumerable<DTO.Admin>>(
                _context.Admins.Where(x => x.IdObjectState == 1).ToList()
                ); 
        }
        public IEnumerable<DTO.Admin> GetTerminated()
        {
            return _mapper.Map<IEnumerable<Admin>, IEnumerable<DTO.Admin>>(
                _context.Admins.Where(x => x.IdObjectState == 2).ToList()
                );
        }

        public DTO.Admin GetById(Guid id)
        {
            return _mapper.Map<Admin, DTO.Admin>(
                 _context.Admins.SingleOrDefault(x => x.IdAdmin == id)
                );
        }

        public DTO.Admin GetByName(string name)
        {
            return _mapper.Map<Admin, DTO.Admin>(
                 _context.Admins.SingleOrDefault(x => x.Name == name)
                );
        }

        public IEnumerable<DTO.Admin> ContainsName(string keyword)
        {
            return _mapper.Map<IEnumerable<Admin>, IEnumerable<DTO.Admin>>(
                _context.Admins.Where(x => x.Name.Contains(keyword)).ToList()
                );
        }

        public IEnumerable<DTO.Admin> ContainsDescription(string keyword)
        {
            return _mapper.Map<IEnumerable<Admin>, IEnumerable<DTO.Admin>>(
                _context.Admins.Where(x => x.Description.Contains(keyword)).ToList()
                );
        }

        public void Create(DTO.Admin entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _context.Add(_mapper.Map<DTO.Admin, Admin>(entity));
            _context.SaveChanges();
        }

        public void Update(DTO.Admin updatedEntity)
        {
            updatedEntity.UpdatedDate = DateTime.UtcNow;
            _context.Update(_mapper.Map<DTO.Admin, Admin>(updatedEntity));
            _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                _context.Remove(_mapper.Map<DTO.Admin, Admin>(entity));
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
