using Fleet.Care.Platform.Iam.Domain.Model.ValueObjects;
using Fleet.Care.Platform.Shared.Domain.Model.Events;

namespace Fleet.Care.Platform.Iam.Domain.Model.Events;

public record UserRegisteredEvent(UserId UserId, string Username) : IEvent;