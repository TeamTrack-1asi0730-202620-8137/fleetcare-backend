using Fleet.Care.Platform.Shared.Domain.Model.ValueObjects;

namespace Fleet.Care.Platform.Iam.Domain.Model.ValueObjects;

/// <summary>
///     Represents a unique identifier for a user.
/// </summary>
/// <param name="Value"></param>
public readonly record struct UserId(int Value) : IEntityId<int>
{
    public static implicit operator int(UserId id)
    {
        return id.Value;
    }

    public static implicit operator UserId(int value)
    {
        return new UserId(value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}