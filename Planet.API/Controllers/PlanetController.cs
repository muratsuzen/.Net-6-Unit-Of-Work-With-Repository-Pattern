using Microsoft.AspNetCore.Mvc;
using Planet.API.Core.IRepositories;

namespace Planet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanetController : Controller
{
    private IUnitOfWork _unitOfWork;

    public PlanetController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _unitOfWork.GenericRepository<Models.Planet>().GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Models.Planet entity)
    {                             
        var result = await _unitOfWork.GenericRepository<Models.Planet>().Add(entity);
        await _unitOfWork.CompleteAsync();
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Models.Planet entity)
    {
        var result = await _unitOfWork.GenericRepository<Models.Planet>().Update(entity);
        await _unitOfWork.CompleteAsync();
        return Ok(result);
    }
}