using Inventory.Core.Business;
using Inventory.Presentations.Api.Controllers.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Presentations.Api.Controllers;

public class InventoryItemController : BaseController
{
    private readonly GetInventoryItems _getInventoryItems;

    public InventoryItemController(GetInventoryItems getInventoryItems)
    {
        _getInventoryItems = getInventoryItems;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _getInventoryItems.GetById(id);

        return Ok(result);
    }
}