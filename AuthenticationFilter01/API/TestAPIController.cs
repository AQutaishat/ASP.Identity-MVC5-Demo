using Authentication01.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Authentication01.API
{
    [RoutePrefix("api/TestAPI")]
    [MyAPIAuthorizeAttribute]

    public class TestAPIController : ApiController
    {

        [HttpGet]
        [Route("Test1")]
        public bool Test1()
        {
            return true;
        }

        [HttpGet]
        [Route("Test2")]
        public bool Test2()
        {
            return false;
        }
    }
}