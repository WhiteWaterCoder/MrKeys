using System.Collections.Generic;
using MindTouch.Dream;
using MindTouch.Xml;

namespace MusicXml
{
	public class XScore
	{
		private readonly XDoc theDocument;

		public XScore(string aFileName)
		{
			theDocument = XDocFactory.LoadFrom(aFileName, MimeType.XML);
		}

		public string MovementTitle
		{
			get { return theDocument["movement-title"].AsText; }
		}

		public Identification Identification
		{
			get
			{
				return new Identification(theDocument["identification"]);
			}
		}

		public IEnumerable<Part> Parts
		{
			get
			{
				List<Part> parts = new List<Part>();
				foreach (XDoc part in theDocument["part-list/score-part"])
				{
					parts.Add(new Part(part));
				}
				return parts;
			}
		}
	}
}
