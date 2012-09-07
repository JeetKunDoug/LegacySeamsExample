using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace MessageManager
{
	public class MessageSender: IMessageSender
	{
		private static Queue<XDocument> messageQueue = new Queue<XDocument>();

		/// <summary>
		/// Gets the next message on the queue. Note that in reality, this class sends messages to an external system,
		/// and validating the message send is more difficult than merely checking a queue.
		/// </summary>
		/// <returns>
		/// The next message.
		/// </returns>
		public static XDocument GetNextMessage ()
		{
			return messageQueue.Dequeue ();
		}

		public MessageSender ()
		{
		}

		public void SendMessage(XDocument message) 
		{
			// Send the message across the wire to somewhere
			// This message mutates state in another system, which is bad for unit testing the MessageCreator
			// for now, just add the message to an in-memory queue
			messageQueue.Enqueue (message);
		}
	}

}

