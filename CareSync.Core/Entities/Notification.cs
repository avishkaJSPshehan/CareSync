using System;

namespace CareSync.Core.Entities;

public class Notification
{
    public int NotificationId { get; set; }
    public Guid UserId { get; set; }
    public string Message { get; set; }
    public DateTime SentAt { get; set; }
    public bool IsRead { get; set; }

    public ApplicationUser User { get; set; }
}

