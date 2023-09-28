using System;

namespace WebApi.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
