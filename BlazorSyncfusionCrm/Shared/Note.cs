﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSyncfusionCrm.Shared
{
    public class Note : ISoftDelete
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public int? ContactId { get; set; }
        public Contact? Contact { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
