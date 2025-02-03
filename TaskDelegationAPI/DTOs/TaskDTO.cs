namespace TaskDelegationAPI.DTOs
{
    public class TaskDTO
    {
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public string Status { get; set; } = "In Progress";
        public string Priority { get; set; } = "Medium";
        public string GivenTo { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; } = DateTime.Now;
        public DateTime? DateComplete {  get; set; }
        public bool Recurring { get; set; } = false;
    }
}
