using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System.Windows.Input;
using GoClimb.Core.Model.Entities;
using GoClimb.Core.Model.Facades;

namespace GoClimb.Core.ViewModels
{
	public class DetailLogViewModel : MvxViewModel
	{

		public Log Log {
			get { return log; }
			set {
				log = value;
				RaisePropertyChanged (() => Log);
			}
		}

		private int logId;
		private Log log;
		private ILogsFacade logsFacade;

		public DetailLogViewModel (ILogsFacade logsFacade)
		{
			//this.logsFacade = logsFacade;
			this.logsFacade = Mvx.Resolve<ILogsFacade> ();
		}

		public void Init (int logId)
		{
			this.logId = logId;
		}

		public override async void Start ()
		{
			base.Start ();
			Mvx.Warning ("ID: " + logId.ToString ());

			if (logsFacade == null) {
				Mvx.Warning ("null");
				return;
			} else {
				Mvx.Warning ("Not null");
			}

			Mvx.Warning ("ID: " + logId.ToString ());

			Log = await logsFacade.GetLog (logId);
		}
	}
}