namespace ClientExercise.Controllers
{
    using ClientExercise.Models;
    using ClientExercise.Service;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Mvc.Routing;
    using System.Threading.Tasks;

    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IActionContextAccessor actionContext;

        public CarsController(ICarsService carsService, IActionContextAccessor actionContext)
        {
            this.carsService = carsService;
            this.actionContext = actionContext;
        }

        [HttpGet]
        public async Task<IActionResult> All(int? id)
        {
            var result = await carsService.All(id);

            return this.View(result);
        }

        public IActionResult Add(Car car)
        {
            return null;
        }

        public IActionResult Edit(Car car)
        {
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await this.carsService.Delete(id);

            return this.Ok();
        }
    }
}
