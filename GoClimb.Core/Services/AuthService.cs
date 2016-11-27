
using System;
using Xamarin.Auth;
using System.Linq;

namespace GoClimb.Core.Service
{

	public interface IAuthService
	{
		void Login ();
		void Logout ();
		bool Check ();
		string GetApiToken ();
	}

	public class AuthService : IAuthService
	{

		public AuthService ()
		{

		}

		public void Login ()
		{
			Account account = new Account {
				Username = "root"
			};

			account.Properties.Add ("Token", "whmj7an5s0o4g2mlgj2h4pk2ptk1dlcm");
			AccountStore.Create ().Save (account, App.AppName);
		}

		public void Logout ()
		{
			var account = AccountStore.Create ().FindAccountsForService (App.AppName).FirstOrDefault ();
			if (account != null) {
				AccountStore.Create ().Delete (account, App.AppName);
			}
		}

		public bool Check ()
		{
			Account account = AccountStore.Create ().FindAccountsForService (App.AppName).FirstOrDefault ();
			return account != null;
		}

		public string GetApiToken ()
		{
			Account account = AccountStore.Create ().FindAccountsForService (App.AppName).FirstOrDefault ();
			return account.Properties ["Token"];
		}
	}
}
