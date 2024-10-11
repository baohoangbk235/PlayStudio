namespace PlayStudio.Server.Model
{
      public class CreateEventModel
      {
            public string Title { get; set; } = string.Empty;

            public string? Description { get; set; }

            public string ScheduledDateTime { get; set; } = string.Empty;
      }
}
