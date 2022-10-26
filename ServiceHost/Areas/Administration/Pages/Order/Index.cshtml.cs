using System.Collections.Generic;
using LangoTop.Application.Contract.Account;
using LangoTop.Application.Contract.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Order
{
    public class IndexModel : PageModel
    {
        public OrderSearchModel SearchModel;
        public List<OrderViewModel> Orders;
        public SelectList Accounts;

        private readonly IOrderApplication _orderApplication;
        private readonly IAccountApplication _accountApplication;

        public IndexModel(IOrderApplication orderApplication, IAccountApplication accountApplication)
        {
            _orderApplication = orderApplication;
            _accountApplication = accountApplication;
        }

        //[NeedsPermission(ShopPermissions.ListOrder)]
        public void OnGet(OrderSearchModel searchModel)
        {
            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "Fullname");
            Orders = _orderApplication.Search(searchModel);
        }

        //[NeedsPermission(ShopPermissions.Confirm)]
        public IActionResult OnGetConfirm(long id)
        {
            _orderApplication.PaymentSucceeded(id, 0);
            return RedirectToPage("/Index");
        }

        //[NeedsPermission(ShopPermissions.Cancel)]
        public IActionResult OnGetCancel(long id)
        {
            _orderApplication.Cancel(id);
            return RedirectToPage("/Index");
        }

        //[NeedsPermission(ShopPermissions.GetItems)]
        public IActionResult OnGetItems(long id)
        {
            var items = _orderApplication.GetItems(id);
            return Partial("Items", items);
        }

        //[NeedsPermission(ShopPermissions.GetInfo)]
        public IActionResult OnGetInfo(long id)
        {
            var items = _orderApplication.GetInfoBy(id);
            return Partial("Info", items);
        }
    }
}