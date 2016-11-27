using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using System;
using Xamarin.Forms;

using MvvmCross.Forms.Presenter.Core;


namespace GoClimb.iOS
{
	public abstract class MainPresenter : MvxViewPresenter
	{
		private Application MvxFormsApp;


		public MainPresenter (Application mvxFormsApp)
		{
			MvxFormsApp = mvxFormsApp;
		}

		public override void Show (MvxViewModelRequest request)
		{
			if (TryShowPage (request)) {
				return;
			}

			Mvx.Error ("Skipping request for {0}", request.ViewModelType.Name);
		}

		public override void ChangePresentation (MvxPresentationHint hint)
		{
			if (HandlePresentationChange (hint)) return;

			if (hint is MvxClosePresentationHint) {
				var mainPage = MvxFormsApp.MainPage as NavigationPage;

				if (mainPage == null) {
					Mvx.TaggedTrace ("MvxFormsPresenter:ChangePresentation()", "Oops! Don't know what to do");
				} else {
					mainPage.PopAsync ();
				}
			}
		}

		protected virtual void CustomPlatformInitialization (NavigationPage mainPage)
		{
		}

		private void SetupForBinding (Page page, IMvxViewModel viewModel, MvxViewModelRequest request)
		{
			var mvxContentPage = page as IMvxContentPage;
			if (mvxContentPage != null) {
				mvxContentPage.Request = request;
				mvxContentPage.ViewModel = viewModel;
			} else {
				page.BindingContext = viewModel;
			}

		}

		private bool TryShowPage (MvxViewModelRequest request)
		{
			var page = MvxPresenterHelpers.CreatePage (request);
			if (page == null)
				return false;

			var viewModel = MvxPresenterHelpers.LoadViewModel (request);

			SetupForBinding (page, viewModel, request);

			var mainPage = MvxFormsApp.MainPage as NavigationPage;
			
			if (request.PresentationValues != null) {
				if (request.PresentationValues.ContainsKey ("NavigationMode") && request.PresentationValues ["NavigationMode"] == "ClearStack") {
					mainPage = null;
				}
			}

			if (mainPage == null) {
				MvxFormsApp.MainPage = new NavigationPage (page);
				mainPage = MvxFormsApp.MainPage as NavigationPage;
				CustomPlatformInitialization (mainPage);
			} else {
				try {
					mainPage.PushAsync (page);
				} catch (Exception e) {
					Mvx.Error ("Exception pushing {0}: {1}\n{2}", page.GetType (), e.Message, e.StackTrace);
					return false;
				}
			}

			return true;
		}
	}
}
