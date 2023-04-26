using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class PropertiesController : ControllerBase
{
    private readonly IPropertyService PropertyService;
    public PropertiesController(IPropertyService PropertyService)
    {
        this.PropertyService = PropertyService;
    }

    [HttpGet("")]
    public IEnumerable<Property> GetAllProperties()
    {
        return PropertyService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Property> GetProperty(int id)
    {
        Property? Property = PropertyService.GetOne(id);
        if (Property == null) return NotFound();
        return Property;
    }

    [HttpPost("")]
    public Property CreateProperty(Property Property)
    {
        return PropertyService.Create(Property);
    }

    [HttpPut("")]
    public ActionResult<Property> UpdateProperty(Property Property)
    {
        
        Property? PropertyUpdated = PropertyService.Update(Property);
        if (PropertyUpdated == null) return NotFound();
        return PropertyUpdated;
    }

    [HttpDelete("{id}")]
    public ActionResult<Property> DeleteProperty(int id)
    {
        Property? Property = PropertyService.Delete(id);
        if (Property == null) return NotFound();
        return Property;
    }
}
