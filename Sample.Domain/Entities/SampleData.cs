using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.Domain.Entities
{
    public class SampleData
    {
        [Key]
        public Guid Key { get; set; }

        public string Message { get; set; }
    }
}
