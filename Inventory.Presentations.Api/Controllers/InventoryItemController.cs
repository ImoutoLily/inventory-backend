using Inventory.Core.Business;
using Inventory.Core.Business.Models.Request;
using Inventory.Presentations.Api.Controllers.Abstract;
using Mapster;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Presentations.Api.Controllers;

public class InventoryItemController : BaseController
{
    private readonly GetInventoryItems _getInventoryItems;
    private readonly UpdateInventoryItem _updateInventoryItem;

    public InventoryItemController(GetInventoryItems getInventoryItems, UpdateInventoryItem updateInventoryItem)
    {
        _getInventoryItems = getInventoryItems;
        _updateInventoryItem = updateInventoryItem;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _getInventoryItems.GetById(id);

        return Ok(result);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, JsonPatchDocument<InventoryItemRequest> request)
    {
        var getResult = await _getInventoryItems.GetById(id);

        if (getResult.Error is not null) return Ok(getResult);

        var inventoryItem = getResult.Value!.Item.Adapt<InventoryItemRequest>();
        
        request.ApplyTo(inventoryItem);

        var updateResult = await _updateInventoryItem.Update(id, inventoryItem);

        return Ok(updateResult);
    }
}