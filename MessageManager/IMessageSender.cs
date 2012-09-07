using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace MessageManager
{

	public interface IMessageSender 
	{
		void SendMessage(XDocument message);
	}
}
