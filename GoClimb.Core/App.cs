using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Core.ViewModels;
using GoClimb.Core.ViewModels;
using System.Collections.Generic;

using GoClimb.Core.Service;

namespace GoClimb.Core
{
	public class App : MvxApplication
	{
		public static readonly string AppName = "com.whiteline.GoClimb";
		
		public override void Initialize ()
		{
			CreatableTypes ()
			    .EndingWith ("Service")
			    .AsInterfaces ()
			    .RegisterAsLazySingleton ();
			
			CreatableTypes ()
			    .EndingWith ("Facade")
			    .AsInterfaces ()
			    .RegisterAsLazySingleton ();


			RegisterAppStart (new AppStart ());
		}
	}

	public class AppStart : MvxNavigatingObject, IMvxAppStart
	{
		public void Start (object hint = null)
		{

			var auth = Mvx.Resolve<IAuthService> ();
			auth.Logout ();
			if (auth.Check ()) {
				ShowViewModel<TabbedViewModel> ();
			} else {
				ShowViewModel<LoginViewModel> ();
			}
		}
	}
}
