using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System.Windows.Input;
using GoClimb.Core.Service;
using System.Collections.Generic;

namespace GoClimb.Core.ViewModels
{
	public class LoginViewModel : MvxViewModel
	{

		private IAuthService authService;

		public LoginViewModel (IAuthService authService)
		{
			this.authService = authService;
			//if (authService.Check ()) {
			//	var presentationBundle = new MvxBundle (new Dictionary<string, string> { { "NavigationMode", "ClearStack" } });
			//	ShowViewModel<TabbedViewModel> (presentationBundle);
			//}s
		}

		public ICommand LoginCommand {
			get { return new MvxCommand (() => Login ()); }
		}

		public void Login ()
		{
			IAuthService authService = Mvx.Resolve<IAuthService> ();
			authService.Login ();

			var presentationBundle = new MvxBundle (new Dictionary<string, string> { { "NavigationMode", "ClearStack" } });
			ShowViewModel<TabbedViewModel> (presentationBundle: presentationBundle);
		}
	}
}