using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.UseCases.PluginInterfaces.StateStore
{
	public  interface IStateStore
	{
		void AddStateChangeListeners(Action listeners);
		void RemoveStateChangeListeners(Action listeners);
		void BroadCastStateChange();
	}
}
