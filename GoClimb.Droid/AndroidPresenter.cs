using MvvmCross.Droid.Views;
using MvvmCross.Forms.Presenter.Core;

namespace MvvmCross.Forms.Presenter.Droid
{
	public class AndroidPresenter : MvxFormsPagePresenter, IMvxAndroidViewPresenter
	{
		public AndroidPresenter ()
		{
		}

		public AndroidPresenter (MvxFormsApp mvxFormsApp)
		    : base (mvxFormsApp)
		{
		}
	}
}