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
            HybridModel SongModel = new HybridModel();
            SongModel.songModel = new Song();
            SongModel.songs = await _Context.Song.ToListAsync();
            return View(SongModel);

        }


        [HttpPost]
        public async Task<IActionResult> AddSong(HybridModel song)
        {

            song.songModel.Adds = 0;
            if (ModelState.IsValid)
            {
                _Context.Add(song.songModel);
                await _Context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> ToPlaylist(HybridModel song)
        {
            var CurrentUser = await _user.GetUserAsync(User);
            MySongs playlistSong = new MySongs();
            playlistSong.SongID = song.songModel.ID;
            playlistSong.UserEmail = CurrentUser.Email;

            if (ModelState.IsValid)
            {
                _MySongsContext.Add(song.songModel);
                await _MySongsContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }
        //renders a newly-added song to the user's playlist
        [HttpPost]
        public async Task<IActionResult> AddToPlaylist(HybridModel song)
        {

            if (ModelState.IsValid)
            {
                _Context.Add(song.songModel);
                await _Context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(MySongs));

        }
    }
}