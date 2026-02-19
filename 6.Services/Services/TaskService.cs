using Data.Repositories;
using Data.Repository;
using Domain.Entities;
using Dtos;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Domain.Entities.Task;

namespace Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository clienteRepository)
        {
            _taskRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }



        public IEnumerable<TaskReadDto> ListTasks()
        {
            return _taskRepository.Query()
                .Include(t => t.User)
                .Select(t => new TaskReadDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    Status = t.Status,
                    UserId = t.UserId,
                    UserName = t.User.Username
                })
                .ToList();
        }

        public TaskReadDto GetTaskById(int id)
        {
            var task = _taskRepository.Query()
                .Include(t => t.User)
                .FirstOrDefault(t => t.Id == id);

            if (task == null)
                throw new KeyNotFoundException("Task not found");

            return new TaskReadDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Status = task.Status,
                UserId = task.UserId,
                UserName = task.User?.Username
            };
        }

        public void CreateTask(TaskCreateDto dto)
        {
            var task = new Task
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Status = "Pending",
                UserId = dto.UserId
            };

            _taskRepository.Add(task);
            _taskRepository.SaveChanges();
        }

        public void UpdateTask(int id, TaskUpdateDto dto)
        {
            var task =_taskRepository.Query()
                       .FirstOrDefault(t => t.Id == id);

            if (task == null)
                throw new KeyNotFoundException("Task not found");

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.DueDate = dto.DueDate;
            task.Status = dto.Status;

            _taskRepository.SaveChanges();
        }

    }
}
