using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class SocialMediaController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult SocialMediaList()
        {
            var values = db.TblSocialMedia.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(TblSocialMedia p)
        {
            p.Status = true;
            db.TblSocialMedia.Add(p);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            db.TblSocialMedia.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult StatusChangeSocialMedia(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia p)
        {
            var value = db.TblSocialMedia.Find(p.SocialMediaId);
            value.PlatformName = p.PlatformName;
            value.İconUrl = p.İconUrl;
            value.RedierectUrl = p.RedierectUrl;
            value.Status = p.Status;
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

    }
}
//ToList --> Bütün Verileri Koşulsuz Getiriyor