using System;
using System.Xml.Linq;

namespace MessageManager
{
	public class DataRepository: IDataRepository
	{
		public DataRepository ()
		{
		}

		public XDocument GetData (int id)
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