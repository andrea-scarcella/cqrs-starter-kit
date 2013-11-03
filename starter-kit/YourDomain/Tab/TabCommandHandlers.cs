using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edument.CQRS;
using Events.Tab;

namespace YourDomain.Tab
{
	public class TabCommandHandlers : IHandleCommand<OpenTab, TabAggregate>
	{
		public System.Collections.IEnumerable Handle(Func<Guid, TabAggregate> al, OpenTab c)
		{
			yield return new TabOpened
			{
				Id = c.Id,
				TableNumber = c.TableNumber,
				Waiter = c.Waiter
			};
		}
	}
}
