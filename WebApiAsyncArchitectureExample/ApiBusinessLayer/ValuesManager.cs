using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDataLayer;

namespace ApiBusinessLayer
{
  public class ValuesManager
  {
    //Add Get method
    public async Task<string> Get()
    {
      var repo = new ValuesRepository();
      var results = await repo.GetAsync();

      return results.First();
    }
  }
}
