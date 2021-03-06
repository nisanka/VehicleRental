﻿using System;
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
    public class CustomersController : Controller
    {
        private VehicleRentalContext db = new VehicleRentalContext();

        // GET: Customers
        public async Task<ActionResult> Index()
        {
            return View(await db.Customers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Name,Address,PhoneNumber1,PhoneNumber2,DOB,ObjectType,IsActive,BlackListed,CreatedDateTime,UpdatedDateTime,LastRentedDatetime,Remarks")] Customer customer)
        public async Task<ActionResult> Create(Customer customer, HttpPostedFileBase file, List<HttpPostedFileBase> files)

        {
            if (ModelState.IsValid)
            {
                BeforeSave(customer);
                SaveAttachment(customer, file);
                SaveAttachments(customer, files);
                db.Customers.Add(customer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Address,PhoneNumber1,PhoneNumber2,DOB,ObjectType,IsActive,BlackListed,CreatedDateTime,UpdatedDateTime,LastRentedDatetime,Remarks")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Customer customer = await db.Customers.FindAsync(id);
            db.Attachments.RemoveRange(customer.Attachments);
            db.Customers.Remove(customer);
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

        private void BeforeSave(Customer customer)
        {
            customer.Id = customer.Id.ToUpper();
            if (!customer.CreatedDateTime.HasValue)
            {                
                customer.IsActive = true;
                customer.CreatedDateTime = DateTime.Now;
            }
            else
            {
                customer.UpdatedDateTime = DateTime.Now;
            }
        }

        AttachmentHelper attachmentHelper = new AttachmentHelper();

        private void SaveAttachment(Customer customer, HttpPostedFileBase file)
        {
            var savedAttachment = attachmentHelper.SaveAttachment(file, customer.Id, customer.ObjectType);
            customer.PictureId = savedAttachment.FileName;
        }

        private void SaveAttachments(Customer customer, List<HttpPostedFileBase> files)
        {
            var savedAttachments = attachmentHelper.SaveAttachments(files.ToArray(), customer.ObjectType, customer.Id);
            customer.Attachments = savedAttachments;
        }
    }
}
