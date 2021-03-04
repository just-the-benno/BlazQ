using System;

namespace BlazQ.Shared
{
    public class CreatePlayerRequest
    {
        public String Name { get; set; }
        public String AvatarUrl { get; set; }
        public Guid Id { get; set; }
    }
}
