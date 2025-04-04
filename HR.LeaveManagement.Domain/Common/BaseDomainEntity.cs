﻿namespace HR.LeaveManagement.Domain.Common;

public abstract class BaseDomainEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = "System"; // Default Value
    public DateTime LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; } = "System"; // Default Value
}
