﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.Entities
{
    public class Field : DeletableEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}