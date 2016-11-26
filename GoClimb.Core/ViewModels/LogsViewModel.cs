using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using System.Collections.ObjectModel;
using GoClimb.Core.Model.Entities;
using GoClimb.Core.Model.Facades;
using MvvmCross.Platform;
using System;

namespace GoClimb.Core.ViewModels
{
	public class LogsViewModel : MvxViewModel
	{

		public MvxObservableCollection<Log> LogsList {
			get { return collection; }
			set {
				collection = value;
				RaisePropertyChanged (() => LogsList);
			}
		}


		public bool IsRefreshing {
			get { return isRefreshing; }
			set {
				isRefreshing = value;
				RaisePropertyChanged (() => IsRefreshing);
			}
		}


		public Log SelectedLog {
			get { return selectedLog; }
			set {
				selectedLog = value;
				RaisePropertyChanged (() => SelectedLog);

				ShowSelectedLogCommand.Execute (null);
			}
		}

		private MvxObservableCollection<Log> collection;
		private bool isRefreshing;
		private Log selectedLog;

		private ILogsFacade logsFacade;

		public LogsViewModel (ILogsFacade logsFacade)
		{
			this.logsFacade = logsFacade;
			LoadData ();
		}

		public ICommand LoadDataCommand {
			get { return new MvxCommand (() => LoadData ()); }
		}

		public ICommand ShowSelectedLogCommand {
			get {
				return new MvxCommand (() => ShowViewModel<DetailLogViewModel> (new { logId = SelectedLog.Id }),() => SelectedLog != null);
				//return new MvxCommand (() => ShowViewModel<DetailLogViewModel> (new { logId = SelectedLog.Id }));
			}
		}

		public async void LoadData ()
		{
			try {
				IsRefreshing = true;
				Mvx.Warning ("Loading Data");
				LogsList = new MvxObservableCollection<Log> (await logsFacade.getAllLogs ());
				IsRefreshing = false;
			} catch (Exception e) {
				//Todo: No internet conection
				Mvx.Warning (e.Message.ToString ());
				IsRefreshing = false;
			}
		}
	}
}