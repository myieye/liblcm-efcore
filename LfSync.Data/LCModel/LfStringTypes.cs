using System.Security.Cryptography.X509Certificates;

namespace LfSync.Data.LCModel
{
    public class LfTsString
    {
        //public Guid Owner { get; set; }
        //public int OwningFlid { get; set; }
        public string? Text { get; init; }
        public List<LfTsStringRun> Runs { get; init; }
    }

    public class LfWsTsString : LfTsString
    {
        public string? WritingSystem { get; set; }
    }

    public class LfTsStringRun
    {
        public int IndexLim { get; set; }
        public List<TextProperty>? Properties { get; set; }
    }

    public class TextProperty
    {
        public int Key { get; set; }

        public TextProperty()
        { }
    }

    public class IntTextProperty : TextProperty
    {
        public int Value { get; set; }
        public int Variation { get; set; }

        public IntTextProperty() : base()
        { }
    }

    public class StringTextProperty : TextProperty
    {
        public string? Value { get; set; }

        public StringTextProperty() : base()
        { }

    }
}