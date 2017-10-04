using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;

namespace VideoRest.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VideoesController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/Video
        [HttpGet]
        public IEnumerable<VideoBO> Get()
        {
            return facade.VideoService.GetAll();
        }

        // GET: api/Video/5
        [HttpGet("{id}", Name = "Get")]
        public VideoBO Get(int id)
        {
            return facade.VideoService.Get(id);
        }
        
        // POST: api/Video
        [HttpPost]
        public IActionResult Post([FromBody]VideoBO vid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.VideoService.Create(vid));
        }
        
        // PUT: api/Video/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]VideoBO vid)
        {
            if (id != vid.Id)
            {
                return StatusCode(405, "Path Id does not match Video Id in json object");
            }
            try
            {
                var videoUpdated = facade.VideoService.Update(vid);
                return Ok(videoUpdated);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.VideoService.Delete(id);
        }
    }
}
