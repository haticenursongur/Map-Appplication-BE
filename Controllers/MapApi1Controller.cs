using MapApi1.EfCore;
using MapApi1.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MapApi1.Controllers
{
    [ApiController]
    public class MapApi1Controller : ControllerBase
    {
        private readonly DbHelper _db;
        public MapApi1Controller(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }
            // GET: api/<MapApi1Controller>
        [HttpGet]
        [Route("api/[controller]/getall")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<PointModel> data = _db.GetPoints();
                
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<MapApi1Controller>/5
        [HttpGet]
        [Route("api/[controller]/GetPointById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                PointModel data = _db.GetPointById(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<MapApiController>
        [HttpPost]
        [Route("api/[controller]/SavePoint")]
        public IActionResult Post([FromBody] PointModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SavePoint(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<MapApi1Controller>/5
        [HttpPut]
        [Route("api/[controller]/UpdatePoint")]
        public IActionResult Put([FromBody] PointModel model)
        {

            try
            {
                ResponseType type = ResponseType.Success;
                _db.SavePoint(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<MapApi1Controller>/5
        [HttpDelete]
        [Route("api/[controller]/DeletePoint/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeletePoint(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}