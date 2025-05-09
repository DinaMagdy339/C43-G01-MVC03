﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BusinessLogic.DataTransferObjects
{
    public class UpdatedDepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty ;
        public string Code { get; set; } = null!;
        public DateOnly DateOfCreation { get; set; }
        public string? Description { get; set; }
    }
}
