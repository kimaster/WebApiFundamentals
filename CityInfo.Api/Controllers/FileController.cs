using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityInfo.Api.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider fileExtensionContentTypeProvider;

        public FileController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider) => this.fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        // GET: api/<FileController>
        [HttpGet]
        public ActionResult Get()
        {
            //FileResult result = new FileResult();
            //FileStreamResult result1 = new FileStreamResult();
            //FileResult result2 = new FileResult);
            //PhysicalFileResult result3 = new PhysicalFileResult();
            var bytes = System.IO.File.ReadAllBytes("README.txt");
            if (!fileExtensionContentTypeProvider.TryGetContentType("README.txt", out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return File(bytes, "text/plain", "README.txt");

            //     return File(bytes, contentType, "README.md");

        }

        [HttpPost]
        public async Task<ActionResult> CreateFile(IFormFile file)
        {
            if (file == null || file.Length == 0 || file.Length < 209712520
                || file.ContentType != "application/pdf")
            {
                return BadRequest();



            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"Uplooaded_file_{Guid.NewGuid()}.pdf");

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok("file created on this location:)_");
        }

        // GET api/<FileController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FileController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
