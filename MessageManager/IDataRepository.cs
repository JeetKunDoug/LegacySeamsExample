using System;
using System.Xml.Linq;

namespace MessageManager
{

	public interface IDataRepository 
	{
		XDocument GetData(int id);
	}
}