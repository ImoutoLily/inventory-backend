using Inventory.Core.Business;
using Inventory.Core.Business.Models.Request;
using Inventory.Presentations.Api.Controllers.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Presentations.Api.Controllers;

public class InventoryItemController : BaseController
{
    private readonly CreateInventoryItem _createInventoryItem;

    public InventoryItemController(CreateInventoryItem createInventoryItem)
    {
        _createInventoryItem = createInventoryItem;
    }

    [HttpPost]
    public async Task<IActionResult> Create(InventoryItemRequest request)
    {
        var result = await _createInventoryItem.Create(request);

        return Ok(result);
    }
}