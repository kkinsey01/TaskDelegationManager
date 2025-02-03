﻿namespace TaskDelegationAPI.DTOs
{
    public class UserDTO
    {
        public int? UserID { get; set; }
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public int NumberOfTasks { get; set; } = 0;
        public int TasksComplete { get; set; } = 0;
    }
}
