using System;
using System.Collections.Generic;

namespace BlazorServer.Models;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string Name { get; set; } = null!;

    public int IdDepartment { get; set; }

    public int Salary { get; set; }

    public DateTime ContractDate { get; set; }

    public virtual Department Department { get; set; } = null!;
}
