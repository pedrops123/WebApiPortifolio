using System;

namespace Portifolio.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public int UserInsert { get; protected set; }
        public DateTime InsertDate { get; protected set; }
        public int? UserUpdate { get; protected set; }
        public DateTime? UdpatetDate { get; protected set; }
    }
}