
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ITaskService
    {
        IEnumerable<TaskReadDto> ListTasks();
        TaskReadDto GetTaskById(int id);

        void CreateTask(TaskCreateDto dto);
        void UpdateTask(int id, TaskUpdateDto dto);
           
       
    }
}
