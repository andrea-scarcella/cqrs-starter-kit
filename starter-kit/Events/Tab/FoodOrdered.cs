using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Tab
{
	public class FoodOrdered
	{
		public Guid Id;
		public List<OrderedItem> Items;
	}
}
