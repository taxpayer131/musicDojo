using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using musicDojo.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using musicDojo.Data;

namespace musicDojo.Controllers
{
    public class SongController : Controller
    {
        private readonly SongDBContext _Context;
        private readonly MySongsDBContext _MySongsContext;
        private readonly UserManager<ApplicationUser> _user;

        public SongController(UserManager<ApplicationUser> userManager, SongDBContext songContext, MySongsDBContext mySongContext)
        {
            _Context = songContext;
            _MySongsContext = mySongContext;
            _user = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _Context.Song.ToListAsync());

        }

        //[HttpPost]
       //// public async Task<IActionResult> AddSong([Bind("ID, Artist, Title")]Song song)
       // {
       //     song.Adds = 0;
       // }
    }
}