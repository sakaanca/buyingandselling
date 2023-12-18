﻿using Project.ENTITIES.Enums;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public abstract class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public  int ID { get; set; }
        public  DateTime CreatedDate { get; set; }
        public  DateTime? ModifiedDate { get; set; }
        public  DateTime? DeletedDate { get; set; }
        public  DataStatus Status { get; set; }
    }
}
