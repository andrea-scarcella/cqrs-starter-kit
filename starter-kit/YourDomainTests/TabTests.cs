using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edument.CQRS;
using Events.Tab;
using NUnit.Framework;
using YourDomain.Tab;

namespace YourDomainTests
{
	public class TabTests : BDDTest<TabCommandHandlers, TabAggregate>
	{
		private Guid testId;
		private int testTable;
		private string testWaiter;
		private OrderedItem testDrink1;

		[SetUp]
		public void Setup()
		{
			testId = Guid.NewGuid();
			testTable = 42;
			testWaiter = "Derek";
			testDrink1 = new OrderedItem() { Description = "drink", IsDrink = true, MenuNumber = 0, Price = 1.0m };
		}
		[Test]
		public void CanOpenANewTab()
		{
			Test(
				Given(),
				When(
				new OpenTab()
				{
					Id = testId,
					TableNumber = testTable,
					Waiter = testWaiter
				}), Then(
				new TabOpened()
				{
					Id = testId,
					TableNumber = testTable,
					Waiter = testWaiter
				}));
		}

		[Test]
		public void CanNotOrderWithUnopenedTab()
		{
			Test(Given(),
				When(new PlaceOrder()
				{
					Id = testId,
					Items = new List<OrderedItem>() { testDrink1 }
				}), ThenFailWith<TabNotOpen>());

		}
	}
}
