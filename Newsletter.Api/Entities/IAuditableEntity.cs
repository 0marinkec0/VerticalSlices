namespace Newsletter.Api.Entities;

public interface IAuditableEntity
{
        DateTime CreatedOnUtc { get; set; }

        DateTime? ModifiedOnUtc { get; set; }
}
