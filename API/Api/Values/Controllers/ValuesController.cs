using API.Api.Values.Resources;
using ApplicationShared.Values;
using ApplicationShared.Values.Queries;
using Core.QueryManager;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Values.Controllers
{
    [Route(ValuesRotues._baseRoute)]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IQueryManager _queryManager;

        public ValuesController(IQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<Value>> Get()
        {
            return await _queryManager.Send(new GetValuesQuery());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<Value> Get(int id)
        {
            return await _queryManager.Send(new GetValueByIdQuery(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
