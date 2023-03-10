using System.ComponentModel.DataAnnotations;

namespace SIL.LCModel.EFCore.Model;

/// <summary>
/// For Preserving references to ICmObjects, which don't get their own table.
/// It would likely make sense for every LfObject to have an LfObjectId. Then we'd be able to cascade deletes and avoid orphaned LfObjectIds.
/// </summary>
public class LfObjectId
{
    [Key]
    public required Guid Guid { get; init; }
    public required string Discriminator { get; init; }
}
