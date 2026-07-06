using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebNetCore.Models;

namespace WebNetCore.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Index()
        {

            var VideoUrl = new List<VideoModel> {

            new VideoModel()
            {
                Id = "luffy",
                    Name = "Monkey D. Luffy",
                    Description = @"Monkey D. Luffy, also known as ""Straw Hat"" Luffy, is a fictional character and the main protagonist of the One Piece manga series, created by Eiichiro Oda.",
                    VideoUrl = "https://www.youtube.com/embed/_U_0uowl174"
            },

            new VideoModel()
            {
                 Id = "zoro",
                    Name = "Roronoa Zoro",
                    Description = @"Roronoa Zoro, nicknamed ""Pirate Hunter"" Zoro, is a fictional character in the One Piece franchise created by Eiichiro Oda. In the story, Pirate Hunter Zoro is the first to join Monkey D. Luffy after he is saved from being executed at the Marine Base.",
                    VideoUrl = "https://www.youtube.com/embed/ZCIpJKE_WLg"
            },

            new VideoModel()
            {
                 Id = "sanji",
                    Name = "Roronoa Zoro",
                    Description = @"Roronoa Zoro, nicknamed ""Pirate Hunter"" Zoro, is a fictional character in the One Piece franchise created by Eiichiro Oda. In the story, Pirate Hunter Zoro is the first to join Monkey D. Luffy after he is saved from being executed at the Marine Base.",
                    VideoUrl = "https://www.youtube.com/embed/ZCIpJKE_WLg"
            }

            };

            return View(VideoUrl);
        }
    }
}
