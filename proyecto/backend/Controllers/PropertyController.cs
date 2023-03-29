using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{
    private readonly IPropertyService PropertyService;
    public PropertyController(IPropertyService PropertyService)
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
