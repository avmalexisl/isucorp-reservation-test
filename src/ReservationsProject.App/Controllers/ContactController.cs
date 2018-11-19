using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Mvc;
using AutoMapper;
using ISUCorp.ReservationsProject.App.Models;
using ISUCorp.ReservationsProject.Core.Entities;
using ISUCorp.ReservationsProject.Domain.Dto;
using ISUCorp.ReservationsProject.Domain.Services;
using Microsoft.Ajax.Utilities;

namespace ISUCorp.ReservationsProject.App.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactDomainService contactService;

        public ContactController(IContactDomainService contactService)
        {
            this.contactService = contactService;
        }

        public JsonResult GetById(int id = 0)
        {
            if (id == 0)
            {
                return null;
            }

            var contactDto = this.contactService.Find(id);
            contactDto.FormattedBirthDate = contactDto.BirthDate.ToString("yyyy-MM-dd");
            return this.Json(contactDto, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List(int page = 1, string sortBy = null)
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = ContactListViewHelper.CurrentSortBy ?? nameof(ContactDto.Name);
            }

            const int maxCount = 5;
            var skipCount = (page - 1) * maxCount;
            var response = this.contactService.FindAll(new PaginationInputDto(skipCount, maxCount, sortBy));
            var dtoList = response.Items;
            var toDecimalRound = (decimal)response.SourceTotal / (decimal)maxCount;
            var toIntegerRound = response.SourceTotal / maxCount;
            var toRound = toDecimalRound > toIntegerRound? toIntegerRound+1:toIntegerRound;
            this.ViewBag.PageCount = toRound;
            ContactListViewHelper.CurrentSortBy = sortBy;
            this.ViewBag.CurrentPage = page;
            return View(dtoList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContactInputDto input)
        {
            if (!this.ModelState.IsValid)
            {
                var message = this.ValidateFields();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
            }

            try
            {
                var contact = input;
                this.contactService.Add(contact);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch(Exception e)
            {
                var message = e.Message;
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, message);
            }
        }

        private string ValidateFields()
        {
            var builder = new StringBuilder();
            builder.Append("Some requiered fields missing:");
            foreach (var modelError in this.ModelState)
            {
                var propertyName = modelError.Key;
                if (modelError.Value.Errors.Count > 0)
                {
                    builder.Append($" [{propertyName}]");
                }
            }

            var message = builder.ToString();
            return message;
        }

        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }

            var contactDto = this.contactService.Find(id);
            return View(contactDto);
        }

        [HttpPost]
        public ActionResult Edit(ContactDto input)
        {
            if (!ModelState.IsValid)
            {
                var message = this.ValidateFields();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
            }

            try
            {
                this.contactService.Update(input);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            this.contactService.Remove(id);
            return RedirectToAction("List");
        }
    }
}