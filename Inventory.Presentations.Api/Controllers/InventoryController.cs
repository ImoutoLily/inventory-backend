using Inventory.Core.Business.Inventory;
using Inventory.Core.Business.InventoryItem;
using Inventory.Core.Business.Models.Request;
using Inventory.Presentations.Api.Controllers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Presentations.Api.Controllers;

[Authorize]
public class InventoryController : BaseController
{
    private readonly CreateInventory _createInventory;
    private readonly GetInventories _getInventories;
    private readonly UpdateInventory _updateInventory;
    private readonly RemoveInventory _removeInventory;

    private readonly GetInventoryItems _getInventoryItems;
    private readonly CreateInventoryItem _createInventoryItem;

    public InventoryController(CreateInventory createInventory, GetInventories getInventories, 
        UpdateInventory updateInventory, RemoveInventory removeInventory, 
        CreateInventoryItem createInventoryItem, GetInventoryItems getInventoryItems)
    {
        _createInventory = createInventory;
        _getInventories = getInventories;
        _updateInventory = updateInventory;
        _removeInventory = removeInventory;
        
        _createInventoryItem = createInventoryItem;
        _getInventoryItems = getInventoryItems;
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

    [HttpGet("{inventoryId:int}/Items")]
    public async Task<IActionResult> GetItems(int inventoryId)
    {
        var result = await _getInventoryItems.GetAllByInventoryId(inventoryId);

        return Ok(result);
    }

    [HttpPost("{inventoryId:int}/Items")]
    public async Task<IActionResult> AddItem(int inventoryId, InventoryItemRequest request)
    {
        var result = await _createInventoryItem.Create(inventoryId, request);

        return Ok(result);
    }
}