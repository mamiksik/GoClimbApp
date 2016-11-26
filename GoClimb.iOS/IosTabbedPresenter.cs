using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using System;
using Xamarin.Forms;
using MvvmCross.Binding.BindingContext;

using MvvmCross.Forms.Presenter.Core;
using MvvmCross.iOS.Views.Presenters;
using UIKit;

using System.Collections.Generic;


namespace GoClimb.iOS
{
	public class IosTabbedPresenter : MvxFormsPagePresenter, IMvxIosViewPresenter
	{
		private readonly UIWindow _window;

		public IosTabbedPresenter (UIWindow window, Xamarin.Forms.Application mvxFormsApp)
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

		public override void Show (MvxViewModelRequest request)
		{
			if (TryShowPage (request)) {
				return;
			}

			Mvx.Error ("Skipping request for {0}", request.ViewModelType.Name);
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

			//var viewModel = MvxPresenterHelpers.LoadViewModel (request);
			//SetupForBinding (page, viewModel, request);

			MvxFormsApp.MainPage = page;
			_window.RootViewController = MvxFormsApp.MainPage.CreateViewController ();

			return true;
		}
	}
}
