using Microsoft.AspNetCore.Mvc;
using _02_DBQuizGame_Service.IService;
using _02_DBQuizGame_Service.DTO;

namespace _03_DBQuizGame_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjectStateController : ControllerBase
    {
        private readonly ILogger<ObjectStateController> _logger;
        private readonly IObjectStateService _service;

        public ObjectStateController(ILogger<ObjectStateController> logger, IObjectStateService objectStateService)
        {
            _logger = logger;
            _service = objectStateService;
        }

        #region Generic Functions

        [HttpGet]
        public IEnumerable<ObjectState> GetAll()
        {
            try
            {
                var result = _service.GetAll();

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpGet("{id}")]
        public ObjectState GetById(int id)
        {
            try
            {
                var result = _service.GetById(id);

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpGet("GetByName/{name}")]
        public ObjectState GetByName(string name)
        {
            try
            {
                var result = _service.GetByName(name);

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpGet("ContainsName/{keyword}")]
        public IEnumerable<ObjectState> ContainsName(string keyword)
        {
            try
            {
                var result = _service.ContainsName(keyword);

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpGet("ContainsDescription/{keyword}")]
        public IEnumerable<ObjectState> ContainsDescription(string keyword)
        {
            try
            {
                var result = _service.ContainsDescription(keyword);

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpPost]
        public void Post(ObjectState entity)
        {
            try
            {
                _service.Create(entity);

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpPut]
        public void Put(ObjectState entity)
        {
            try
            {
                _service.Update(entity);

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _service.Delete(id);

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        #endregion

        #region Custom Functions
        #endregion
    }
}
