using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinhVien.Entities;
using SinhVien.Dao;
namespace SinhVien.Controllers
{
    public class SINHVIENsController : Controller
    {
        private SinhVienDbContext db = new SinhVienDbContext();

        // GET: SINHVIENs
        public PartialViewResult Index()
        {
            var sINHVIENs = db.SINHVIENs.Include(s => s.DANTOC1).Include(s => s.LOP1);
            return PartialView(sINHVIENs.ToList());
        }


        // GET: SINHVIENs/Create
        public PartialViewResult Create(int? id)
        {
            ViewBag.DANTOC = new SelectList(db.DANTOCs, "MA", "TEN");
            ViewBag.LOP = new SelectList(db.LOPs, "MA", "TEN");
            if(id == null)
            return PartialView();
               SINHVIEN sv = db.SINHVIENs.Find(id);
            return PartialView(sv);
          }

        // POST: SINHVIENs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(FormCollection form)
        {
            SINHVIEN sv = new SINHVIEN();
            sv.MA = Int32.Parse(form["MA"]);
            sv.HOTEN = form["HOTEN"];
            sv.NGAYSINH = DateTime.Parse(form["NGAYSINH"]);
            sv.QUEQUAN = form["QUEQUAN"];
            sv.LOP = Int32.Parse(form["LOP"]);
            sv.DANTOC = Int32.Parse(form["DANTOC"]);
               //ViewBag.DANTOC = new SelectList(db.DANTOCs, "MA", "TEN", sv.DANTOC);
               //ViewBag.LOP = new SelectList(db.LOPs, "MA", "TEN", sv.LOP);
            return Json( new SINHVIENDao().AddSINHVIEN(sv));
          }

        // GET: SINHVIENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.DANTOC = new SelectList(db.DANTOCs, "MA", "TEN", sINHVIEN.DANTOC);
            ViewBag.LOP = new SelectList(db.LOPs, "MA", "TEN", sINHVIEN.LOP);
            return View(sINHVIEN);
        }

        // POST: SINHVIENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(FormCollection form)
        {
               SINHVIEN sv = new SINHVIEN();
               sv.MA = Int32.Parse(form["MA"]);
               sv.HOTEN = form["HOTEN"];
               sv.NGAYSINH = DateTime.Parse(form["NGAYSINH"]);
               sv.QUEQUAN = form["QUEQUAN"];
               sv.LOP = Int32.Parse(form["LOP"]);
               sv.DANTOC = Int32.Parse(form["DANTOC"]);
               return Json(new SINHVIENDao().UpdateSINHVIEN(sv));
        }

        // GET: SINHVIENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        // POST: SINHVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {               
            return Json(new SINHVIENDao().DeleteSINHVIEN(id));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



          [HttpPost]
          [ValidateAntiForgeryToken]
          public PartialViewResult Search(FormCollection form)
          {
               string word = form["word"];
               int day = 0, month = 0, year = 0;
               if (form["day"] != "")
               {
                    day = int.Parse(form["day"]);
               }
               if (form["month"] != "")
               {
                    month = int.Parse(form["month"]);
               }
               if(form["year"] != "")
               {
                    year = int.Parse(form["year"]);
               }
               var listSV = db.SINHVIENs.Include(s => s.DANTOC1).Include(s => s.LOP1)
                              .Where(x => x.HOTEN.Contains(word)
                              || x.LOP1.TEN.Contains(word)
                              || x.QUEQUAN.Contains(word)
                              || x.DANTOC1.TEN.Contains(word)
                              && ((x.NGAYSINH.Month == day || day == 0)
                              && (x.NGAYSINH.Day == month || month ==0)
                              && (x.NGAYSINH.Year == year || year == 0)));
               return PartialView("Index",listSV.ToList());

          }
    }
}
