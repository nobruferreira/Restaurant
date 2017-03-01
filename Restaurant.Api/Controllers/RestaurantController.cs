using Restaurant.Domain.Commands.Restaurants;
using Restaurant.Domain.Contracts.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Restaurant.Api.Controllers
{
    [RoutePrefix("api/restaurant")]
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantAppService _service;

        public RestaurantController(IRestaurantAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAll")]
        public Task<HttpResponseMessage> GetAll()
        {
            var restaurant = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, restaurant);
        }

        [HttpGet]
        [Route("getById/{restaurantId}")]
        public Task<HttpResponseMessage> GetById(int restaurantId)
        {
            var restaurant = _service.GetById(restaurantId);
            return CreateResponse(HttpStatusCode.OK, restaurant);
        }

        [HttpPost]
        [Route("create")]
        public Task<HttpResponseMessage> Create([FromBody]dynamic body)
        {
            var command = new CreateRestaurantCommand(
                restaurantName: (string)body.restaurantName
            );

            var restaurant = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, restaurant);
        }

        [HttpPut]
        [Route("update")]
        public Task<HttpResponseMessage> Update([FromBody]dynamic body)
        {
            var command = new UpdateRestaurantCommand(
                restaurantId: (int)body.restaurantId,
                restaurantName: (string)body.restaurantName
            );

            var restaurant = _service.Update(command);
            return CreateResponse(HttpStatusCode.Created, restaurant);
        }

        [HttpDelete]
        [Route("remove/{restaurantId}")]
        public Task<HttpResponseMessage> Remove(int restaurantId)
        {
            var restaurant = _service.Remove(restaurantId);
            return CreateResponse(HttpStatusCode.Created, restaurant);
        }
    }
}