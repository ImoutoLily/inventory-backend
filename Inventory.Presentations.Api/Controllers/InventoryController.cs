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
    private readonly UpdateInventory _updateInventory;
    private readonly RemoveInventory _removeInventory;

    public InventoryController(CreateInventory createInventory, GetInventories getInventories, 
        UpdateInventory updateInventory, RemoveInventory removeInventory)
    {
        _createInventory = createInventory;
        _getInventories = getInventories;
        _updateInventory = updateInventory;
        _removeInventory = removeInventory;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _getInventories.GetById(id);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getInventories.GetAll();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(InventoryRequest request)
    {
        var result = await _createInventory.Create(request);

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, InventoryRequest request)
    {
        var result = await _updateInventory.Update(id, request);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remove(int id)
    {
        var result = await _removeInventory.Remove(id);

        return Ok(result);
    }
}