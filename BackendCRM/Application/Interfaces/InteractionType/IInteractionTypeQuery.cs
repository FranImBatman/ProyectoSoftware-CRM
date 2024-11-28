using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InteractionType
{
    public interface IInteractionTypeQuery
    {
        Task<ICollection<InteractionTypes>> GetList();

        Task<bool> InteractionTypeExists(int id);
    }
}
