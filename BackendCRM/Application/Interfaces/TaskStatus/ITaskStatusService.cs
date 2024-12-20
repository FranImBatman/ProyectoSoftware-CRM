﻿using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.TaskStatus
{
    public interface ITaskStatusService
    {
        Task<ICollection<GenericResponse>> GetAll();

        Task TaskStatusExists(int Id);
    }
}
