namespace ApiExercise.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ApiExercise.Data.Models;
    using ApiExercise.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("car")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return this.carService.All();
        }

        [HttpGet("{id}")]
        public IEnumerable<Car> Get(int id)
        {
            return this.carService.All(id);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Car car)
        {
            await this.carService.AddAsync(car);

            return this.Created($"car/{car.Id}", car);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Car car)
        {
            await this.carService.Edit(car);

            return this.Ok(204);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await this.carService.Delete(id);

            return this.Ok(204);
        }
    }
}
