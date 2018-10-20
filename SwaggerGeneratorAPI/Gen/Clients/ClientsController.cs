using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SwaggerGeneratorAPI.Gen.Clients
{
    /// <remarks>
    /// 下記Swagger の実装練習
    /// https://api.apis.guru/v2/specs/swagger.io/generator/2.3.1/swagger.yaml
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsModel model;



        public ClientsController(ClientsModel model)
        {
            this.model = model;
        }



        /// <summary>
        /// Gets languages supported by the client generator
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetSupportedLanguages()
        {
            var list = model.GetSupportedLanguages();
            return list;
        }
    }
}