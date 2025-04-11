﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BusinessLogic.DataTransferObjects
{
    public class CreatedDepartmentDto
    {
        [Required(ErrorMessage = "Name is required !!!!!!!")]
        public string Name { get; set; } = null!;
        [Required]
        [Range(100,int.MaxValue)]
        public string Code { get; set; } = null!;
        public DateOnly DateOfCreation { get; set; }
        public string? Description { get; set; }
    }
}
