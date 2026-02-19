using Data;
using Data.Repositories;
using Data.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task = Domain.Entities.Task;

namespace JobBoard.Data.Repositories
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        private readonly TasksContext _context;

        public TaskRepository(TasksContext context) : base(context)
        {
            _context = context;
        }


    }
}
