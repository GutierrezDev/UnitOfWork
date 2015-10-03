using UnitOfWork.Repository.Interfaces;
using UOW.Web.DataModel1;
using UOW.Web.DataModel2;

namespace UOW.Web.Service
{
	public class ManageAccountsAndContacts : IManageAccountsAndContacts
	{
		private readonly IRepository<Account, X4fleet> _repositoryTest1;
		private readonly IRepository<ERP_Contacts, NoTime> _repositoryTest2;

		public ManageAccountsAndContacts(IRepository<Account, X4fleet> repositoryTest1, IRepository<ERP_Contacts, NoTime> repositoryTest2)
		{
			_repositoryTest1 = repositoryTest1;
			_repositoryTest2 = repositoryTest2;
		}

		public void Bla()
		{
			var a = _repositoryTest1.Count();
			var b = _repositoryTest2.Count();
		}
	}
}