using Xamarin.Forms;
using MvvmCross.iOS.Views.Presenters;
using UIKit;

namespace GoClimb.iOS
{
	public class IOSPresenter : MainPresenter, IMvxIosViewPresenter
	{
		private readonly UIWindow _window;

		public IOSPresenter (UIWindow window, Xamarin.Forms.Application mvxFormsApp)
		    : base (mvxFormsApp)
		{
			_window = window;
		}

		public virtual bool PresentModalViewController (UIViewController controller, bool animated)
		{
			return false;
		}

		public virtual void NativeModalViewControllerDisappearedOnItsOwn ()
		{
		}

		protected override void CustomPlatformInitialization (NavigationPage mainPage)
		{
			_window.RootViewController = mainPage.CreateViewController ();
		}
	}
}
