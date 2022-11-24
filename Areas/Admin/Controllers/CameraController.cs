﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechRentingSystem.Data;
using TechRentingSystem.Data.Models;
using TechRentingSystem.Models.Cameras;
using TechRentingSystem.Models.Home;
using TechRentingSystem.Repository.Repository;

namespace TechRentingSystem.Areas.Admin.Controllers
{
    public class CameraController : BaseController
    {
   
        private readonly IUnitOfWork _unitOfWork;

        public CameraController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var allCameras = await this._unitOfWork.Product.GetCamerasAsync();
           
            return View(allCameras);
        }
        public async Task<IActionResult> Add() => this.View(new AddCameraFromModel
        {
            Categories = await this._unitOfWork.Product.GetCameraCategories()
        });

     

        [HttpPost]
        public async Task<IActionResult> Add(AddCameraFromModel camera)
        {

            await this._unitOfWork.Product.Add(camera);

            return this.RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this._unitOfWork.Product.Delete(id);

            return this.RedirectToAction(nameof(Index));
        }

     

    }
}
