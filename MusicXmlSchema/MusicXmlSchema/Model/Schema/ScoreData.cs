namespace MusicXmlSchema
{
    public class ScoreData
    {
        public MusicXmlVersion Version { get; set; } = MusicXmlVersion.Unknown;
        public ScorePartwise ScorePart { get; set; } = new ScorePartwise();
    }
}