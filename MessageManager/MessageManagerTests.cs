using Moq;
using System;
using NUnit.Framework;
using System.Xml.Linq;

namespace MessageManager
{
	[TestFixture()]
	public class MessageManagerTests_CreateAndSendMessage
	{

		int id = 1;
		string otherData = "Some other data";
		XDocument result;

		[SetUp()]
		public void SetUp ()
		{
			var sender = new Mock<IMessageSender>(MockBehavior.Strict);
			var repo = new Mock<IDataRepository>(MockBehavior.Strict);
			sender.Setup (s => s.SendMessage(It.IsAny<XDocument>()))
				.Callback<XDocument>(d => result = d);
			repo.Setup(r => r.GetData(id))
				.Returns(new XDocument(new XElement("Document", new XAttribute("Id", this.id))));

			var creator = new MessageCreator(sender.Object, repo.Object);
			creator.CreateAndSendMessage(id, otherData);
		}

		[Test]
		public void should_add_correct_id ()
		{
			Assert.That (result.Root.Attribute ("Id").Value, Is.EqualTo (this.id.ToString ()));
		}

		[Test]
		public void should_set_other_data ()
		{
			Assert.That (result.Root.Element ("AdditionalData").Value, Is.EqualTo (this.otherData));
		}
	}
}

