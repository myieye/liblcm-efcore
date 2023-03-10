using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SIL.WritingSystems;

namespace SIL.LCModel.EFCore.Model;

public class WritingSystem
{
    [Key]
    public required string Id { get; init; }
    public required string LanguageTag { get; init; }
    public required string Abbreviation { get; init; }
    public required string LanguageName { get; init; }
    public required string DisplayName { get; init; }
    public required string IcuLocale { get; init; }
    public required bool IsRightToLeft { get; init; }
    public required bool IsVoice { get; init; }
    public required IpaStatusChoices IpaType { get; init; }
    [Column(TypeName = "jsonb")]
    public required List<CharacterSet> CharacterSet { get; init; }
    public required string DefaultFontName { get; init; }
    public required bool IsVernacular { get; init; }
    public required bool IsAnalysis { get; init; }
    public required bool IsHidden { get; init; }
}

public class CharacterSet
{
    public required string Type { get; init; }
    public required List<string> Characters { get; init; }
}
