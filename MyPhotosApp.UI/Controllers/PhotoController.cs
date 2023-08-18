using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MyPhotosApp.Core.IRepos;
using MyPhotosApp.Data.Contexts;
using MyPhotosApp.Domain.Entities;
using MyPhotosApp.UI.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MyPhotosApp.UI.Controllers
{
    public class PhotoController : Controller
    {
        readonly MyPhotosDbContext _context;

        public PhotoController(MyPhotosDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var photos = _context.Photos.ToList();

            List<PhotosDTO> photoList = new List<PhotosDTO>();
            if (photos != null)
            {
                foreach (var item in photos)
                {
                    PhotosDTO model = new PhotosDTO();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Bytes = item.Bytes;
                    model.ContentType = item.ContentType;
                    model.Tags = item.Tags;
                    model.Description = item.Description;
                    model.Base64String = Convert.ToBase64String(model.Bytes);
                    photoList.Add(model);
                }
            }

            return View(photoList);
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(PhotosDTO model)
        {
            if (model.File != null && model.File.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.File.CopyToAsync(memoryStream);
                    var photo = new Photo
                    {
                        Name = model.Name,
                        Bytes = memoryStream.ToArray(),
                        ContentType = model.File.ContentType,
                        CreatedById = 4,
                        UserId = 4,
                        CreatedByRowId = Guid.Parse("13c54f91-84aa-4fb2-a039-f4175ada35bc"),
                        CreatedAt = DateTime.UtcNow,
                        Tags = model.Tags,
                        Description = model.Description,
                        RowId = Guid.NewGuid(),
                    };
                    _context.Photos.Add(photo);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        } 

        public IActionResult Display(int id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            if (photo != null)
            {
                DisplayDTO model = new DisplayDTO()
                {
                    Base64String = Convert.ToBase64String(photo.Bytes),
                    ContentType = photo.ContentType,
                    Description = photo.Description,
                    Tags = photo.Tags,
                    Id = photo.Id
                };
                return View(model);
            }
            return NotFound();
        }

        public IActionResult CardDisplay(int id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            if(photo != null)
            {
                return File(photo.Bytes, photo.ContentType);
            }
            return NotFound();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            if(photo != null)
            {
                _context.Photos.Remove(photo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
