using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edument.CQRS;
using NUnit.Framework;
using YourDomain.Tab;

namespace YourDomainTests
{
	public class TabTests : BDDTest<TabCommandHandlers, TabAggregate>
	{
		private Guid testId;
		private int testTable;
		private string testWaiter;

		[SetUp]
		public void Setup()
		{
			testId = Guid.NewGuid();
			testTable = 42;
			testWaiter = "Derek";
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
				new OpenTab()
				{
					Id = testId,
					TableNumber = testTable,
					Waiter = testWaiter
				}));
		}
	}
}
