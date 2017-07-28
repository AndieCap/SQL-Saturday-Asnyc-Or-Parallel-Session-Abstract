using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ApiBusinessLayer;

namespace WebApiAsyncArchitectureExample.Controllers
{
  public class ValuesController : ApiController
  {
    // GET api/values
    public IEnumerable<string> Get()
    {

      //var httpClient = new HttpClient();
      //var ip = await httpClient.GetStringAsync("https://api.ipify.org");

      //return new[] { ip, "value2" };
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    public Task<string> Get(int id)
    {
      return new ValuesManager().Get();
    }

    // POST api/values
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    public void Delete(int id)
    {
    }
  }
}
