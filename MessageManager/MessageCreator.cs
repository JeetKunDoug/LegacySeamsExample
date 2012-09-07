using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace MessageManager
{
	public class MessageCreator
	{
		private static Queue<XDocument> messageQueue = new Queue<XDocument>();

		public static XDocument GetNextMessage ()
		{
			return messageQueue.Dequeue ();
		}

		public MessageCreator ()
		{
		}

		public void CreateAndSendMessage(int id, string otherData) 
		{
			XDocument message = this.CreateMessage(id, otherData);
			this.SendMessage(message);
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

		private void SendMessage(XDocument message) 
		{
			// Send the message across the wire to somewhere
			// This message mutates state in another system, which is bad for unit testing the MessageCreator
			// for now, just add the message to an in-memory queue
			MessageCreator.messageQueue.Enqueue (message);
		}
	}
}
