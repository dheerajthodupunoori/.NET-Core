using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Interface;

namespace SwaggerDemo.Controllers
{
    [Authorize]
    //[Route("[controller]")]
    //[ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUser _user;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ValuesController));


        public ValuesController(IUser user)
        {
            _user = user;
        }
        // GET api/values
        [HttpGet]
        [Route("[controller]/get")]
        public ActionResult<IEnumerable<string>> Get()
        {
            log.Debug("Logging is successfull");
            log.Info("Get method is triggered and executing");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            log.Info("Get method is triggered and executing");
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            log.Info("post method is triggered and executing");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            log.Info("put method is triggered and executing");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            log.Info("delete method is triggered and executing");
        }
    }
}
