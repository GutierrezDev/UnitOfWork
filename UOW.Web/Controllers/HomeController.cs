using System.Web.Mvc;
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