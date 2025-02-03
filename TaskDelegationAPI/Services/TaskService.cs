using TaskDelegationAPI.Services.Interfaces;
using ef = TaskDelegationAPI.Models;

namespace TaskDelegationAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ef.TaskDelegationContext _context;
        private readonly IUserService _userService;

        public TaskService(ef.TaskDelegationContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

    }
}
