using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XmlAnyConsole
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot]
    public class XmlAnyObject
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        private static string XmlStartStc { get { return "<" + typeof(XmlAnyObject).Name + ">"; } }

        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        private static string XmlEndStc { get { return "</" + typeof(XmlAnyObject).Name + ">"; } }

        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        private string XmlStart { get { return "<" + typeof(XmlAnyObject).Name + ">"; } }

        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        private string XmlEnd { get { return "</" + typeof(XmlAnyObject).Name + ">"; } }

        /// <summary>
        /// 
        /// </summary>
        public XmlAnyObject()
	    {
	    }

        /// <summary>
        /// 
        /// </summary>
        [XmlAnyElement]
        public XmlElement[] Elements { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAnyAttribute]
        public XmlAttribute[] Attributes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public XmlAnyObject[] Children
        {
            get
            {
                List<XmlAnyObject> xChilds = new List<XmlAnyObject>();
                if (null != this.Elements && this.Elements.Length > 0)
                {
                    for (int i = 0; i < this.Elements.Length; i++)
                    {
                        using (StringReader stringReader = new StringReader(this.XmlStart + this.Elements[i].InnerXml + this.XmlEnd))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(XmlAnyObject));
                            xChilds.Add(serializer.Deserialize(stringReader) as XmlAnyObject);
                        }
                    }
                }
                return xChilds.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static XmlAnyObject Deserialize(string xml)
        {
            const string xmlStartDeclaration = "<?",
                         xmlEndDeclaration = "?>";
            if (xml.Contains(xmlStartDeclaration) && xml.Contains(xmlEndDeclaration))
            {
                int startPos = xml.LastIndexOf(xmlStartDeclaration) + xmlStartDeclaration.Length,
                  length = xml.IndexOf(xmlEndDeclaration) - startPos;

                string sub = xml.Substring(startPos, length);

                xml = xml.Replace(xmlStartDeclaration, "").Replace(xmlEndDeclaration, "").Replace(sub, "");
            }
            using (StringReader stringReader = new StringReader(XmlStartStc + xml + XmlEndStc))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XmlAnyObject));
                return (XmlAnyObject)serializer.Deserialize(stringReader);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(XmlAnyObject obj)
        {
            using (StringWriter writer = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XmlAnyObject));
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }
    }
}