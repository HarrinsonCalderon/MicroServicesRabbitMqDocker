using System;
using System.Collections.Generic;
using MicroServi
public class IAccountRepository
{
	public IAccountRepository()
	{
		IEnumerable<Account> GetAccounts();
	}
}
