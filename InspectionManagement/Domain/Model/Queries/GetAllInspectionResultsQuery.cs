namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;

public record GetAllInspectionResultsQuery(int? InspectionId = null, int? ChecklistItemId = null);