﻿using Bridge.Models;
using System.Web.Mvc;

namespace Bridge.Controllers
{
    [Authorize]
    public class ImageFileController : Controller
    {

        private ApplicationDbContext _context;

        public ImageFileController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: ImageFile
        public ActionResult Index(int id)
        {
            var fileToRetrieve = _context.Referrals.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}