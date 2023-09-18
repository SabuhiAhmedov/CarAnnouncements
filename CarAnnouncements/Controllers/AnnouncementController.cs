using AutoMapper;
using CarAnnouncements.DAL;
using CarAnnouncements.Models;
using CarAnnouncements.ToDoItems;
using CarAnnouncements.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using HotelProject.Helpers;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CarAnnouncements.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public AnnouncementController(AppDbContext db, IWebHostEnvironment env,IMapper mapper)
        {
            _db = db;            
            _env = env;
            _mapper=mapper;
        }

        #region Get Announcement By Id
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "id can't null" });
            }
            Announcement announcement = await _db.Announcements
                .Include(x => x.Model).ThenInclude(x => x.Mark)
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (announcement == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = $"No announcement was found with id= {id}" });
            }
            AnnouncementDto announcementDto = new AnnouncementDto();

            return Ok(_mapper.Map(announcement,announcementDto));
        }
        #endregion

        #region Get all Announcement
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            List<Announcement> announcements = await _db.Announcements.
                Include(x => x.Model).ThenInclude(x => x.Mark).
                Include(x => x.Images).
                ToListAsync();
           List< AnnouncementDto> announcementDto = new List< AnnouncementDto>();
            return Ok(_mapper.Map(announcements, announcementDto));
        }
        #endregion

        #region Create Announcement
        [HttpPost]
        [Route("Create")]
        [Authorize]
        public async Task<ActionResult> Create([FromForm] AnnouncementCreateDto createDto)
        {
            Ban ban = await _db.Bans.FirstOrDefaultAsync(x => x.Id == createDto.BanId);
            Color color = await _db.Colors.FirstOrDefaultAsync(x => x.Id == createDto.ColorId);
            Gas gas = await _db.Gases.FirstOrDefaultAsync(x => x.Id == createDto.GasId);
            GearBox gearBox = await _db.GearBoxes.FirstOrDefaultAsync(x => x.Id == createDto.GearBoxId);
            Model model = await _db.Models.FirstOrDefaultAsync(x => x.Id == createDto.ModelId);

            if (ban == null || color == null || gas == null || gearBox == null || model == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "One or more entities not found with the provided ids." });
            }
            //Find Logged in User 
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim.Value;
            Announcement announcement = new Announcement
            {
                UserId = int.Parse(userId),
                BanId = createDto.BanId,
                ColorId = createDto.ColorId,
                GasId = createDto.GasId,
                GearBoxId = createDto.GearBoxId,
                ModelId = createDto.ModelId,
                Price = createDto.Price,
                EngineVolume = createDto.EngineVolume,
                Year = createDto.Year,
                Distance = createDto.Distance
            };

            //Upload Photo
            #region Upload Photo
            if (createDto.Photos == null)
            {
                return NotFound("Choose photo");
            }
            List<Images> ımages = new List<Images>();
            foreach (IFormFile photos in createDto.Photos)
            {

                if (photos.IsOlderTwoMb())
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Choose an image less than 2mb in size." });
                }
                if (!photos.IsImage())
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Choose  photo" });
                }
                string folder = Path.Combine(_env.WebRootPath, "img");
                Images carImage = new Images();
                carImage.Url = await photos.SaveFileAsync(folder);
                ımages.Add(carImage);
            }
            announcement.Images = ımages;
            #endregion
            await _db.Announcements.AddAsync(announcement);
            await _db.SaveChangesAsync();
            return Ok("Created successfully");
        }
        #endregion

        #region Update Announcements
        [HttpPut("Update{id}")]
        [Authorize]
        public async Task<ActionResult> Update(int? id, [FromForm] AnnouncementUpdateDto updateDto)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "id can't null" });
                }
                Announcement announcement = await _db.Announcements.Include(x => x.Images).FirstOrDefaultAsync(x => x.Id == id);
                //Find Logged in User
                var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                var userId = userIdClaim.Value;
                if (announcement.UserId != int.Parse(userId))
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "You can only make changes to your own announcement." });
                }
                if (announcement == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = $"No announcement was found with id= {id}" });
                }

                #region Upload Photo for update
                List<Images> images = new List<Images>();
                if (updateDto.Photos != null)
                {

                    foreach (IFormFile photos in updateDto.Photos)
                    {

                        if (photos.IsOlderTwoMb())
                        {
                            return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Choose an image less than 2mb in size." });
                        }
                        if (!photos.IsImage())
                        {
                            return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Choose  photo" });
                        }
                        string folder = Path.Combine(_env.WebRootPath, "img");
                        Images carImage = new Images();
                        carImage.Url = await photos.SaveFileAsync(folder);
                        images.Add(carImage);
                    }
                    announcement.Images.AddRange(images);
                }
                #endregion

                #region Data Modify

                if (updateDto.Price != null)
                {
                    announcement.Price = (int)updateDto.Price;
                }
                if (updateDto.Year != null)
                {
                    announcement.Year = (int)updateDto.Year;
                }
                if (updateDto.Distance != null)
                {
                    announcement.Distance = (int)updateDto.Distance;
                }
                if (updateDto.EngineVolume != null)
                {
                    announcement.EngineVolume = (int)updateDto.EngineVolume;
                }
                if (updateDto.GasId != null)
                {
                    announcement.GasId = (int)updateDto.GasId;
                }
                if (updateDto.GearBoxId != null)
                {
                    announcement.GearBoxId = (int)updateDto.GearBoxId;
                }
                if (updateDto.ColorId != null)
                {
                    announcement.ColorId = (int)updateDto.ColorId;
                }
                if (updateDto.BanId != null)
                {
                    announcement.BanId = (int)updateDto.BanId;
                }
                if (updateDto.ModelId != null)
                {
                    announcement.ModelId = (int)updateDto.ModelId;
                }
                #endregion
                await _db.SaveChangesAsync();
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = ex.Message });
            }

        }
        #endregion

        #region Delete  Car Images in Announcement
        [HttpDelete("DeleteImage/{imgId}")]
        [Authorize]
        public async Task<ActionResult> DeleteCarImages(int? announcementId, int? imgId)
        {
            Announcement dbAnnouncement = await _db.Announcements.FirstOrDefaultAsync(x => x.Id == announcementId);
            //Find Logged in User
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim.Value;
            if (dbAnnouncement.UserId != int.Parse(userId))
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "You can only delete photos from your own announcement" });
            }
            if (imgId == null || announcementId == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "imgId and announcementId can't null" });
            }

            Images image = await _db.Images.FirstOrDefaultAsync(x => x.Id == imgId && x.AnnouncementId == announcementId);
            if (image == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Image not found " });

            }
            List<Images> imagesList = await _db.Images.Where(x => x.AnnouncementId == announcementId).ToListAsync();
            if (imagesList.Count == 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Image could not be deleted. The announcement must have at least one image." });

            }
            //Delete image from wwwroot
            string path = Path.Combine(_env.WebRootPath, "img", image.Url);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _db.Images.Remove(image);
            await _db.SaveChangesAsync();
            return Ok("Deleted Successfully");
        }
        #endregion

        #region Delete announcement
        [HttpDelete("announcement/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAnnouncement(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "id can't null" });
            }
            Announcement dbAnnouncement = await _db.Announcements.FirstOrDefaultAsync(x => x.Id == id);
            //Find Logged in User
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim.Value;
            if (dbAnnouncement.UserId != int.Parse(userId))
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "You can only delete  your own announcement" });
            }
            if (dbAnnouncement == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = $"Announcemen don't found with id= {id}" });

            }
            List<Images> images = await _db.Images.Where(x => x.AnnouncementId == id).ToListAsync();
            foreach (Images item in images)
            {
                string path = Path.Combine(_env.WebRootPath, "img", item.Url);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            _db.Announcements.Remove(dbAnnouncement);
            await _db.SaveChangesAsync();
            return Ok("Deleted Successfully");
        }
        #endregion

        #region Search Announcement
        [HttpGet("Search")]
        public async Task<ActionResult> Search([FromQuery] AnnouncementSearchDto searchDto)
        {
            IQueryable<Announcement> queries = _db.Announcements
          .Include(x => x.Model)
          .ThenInclude(x => x.Mark)
          .Include(x => x.Images)
          .Where(x =>
              (!searchDto.MinPrice.HasValue || x.Price >= searchDto.MinPrice.Value) &&
              (!searchDto.MaxPrice.HasValue || x.Price <= searchDto.MaxPrice.Value) &&
              (!searchDto.MinYear.HasValue || x.Year >= searchDto.MinYear.Value) &&
              (!searchDto.MaxYear.HasValue || x.Year <= searchDto.MaxYear.Value) &&
              (!searchDto.MinDistance.HasValue || x.Distance >= searchDto.MinDistance.Value) &&
              (!searchDto.MaxDistance.HasValue || x.Distance <= searchDto.MaxDistance.Value) &&
              (!searchDto.MinEngineVolume.HasValue || x.EngineVolume >= searchDto.MinEngineVolume.Value) &&
              (!searchDto.MaxEngineVolume.HasValue || x.EngineVolume <= searchDto.MaxEngineVolume.Value) &&
              (!searchDto.BanId.HasValue || x.BanId == searchDto.BanId.Value) &&
              (!searchDto.ColorId.HasValue || x.ColorId == searchDto.ColorId.Value) &&
              (!searchDto.GasId.HasValue || x.GasId == searchDto.GasId.Value) &&
              (!searchDto.GearBoxId.HasValue || x.GearBoxId == searchDto.GearBoxId.Value) &&
              (!searchDto.ModelId.HasValue || x.ModelId == searchDto.ModelId.Value) &&
              (!searchDto.MarkId.HasValue || x.Model.MarkId == searchDto.MarkId.Value)
          );

            List<Announcement> announcements = queries.ToList();
            if (!announcements.Any())
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Announcement not found" });
            }
            List<AnnouncementDto> announcementDto = new List<AnnouncementDto>();
            return Ok(_mapper.Map(announcements, announcementDto));
        }
        #endregion

    }
}
