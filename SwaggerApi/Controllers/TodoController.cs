using Microsoft.AspNetCore.Mvc;
using SwaggerApi.Models;

namespace SwaggerApi.Controllers
{
    [ApiController]
    [Route("api/todos")]
    [Produces("application/json")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromHeader] string correlationId)
        {
            _logger.LogInformation($"Request CorrelationId: {correlationId}");

            var items = new TodoList().Items;
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromHeader] string correlationId, long id)
        {
            _logger.LogInformation($"Request CorrelationId: {correlationId}");

            var item = new TodoList().Items.FirstOrDefault(item => item.Id == id);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // <snippet_Create>
        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromHeader] string correlationId, TodoItem item)
        {
            _logger.LogInformation($"Request CorrelationId: {correlationId}");

            var list = new TodoList();
            list.Add(item);

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }
        // </snippet_Create>

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromHeader] string correlationId, long id)
        {
            _logger.LogInformation($"Request CorrelationId: {correlationId}");

            var list = new TodoList();
            var item = list.Items.FirstOrDefault(item => item.Id == id);

            if (item is null)
            {
                return NotFound();
            }

            list.Remove(item);
            return NoContent();
        }
    }
}
