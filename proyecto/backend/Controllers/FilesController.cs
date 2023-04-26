using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class FilesController : ControllerBase
{
  [HttpPost("images")]
  public async Task<IActionResult> Upload(IFormFile file)
  {
    if (file == null || file.Length == 0)
      return BadRequest("No file was uploaded.");

    string filename = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
    string targetDirectory = Path.Combine("C:", "storage", "images");
    string targetPath = Path.Combine(targetDirectory, filename);

    using (var stream = new FileStream(targetPath, FileMode.Create))
      await file.CopyToAsync(stream);

    return Ok(new { filename });
  }
}
