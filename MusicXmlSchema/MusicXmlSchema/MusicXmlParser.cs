using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MusicXmlSchema
{
    public static class MusicXmlParser
    {
        public static ScoreData GetScore(string filename)
        {
            var document = GetXmlDocument(filename);
            var score = new ScoreData();
            // 解析node
            var sp = document.SelectSingleNode("score-partwise");
            // 读版本信息
            score.Version = GetVersion(sp);
            // 读乐谱信息
            score.ScorePart = GetScorePart(filename);
            return score;
        }

        #region XmlDocument

        static XmlDocument GetXmlDocument(string filename)
        {
            var document = new XmlDocument();
            using (var fs = new FileStream(filename, FileMode.Open))
            using (var sr = new StreamReader(fs))
            {
                var xml = sr.ReadToEnd();
                document.XmlResolver = null;
                document.LoadXml(xml);
                return document;
            }
        }

        static ScorePartwise GetScorePart(string filename)
        {
            using (var fs = new FileStream(filename, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    var xml = sr.ReadToEnd();
                    var sp = Deserialize<ScorePartwise>(xml);
                    return sp;
                }
            }
        }

        #endregion

        #region XmlNode

        static MusicXmlVersion GetVersion(XmlNode node)
        {
            if (node?.Attributes != null)
            {
                var ver = node.Attributes["version"]?.InnerText;
                switch (ver)
                {
                    case "2.0":
                        return MusicXmlVersion.V20;
                    case "3.0":
                        return MusicXmlVersion.V30;
                    case "3.1":
                        return MusicXmlVersion.V31;
                }
            }
            return MusicXmlVersion.Unknown;
        }

        #endregion

        #region XmlSerializer

        public static string Serialize<T>(T entity)
        {
            var xmlText = string.Empty;
            try
            {
                if (entity != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        var serializer = new XmlSerializer(entity.GetType());
                        serializer.Serialize(stream, entity);
                        stream.Position = 0;
                        using (var sr = new StreamReader(stream))
                        {
                            xmlText = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                xmlText = string.Empty;
            }
            return xmlText;
        }

        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                using (var sr = new StringReader(xmlText))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(sr);
                }
            }
            catch
            {
                return default(T);
            }
        }

        #endregion

    }
}