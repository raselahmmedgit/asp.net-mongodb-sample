using lab.MongoDBApps.Helpers;
using lab.MongoDBApps.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab.MongoDBApps.Controllers
{

    public class ProductController : Controller
    {
        private ProductRepository _productRepository = new ProductRepository();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetListAjax()
        {
            var list = _productRepository.GetAll();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetByIdAjax(string id)
        {
            var product = _productRepository.Get(new ObjectId(id));
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveAjax(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExistProduct = _productRepository.Get(product.Id);
                    if (isExistProduct != null)
                    {
                        isExistProduct.ProductName = product.ProductName;
                        _productRepository.Update(isExistProduct);
                        product.IsSuccess = true;
                        product.SuccessMessage = Constants.Messages.UpdateSuccess;
                    }
                    else
                    {
                        _productRepository.Insert(product);
                        product.IsSuccess = true;
                        product.SuccessMessage = Constants.Messages.SaveSuccess;
                    }
                }
            }
            catch (Exception ex)
            {
                product.IsSuccess = false;
                product.ErrorMessage = Constants.Messages.ExceptionError(ex);
            }

            return Json(product, JsonRequestBehavior.DenyGet);

        }

        [HttpPost]
        public ActionResult DeleteAjax(string id)
        {
            var product = new Product();
            try
            {
                product = _productRepository.Get(new ObjectId(id));
                if (product != null)
                {
                    _productRepository.Delete(product);
                    product.IsSuccess = true;
                    product.SuccessMessage = Constants.Messages.DeleteSuccess;
                }
                else
                {
                    product.IsSuccess = false;
                    product.SuccessMessage = Constants.Messages.NotFound;
                }
            }
            catch (Exception ex)
            {
                product.IsSuccess = false;
                product.ErrorMessage = Constants.Messages.ExceptionError(ex);
            }

            return Json(product, JsonRequestBehavior.DenyGet);

        }
    }
}