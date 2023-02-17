using System.Buffers;

namespace LfSync.Data.LCModel;

public class LfTsString
{
    public Guid Owner { get; set; }
    public int OwningFlid { get; set; }
    public string Text { get; set; }
    public string Runs { get; set; }
}

public class LfWsTsString : LfTsString
{
    public string WritingSystem { get; set; }
}