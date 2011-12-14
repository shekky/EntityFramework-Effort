﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Effort.Example.Services;
using Microsoft.Practices.Unity;
using Effort.Example.Models;
using System.Data.EntityClient;

namespace Effort.Example.Controllers
{

    public class ProductController : Controller
    {
        [Dependency]
        public IProductService ProductService { get; set; }

        public ActionResult List()
        {
            var result = this.ProductService.GetAllProducts();
            var model = new ProductListModel();

            model.Products = result;

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = this.ProductService.GetProduct(id);

            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

    }
}