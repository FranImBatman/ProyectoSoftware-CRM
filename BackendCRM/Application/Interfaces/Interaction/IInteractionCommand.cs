﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Interaction
{
    public interface IInteractionCommand
    {
        Task InsertInteraction(Interactions interaction);


    }
}