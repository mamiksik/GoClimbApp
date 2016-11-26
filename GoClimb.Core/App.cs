using MvvmCross.Platform.IoC;
using MvvmCross.Core.ViewModels;
using GoClimb.Core.ViewModels;

using System.Collections.Generic;

namespace GoClimb.Core
{
	public class App : MvxApplication
	{

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

			//var auth = Mvx.Resolve<IAuth> ();
			//if (auth.Check ()) {
			//	ShowViewModel<HomeViewModel> ();
			//} else {
			ShowViewModel<TabbedViewModel> ();
			//}
		}
	}
}
