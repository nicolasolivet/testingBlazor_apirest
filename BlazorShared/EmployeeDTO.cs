using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BlazorShared
{
    public class EmployeeDTO
    {
        public int IdEmployee  { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int IdDepartment { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The field {0} is required")]
        public int Salary { get; set; }

        public DateTime ContractDate { get; set; }

        public DepartmentDTO? Department { get; set; }
    }
}
