using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.UseCase.PluginInterfaces.StateStore;
namespace ClassLibrary1
{
	public  class StateStoreBase : IStateStore
	{
		protected Action listeners;
		public void AddStateChangeListeners(Action listeners) => this.listeners += listeners;
		public void RemoveStateChangeListeners(Action listeners) => this.listeners -= listeners;


		public void BroadCastStateChange()
		{
			if (this.listeners != null)
			{
				this.listeners.Invoke();
			}
		}
	}
}
