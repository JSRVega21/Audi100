using Audi100.Models;
using Audi100.Server.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace Audi100.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepository<Photo, int> _photoRepository;

        public PhotoController(IPhotoRepository<Photo, int> photoRepository)
        {
            _photoRepository = photoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhotos()
        {
            var photos = await _photoRepository.GetListAsync();
            return Ok(photos);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles([FromForm] int auditFindingId, [FromForm] List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return BadRequest("No files uploaded.");

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    byte[] fileBytes;
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        fileBytes = memoryStream.ToArray();
                    }

                    var photo = new Photo
                    {
                        AuditFindingId = auditFindingId
                    };

                    if (file.ContentType.StartsWith("image"))
                    {
                        photo.BytePhone = fileBytes;
                    }
                    else if (file.ContentType == "application/pdf")
                    {
                        photo.BytePdf = fileBytes;
                    }
                    else
                    {
                        return BadRequest("Unsupported file type. Only images and PDFs are allowed.");
                    }

                    await _photoRepository.AddAsync(photo);
                }
            }

            return Ok(new { Message = "Files uploaded successfully." });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhotoById(int id)
        {
            var photo = await _photoRepository.GetByKeyAsync(id);
            if (photo == null)
                return NotFound();

            return Ok(photo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhoto(int id, [FromBody] Photo updatedPhoto)
        {
            if (id != updatedPhoto.PhotoId)
                return BadRequest("ID mismatch.");

            var photo = await _photoRepository.GetByKeyAsync(id);
            if (photo == null)
                return NotFound();

            photo.BytePhone = updatedPhoto.BytePhone;

            await _photoRepository.UpdateAsync(photo);

            return Ok(new { Message = "Photo updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            var photo = await _photoRepository.GetByKeyAsync(id);
            if (photo == null)
                return NotFound();

            await _photoRepository.DeleteAsync(id);

            return Ok(new { Message = "Photo deleted successfully." });
        }

        [HttpGet("auditFinding/{auditFindingId}")]
        public async Task<IActionResult> GetAuditId(int auditFindingId)
        {
            var photos = await _photoRepository.GetAuditIdAsync(auditFindingId);
            if (photos == null || photos.Count == 0)
                return Ok(new List<Photo>());

            return Ok(photos);
        }

        [HttpGet("download-files/{auditFindingId}")]
        public async Task<IActionResult> DownloadFiles(int auditFindingId)
        {
            var photos = await _photoRepository.GetAuditIdAsync(auditFindingId);

            if (!photos.Any())
            {
                return NotFound("No se encontró ningún archivo para el hallazgo especificado.");
            }

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    int pdfCounter = 1;
                    int imageCounter = 1;

                    // Añadir PDFs
                    foreach (var pdfPhoto in photos.Where(p => p.BytePdf != null))
                    {
                        var zipEntry = archive.CreateEntry($"informe-{pdfCounter}.pdf", CompressionLevel.Fastest);
                        using (var entryStream = zipEntry.Open())
                        {
                            await entryStream.WriteAsync(pdfPhoto.BytePdf, 0, pdfPhoto.BytePdf.Length);
                        }
                        pdfCounter++;
                    }

                    // Añadir imágenes
                    foreach (var photo in photos.Where(p => p.BytePhone != null))
                    {
                        var imageEntry = archive.CreateEntry($"imagen-{imageCounter}.jpg", CompressionLevel.Fastest); 
                        using (var imageStream = imageEntry.Open())
                        {
                            await imageStream.WriteAsync(photo.BytePhone, 0, photo.BytePhone.Length);
                        }
                        imageCounter++;
                    }
                }

                 memoryStream.Seek(0, SeekOrigin.Begin);

                return File(memoryStream.ToArray(), "application/zip", "archivos.zip");

            }
        }


    }
}
