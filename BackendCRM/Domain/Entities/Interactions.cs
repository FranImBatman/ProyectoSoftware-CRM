
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Interactions
    {
        public Guid InteractionID { get; set; }

        public Guid ProjectID { get; set; }

        public int InteractionType { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public virtual Projects ProjectNavigator { get; set; }

        public virtual InteractionTypes InteractionTypesNavigator { get; set; }
    }
}
