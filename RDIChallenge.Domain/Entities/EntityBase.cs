using System;
using System.Collections.Generic;
using System.Text;

namespace RDIChallenge.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; protected set; }
        public bool IsNew => Id == 0;
    }
}
