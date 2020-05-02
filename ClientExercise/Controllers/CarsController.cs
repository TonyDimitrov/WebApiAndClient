namespace ClientExercise.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using ClientExercise.Models;
    using ClientExercise.Service;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly ICarsService carsService;

        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        [HttpGet]
        public async Task<IActionResult> All(int? id)
        {
            var result = await this.carsService.AllAsync(id);

            return this.View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Car car)
        {
            await this.carsService.AddAsync(car);

            return this.RedirectToAction(nameof(this.All));
        }

        public async Task<IActionResult> Edit(Car car)
        {
            await this.carsService.EditAsync(car);

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await this.carsService.Delete(id);

            return this.Ok();
        }

        // Json result actions
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var car = (await this.carsService.AllAsync(id)).FirstOrDefault();

            if (car == null)
            {
                return this.NotFound();
            }

            return this.Json(car);
        }
    }
}
