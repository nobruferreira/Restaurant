using Restaurant.Domain.Commands.Plates;
using Restaurant.Domain.Contracts.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Restaurant.Api.Controllers
{
    [RoutePrefix("api/plate")]
    public class PlateController : BaseController
    {
        private readonly IPlateAppService _service;

        public PlateController(IPlateAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAll")]
        public Task<HttpResponseMessage> GetAll()
        {
            var plate = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, plate);
        }

        [HttpGet]
        [Route("getById/{plateId}/{restaurantId}")]
        public Task<HttpResponseMessage> GetById(int plateId, int restaurantId)
        {
            var plate = _service.GetById(plateId, restaurantId);
            return CreateResponse(HttpStatusCode.OK, plate);
        }

        [HttpPost]
        [Route("create")]
        public Task<HttpResponseMessage> Create([FromBody]dynamic body)
        {
            var command = new CreatePlateCommand(
                plateName: (string)body.plateName,
                price: (decimal)body.price,
                restaurantId: (int)body.restaurantId
            );

            var plate = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, plate);
        }

        [HttpPut]
        [Route("update")]
        public Task<HttpResponseMessage> Update([FromBody]dynamic body)
        {
            var command = new UpdatePlateCommand(
                plateId: (int)body.plateId,
                plateName: (string)body.plateName,
                price: (decimal)body.price,
                restaurantId: (int)body.restaurantId
            );

            var plate = _service.Update(command);
            return CreateResponse(HttpStatusCode.Created, plate);
        }

        [HttpDelete]
        [Route("remove/{plateId}/{restaurantId}")]
        public Task<HttpResponseMessage> Remove(int plateId, int restaurantId)
        {
            var command = new RemovePlateCommand(
                plateId: plateId,
                restaurantId: restaurantId
            );

            var plate = _service.Remove(command);
            return CreateResponse(HttpStatusCode.Created, plate);
        }
    }
}