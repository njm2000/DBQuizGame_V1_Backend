using _01_DBQuizGame_Persistence.Entity;
using _02_DBQuizGame_Service.IService;
using _02_DBQuizGame_Service.Request;
using _02_DBQuizGame_Service.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.Service
{
    public class PlayerCertificateService : IPlayerCertificateService
    {
        private readonly DBQuizGameContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;
        private readonly ICertificateService _certificateService;
        private readonly IPlayerService _playerService;


        public PlayerCertificateService(DBQuizGameContext dbQuizGameContext, IMapper mapper, ICertificateService certService, IPlayerService playerService)
        {
            _context = dbQuizGameContext;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlayerCertificate, DTO.PlayerCertificate>().ReverseMap();
            });
            _mapper = _mapperConfig.CreateMapper();
            _certificateService = certService;
            _playerService = playerService;
        }

        #region Generic Functions

        public IEnumerable<DTO.PlayerCertificate> GetAll()
        {
            return _mapper.Map<IEnumerable<PlayerCertificate>, IEnumerable<DTO.PlayerCertificate>>(
                _context.PlayerCertificates.ToList()
                );
        }

        public IEnumerable<DTO.PlayerCertificate> GetActive()
        {
            return _mapper.Map<IEnumerable<PlayerCertificate>, IEnumerable<DTO.PlayerCertificate>>(
                _context.PlayerCertificates.Where(x => x.IdObjectState == 1).ToList()
                );
        }
        public IEnumerable<DTO.PlayerCertificate> GetTerminated()
        {
            return _mapper.Map<IEnumerable<PlayerCertificate>, IEnumerable<DTO.PlayerCertificate>>(
                _context.PlayerCertificates.Where(x => x.IdObjectState == 2).ToList()
                );
        }

        public DTO.PlayerCertificate GetById(Guid id)
        {
            return _mapper.Map<PlayerCertificate, DTO.PlayerCertificate>(
                 _context.PlayerCertificates.SingleOrDefault(x => x.IdPlayerCertificate == id)
                );
        }

        //public IEnumerable<DTO.PlayerCertificate> GetByIdPlayer(Guid id)
        //{
        //    return _mapper.Map<IEnumerable<PlayerCertificate>, IEnumerable<DTO.PlayerCertificate>>(
        //         _context.PlayerCertificates.Where(x => x.IdPlayer == id).ToList()
        //        );
        //}

        //public DTO.PlayerCertificate GetByIdCertificate(Guid id)
        //{
        //    return _mapper.Map<PlayerCertificate, DTO.PlayerCertificate>(
        //         _context.PlayerCertificates.SingleOrDefault(x => x.IdCertificate == id)
        //        );
        //}

        public void Create(DTO.PlayerCertificate entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _context.Add(_mapper.Map<DTO.PlayerCertificate, PlayerCertificate>(entity));
            _context.SaveChanges();
        }

        public void Update(DTO.PlayerCertificate updatedEntity)
        {
            updatedEntity.UpdatedDate = DateTime.UtcNow;
            _context.Update(_mapper.Map<DTO.PlayerCertificate, PlayerCertificate>(updatedEntity));
            _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);

            _context.ChangeTracker.Clear();

            if (entity != null)
            {
                _context.Remove(_mapper.Map<DTO.PlayerCertificate, PlayerCertificate>(entity));
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

        public ViewPlayerCertificateResponse ViewPlayerCertificate(ViewPlayerCertificateRequest request)
        {
            ViewPlayerCertificateResponse response = new ViewPlayerCertificateResponse();
            List<DTO.PlayerCertificate> playerCertificateList = new List<DTO.PlayerCertificate>();
            List<DTO.Certificate> certificateList = new List<DTO.Certificate>();

            playerCertificateList = GetAll().Where(x => x.IdPlayer == request.IdPlayer).ToList();

            foreach (var playerCertificate in playerCertificateList) 
            {
                var cert = _certificateService.GetById(playerCertificate.IdCertificate);
                certificateList.Add(cert);
            }

            response.PlayerCertificates = playerCertificateList;
            response.Certificates = certificateList.OrderBy(x => x.Name).ToList();

            return response;
        }

        public SavePlayerCertificateResponse SavePlayerCertificate(SavePlayerCertificateRequest request)
        {
            SavePlayerCertificateResponse response = new SavePlayerCertificateResponse();
            List<DTO.PlayerCertificate> certList = new List<DTO.PlayerCertificate>();
            DTO.PlayerCertificate cert = new DTO.PlayerCertificate();
            DTO.Player player = new DTO.Player();

            if (request.IdPlayer != Guid.Empty && request.CertificateName != null && request.TotalAttempts != null && request.TimeTaken != null && request.PointsAcquired != null)
            {                
                cert.IdPlayer = request.IdPlayer;
                cert.IdCertificate = _certificateService.GetByName(request.CertificateName).IdCertificate;
                cert.TotalAttempt = request.TotalAttempts;
                cert.TimeTaken = request.TimeTaken;
                cert.PointsAcquired = request.PointsAcquired;
                cert.IdObjectState = 1;

                certList = GetAll().Where(x => x.IdPlayer == request.IdPlayer && x.IdCertificate == cert.IdCertificate).ToList();
                player = _playerService.GetById(request.IdPlayer);

                if (certList.Count > 0)
                {
                    cert.IdPlayerCertificate = certList[0].IdPlayerCertificate;

                    if (request.PointsAcquired > certList[0].PointsAcquired)
                    {
                        _context.ChangeTracker.Clear();

                        Update(cert);

                        if (player != null)
                        {
                            player.TotalPoints += (request.PointsAcquired - certList[0].PointsAcquired);
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
                    cert.IdPlayerCertificate = Guid.NewGuid();

                    Create(cert);

                    if (player != null)
                    {
                        _context.ChangeTracker.Clear();

                        player.TotalPoints += request.PointsAcquired;
                        _playerService.Update(player);
                    }


                    response.IsSaveSuccess = true;
                }

                response.IdPlayerCertificate = cert.IdPlayerCertificate;
            }
            else
            {
                response.IsSaveSuccess = false;
                response.ErrorMessage = "Invalid Request Detected! Unable to save Player's Certificate!";
            }

            return response;
        }

        #endregion
    }
}
