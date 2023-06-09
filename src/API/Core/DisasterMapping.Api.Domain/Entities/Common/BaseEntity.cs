﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Domain.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public BaseEntity()
        {

        }

        public BaseEntity(int id):this()
        {
            Id = id;
        }
    }
}
