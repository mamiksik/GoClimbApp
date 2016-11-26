using MvvmCross.Platform.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using UIKit;
using Xamarin.Forms;
using MvvmCross.Forms.Presenter.iOS;
using MvvmCross.Forms.Presenter.Core;

namespace GoClimb.iOS
{
	public class Setup : MvxIosSetup
	{
		public Setup (MvxApplicationDelegate applicationDelegate, UIWindow window)
		    : base (applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new Core.App ();
		}

		protected override IMvxTrace CreateDebugTrace ()
		{
			return new DebugTrace ();
		}

		protected override IMvxIosViewPresenter CreatePresenter ()
		{
			Forms.Init ();

			var xamarinFormsApp = new MvxFormsApp ();
			//xamarinFormsApp.MainPage = new TabbedPage();

			return new MvxFormsIosPagePresenter (Window, xamarinFormsApp);
			//return new IosTabbedPresenter (Window, xamarinFormsApp);
			//var t = new MvxPrese<>;
			//test.ChangePresentation (t);
			//return test;
			//return new MvxForms ();
		}
	}
}
