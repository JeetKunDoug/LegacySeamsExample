using System;
using NUnit.Framework;

namespace MessageManager
{
	[TestFixture()]
	public class MessageManagerIntegrationTests
	{
		[Test()]
		public void TestMessageSending ()
		{
			var creator = new MessageCreator();
			var otherData = "Some Other Data";
			var id = 1;
			creator.CreateAndSendMessage(id, otherData);
			var message = MessageCreator.GetNextMessage ();
			var root = message.Root;
			Assert.That (root.Attribute("Id").Value, Is.EqualTo (id.ToString()));
			Assert.That (root.Element ("AdditionalData").Value, Is.EqualTo(otherData));
		}
	}
}

