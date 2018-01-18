﻿/*!
 * http://www.zkea.net/
 * Copyright 2017 ZKEASOFT
 * http://www.zkea.net/licenses
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Easy.Mvc.Controllers;
using ZKEACMS.Shop.Models;
using ZKEACMS.Shop.Service;
using Easy.Mvc.Authorize;
using Alipay.AopSdk.Core.Domain;
using Alipay.AopSdk.Core.Request;
using Alipay.AopSdk.AspnetCore;

namespace ZKEACMS.Shop.Controllers
{
    [DefaultAuthorize(Policy = PermissionKeys.ViewOrder)]
    public class OrderController : BasicController<Order, string, IOrderService>
    {
        public OrderController(IOrderService service) : base(service)
        {
        }
        [NonAction]
        public override IActionResult Create()
        {
            return base.Create();
        }
        [HttpPost, NonAction]
        public override IActionResult Create(Order entity)
        {
            return base.Create(entity);
        }
        [DefaultAuthorize(Policy = PermissionKeys.ManageOrder)]
        public override IActionResult Edit(string Id)
        {
            return base.Edit(Id);
        }
        [HttpPost, DefaultAuthorize(Policy = PermissionKeys.ManageOrder)]
        public override IActionResult Edit(Order entity)
        {
            return base.Edit(entity);
        }
        [HttpPost, DefaultAuthorize(Policy = PermissionKeys.ManageOrder)]
        public override IActionResult Delete(string id)
        {
            return base.Delete(id);
        }
        public IActionResult PaymentInfo(string id)
        {
            return PartialView(Service.GetPaymentInfo(id));
        }
        public IActionResult Refund(string id, decimal amount, string reason)
        {
            Service.Refund(id, amount, reason);
            return Json(true);
        }
    }
}
