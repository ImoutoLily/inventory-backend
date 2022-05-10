using Inventory.Core.Business;
using Inventory.Core.Business.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Presentations.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly CreateInventory _createInventory;
    private readonly GetInventories _getInventories;

    public InventoryController(CreateInventory createInventory, GetInventories getInventories)
    {
        _createInventory = createInventory;
        _getInventories = getInventories;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getInventories.GetAll();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateInventoryRequest request)
    {
        var result = await _createInventory.Create(request);

        return Ok(result);
    }
}