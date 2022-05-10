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
    private readonly RemoveInventoryItem _removeInventoryItem;

    public InventoryItemController(GetInventoryItems getInventoryItems, UpdateInventoryItem updateInventoryItem, RemoveInventoryItem removeInventoryItem)
    {
        _getInventoryItems = getInventoryItems;
        _updateInventoryItem = updateInventoryItem;
        _removeInventoryItem = removeInventoryItem;
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

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remove(int id)
    {
        var result = await _removeInventoryItem.Remove(id);

        return Ok(result);
    }
}