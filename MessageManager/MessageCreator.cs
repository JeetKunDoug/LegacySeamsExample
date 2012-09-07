using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace MessageManager
{
	public class MessageCreator
	{
		IMessageSender sender;
		IDataRepository repository;

		public MessageCreator (IMessageSender sender, IDataRepository repository)
		{
			this.sender = sender;
			this.repository = repository;
		}

		public MessageCreator(): this(new MessageSender(), new DataRepository())
		{
		}

		public void CreateAndSendMessage(int id, string otherData) 
		{
			XDocument message = this.CreateMessage(id, otherData);
			this.sender.SendMessage(message);
		}

		private XDocument CreateMessage(int id, string otherData) 
		{
			var data = this.repository.GetData(id);
			data.Element ("Document").Add (
				new XElement("AdditionalData", otherData)
				);
			return data;
		}
	}
}
