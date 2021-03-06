﻿using System;
using System.Net;
using System.Text;
using System.Web.Mvc;
using ISUCorp.ReservationsProject.App.Models;
using ISUCorp.ReservationsProject.Domain.Dto;
using ISUCorp.ReservationsProject.Domain.Services;

namespace ISUCorp.ReservationsProject.App.Controllers
{
    public class ReservationController : BaseController
    {
        private readonly IReservationDomainService reservationService;

        public ReservationController(IReservationDomainService reservationService)
        {
            this.reservationService = reservationService;
        }

        public JsonResult GetById(int id = 0)
        {
            if (id == 0)
            {
                return null;
            }

            var reservationDto = this.reservationService.Find(id);
            return this.Json(reservationDto, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List(int page = 1, string sortBy = null)
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = ReservationListViewHelper.CurrentSortBy ?? nameof(ReservationDto.ReservationDate);
            }

            const int MaxCount = 5;
            var skipCount = (page - 1) * MaxCount;
            var response = reservationService.FindAll(new PaginationInputDto(skipCount, MaxCount, sortBy));
            var dtoList = response.Items;
            var toDecimalRound = (decimal)response.SourceTotal / (decimal)MaxCount;
            var toIntegerRound = response.SourceTotal / MaxCount;
            var toRound = toDecimalRound > toIntegerRound ? toIntegerRound + 1 : toIntegerRound;
            this.ViewBag.PageCount = toRound;
            ReservationListViewHelper.CurrentSortBy = sortBy;
            this.ViewBag.CurrentPage = page;
            return View(dtoList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReservationInputDto input)
        {
            if (!this.ModelState.IsValid)
            {
                var message = this.ValidateFields();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
            }

            try
            {
                var reservation = input;
                this.reservationService.Add(reservation);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception e)
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

            var reservationDto = this.reservationService.Find(id);
            return View(reservationDto);
        }

        public ActionResult EditFavorite(int id = 0, bool isFavorite = false)
        {
            if (id == 0)
            {
                return RedirectToAction("List");
            }

            var reservationDto = reservationService.Find(id);
            reservationDto.IsFavorite = isFavorite;
            this.reservationService.Update(reservationDto);
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Edit(ReservationDto input)
        {
            if (!ModelState.IsValid)
            {
                var message = this.ValidateFields();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
            }

            try
            {
                this.reservationService.Update(input);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Remove(int id)
        {
            reservationService.Remove(id);
            return RedirectToAction("List");
        }
    }
}