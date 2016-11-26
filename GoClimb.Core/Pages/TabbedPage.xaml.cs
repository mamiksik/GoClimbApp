using Xamarin.Forms;
using System.Collections.Generic;
using MvvmCross.Platform;
using GoClimb.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenter.Core;
//using BottomBar.XamarinForms;

namespace GoClimb.Core.Pages
{
	public partial class TabbedPage : Xamarin.Forms.TabbedPage
	{
		public TabbedPage ()
		{
			addTab<LogsViewModel> ();
			addTab<AboutViewModel> ();
			addTab<TestViewModel> ();
		}

		private void addTab<T> ()
		{
			var request = new MvxViewModelRequest (typeof (T), null, null, null);
			var page = MvxPresenterHelpers.CreatePage (request);
		
			page.BindingContext = MvxPresenterHelpers.LoadViewModel (request); ;
			Children.Add (page);
		}
	}
}
