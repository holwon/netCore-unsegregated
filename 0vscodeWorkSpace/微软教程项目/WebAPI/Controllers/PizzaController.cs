using System.Net;
using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
    PizzaService.GetAll();

    // [HttpGet("{Pizza}")]
    // public async Task<ActionResult<List<Pizza>>> GetAsync()
    // {
    //     return await Task.FromResult(PizzaService.GetAll());
    // }


    /// <summary>
    /// GET by Id action
    /// </summary>
    /// <param name="id"></param>
    /// <returns>pizza</returns>
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza == null)
            return NotFound();

        return pizza;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        // TODO: 提问: 这里为什么要比较`id != pizza.Id`, pizza不是在此处定义的吗?
        // todo 那么它不就是一个空的`pizza`了吗, 这怎么比较的?
        // FIX: 回答: 因为`PUT`时, `PUT`后面的参数才是`id`
        // 例如 put 3 -c  "{"id": 3, "name":"Hawaiian", "isGlutenFree":false}"
        // put 后面的参数 `3`才是 [HttpPut("{id}")] 里面的id, 
        // 而 -c 后面传的"{"id": 3, "name":"Hawaiian", "isGlutenFree":false}", 
        // 就是要更新的数据, 所以要比较`id != pizza.Id`, 防止修改错误。
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = PizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();

        PizzaService.Update(pizza);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza is null)
            return NotFound();

        PizzaService.Delete(id);

        return NoContent();
    }
}
