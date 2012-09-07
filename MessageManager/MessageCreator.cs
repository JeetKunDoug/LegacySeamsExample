using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace MessageManager
{
	public class MessageCreator
	{
		IMessageSender sender;

		public MessageCreator (IMessageSender sender)
		{
			this.sender = sender;
		}

		public MessageCreator(): this(new MessageSender())
		{
		}

		public void CreateAndSendMessage(int id, string otherData) 
		{
			XDocument message = this.CreateMessage(id, otherData);
			this.sender.SendMessage(message);
		}

		private XDocument CreateMessage(int id, string otherData) 
		{
			var data = this.GetDataFromDatabase(id);
			data.Element ("Document").Add (
				new XElement("AdditionalData", otherData)
				);
			return data;
		}

		private XDocument GetDataFromDatabase (int id)
		{
			// In the real world, this actually calls a stored procedure which returns XML
			var doc = new XDocument(
				new XElement("Document", 
			             new XAttribute("Id", id)
			             )
				);
			return doc;
		}
	}
}
