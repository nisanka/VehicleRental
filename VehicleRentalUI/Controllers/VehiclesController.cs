using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleRentalUI.Context;
using VehicleRentalUI.Models;
using VehicleRentalUI.Helpers;

namespace VehicleRentalUI.Controllers
{
    public class VehiclesController : Controller
    {
        private VehicleRentalContext db = new VehicleRentalContext();

        // GET: Vehicles
        public async Task<ActionResult> Index()
        {
            return View(await db.Vehicles.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            RefreshViewBags();
            return View();
        }
        
        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Vehicle vehicle, HttpPostedFileBase file, List<HttpPostedFileBase> files)
        //public async Task<ActionResult> Create([Bind(Include = "Province,Id,Rate,RegisteredYear,EngineCapacity,Model,Color,Remarks")] Vehicle vehicle)
        {   
            if (ModelState.IsValid)
            {
                BeforeSave(vehicle);
                SaveAttachment(vehicle, file);
                SaveAttachments(vehicle, files);
                db.Vehicles.Add(vehicle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            RefreshViewBags();
            return View(vehicle);
        }

        private void SaveAttachment(Vehicle vehicle, HttpPostedFileBase file)
        {
            var savedAttachment = attachmentHelper.SaveAttachment(file, vehicle.Id, vehicle.ObjectType);
            vehicle.PictureId = savedAttachment.FileName;
        }

        private void SaveAttachments(Vehicle vehicle, List<HttpPostedFileBase> files)
        {
            var savedAttachments = attachmentHelper.SaveAttachments(files.ToArray(), vehicle.ObjectType, vehicle.Id);
            vehicle.Attachments = savedAttachments;
        }

        // GET: Vehicles/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            RefreshViewBags();
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Rate,RegisteredYear,EngineCapacity,Model,Color,Remarks,ObjectType,IsActive,CreatedDateTime,UpdatedDateTime,LastRentedDatetime")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                BeforeSave(vehicle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            RefreshViewBags();
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            db.Attachments.RemoveRange(vehicle.Attachments);
            db.Vehicles.Remove(vehicle);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        private void RefreshViewBags()
        {
            ViewBag.Provinces = db.ProvinceCategories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            ViewBag.VehicleTypes = db.VehicleTypes.ToList();
        }

        AttachmentHelper attachmentHelper = new AttachmentHelper();
        private void BeforeSave(Vehicle vehicle)
        {
            vehicle.Id = vehicle.Id.ToUpper();
            if (!vehicle.CreatedDateTime.HasValue)
            {
                vehicle.IsActive = true;
                vehicle.CreatedDateTime = DateTime.Now;
            }
            else
            {
                vehicle.UpdatedDateTime = DateTime.Now;
            }
        }
    }
}
