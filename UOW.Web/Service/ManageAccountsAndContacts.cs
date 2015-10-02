using UnitOfWork;
using UnitOfWork.Test;
using UOW.Web.DataModel1;
using UOW.Web.DataModel2;

namespace UOW.Web.Service
{
	public class ManageAccountsAndContacts : IManageAccountsAndContacts
	{
		private readonly IUnitOfWorkTest<X4fleet> _unitOfWorkTest1;
		private readonly IUnitOfWorkTest<NoTime> _unitOfWorkTest2;
		private readonly IRepositoryTest<Account, X4fleet> _repositoryTest1;
		private readonly IRepositoryTest<ERP_Contacts, NoTime> _repositoryTest2;

		public ManageAccountsAndContacts(IUnitOfWorkTest<X4fleet> unitOfWorkTest1, IUnitOfWorkTest<NoTime> unitOfWorkTest2, IRepositoryTest<Account, X4fleet> repositoryTest1, IRepositoryTest<ERP_Contacts, NoTime> repositoryTest2)
		{
			_unitOfWorkTest1 = unitOfWorkTest1;
			_unitOfWorkTest2 = unitOfWorkTest2;
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