namespace PlayStudio.Server.Model
{
      public class CreateEventModel
      {
            public string Title { get; set; }

            public string? Description { get; set; }

            public DateTime ScheduledDateTime { get; set; }
      }
}
