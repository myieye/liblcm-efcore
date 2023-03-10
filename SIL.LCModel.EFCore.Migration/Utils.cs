using SIL.LCModel.Core.WritingSystems;
using SIL.Linq;

namespace SIL.LCModel.EFCore.Migration;

public static class Utils
{
    public static void Print(string header, IEnumerable<CoreWritingSystemDefinition> writingSystems)
    {
        Print($"--- {header} ---");
        writingSystems.ForEach(ws => Print($"{ws.Handle}: {ws}"));
        Print();
    }

    public static void Print(string text = "")
    {
        Console.Out.WriteLine(text);
    }
}
