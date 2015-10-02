using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork;
using UnitOfWork.Test;
using UOW.Web.DataModel1;
using UOW.Web.DataModel2;
using UOW.Web.Service;

namespace UOW.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IManageAccountsAndContacts _accountsAndContacts;

		public HomeController(IManageAccountsAndContacts accountsAndContacts)
		{
			_accountsAndContacts = accountsAndContacts;
		}

		// GET: Home
		public ActionResult Index()
		{

		_accountsAndContacts.Bla();

			return null;
		}
	}
}