﻿using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InteractionType
{
    public interface IInteractionTypeService
    {
        Task<ICollection<GenericResponse>> GetAll();

        Task InteractionTypeExists(int id);
    }

}
