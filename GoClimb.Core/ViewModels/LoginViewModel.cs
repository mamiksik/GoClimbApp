using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System.Windows.Input;

namespace GoClimb.Core.ViewModels
{
	public class TestViewModel : MvxViewModel
	{
		public ICommand TestCommand {
		//ShowViewModel<AboutViewModel> ()
			//get { return new MvxCommand (() =>  Mvx.Warning("Command tested")); }
			get { return new MvxCommand (() =>  ShowViewModel<AboutViewModel> ()); }
		}
	}
}