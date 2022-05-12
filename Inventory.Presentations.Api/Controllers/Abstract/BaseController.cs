using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Presentations.Api.Controllers.Abstract;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public abstract class BaseController : ControllerBase
{
}