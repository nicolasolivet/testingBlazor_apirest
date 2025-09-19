using System;
using System.Collections.Generic;

namespace BlazorServer.Models;

public partial class Department
{
    public int IdDepartment { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();


//Ambas líneas de código en C# declaran una propiedad llamada Name de tipo string. Sin embargo, la diferencia sintáctica radica en cómo manejan la nulabilidad (nullability) del valor de esa propiedad, lo cual es parte de la característica de tipos de referencia que aceptan valores nulos (nullable reference types), introducida en C# 8.

//La primera línea, public string Name { get; set; } = null!;, utiliza el operador de anulación nula (!). Este operador le dice al compilador de C# que "ignore" cualquier advertencia de que la propiedad podría ser nula. En otras palabras, estás asumiendo la responsabilidad de asegurar que la propiedad Name nunca será nula en tiempo de ejecución. Esto se usa a menudo cuando sabes que el valor se inicializará más tarde, pero no puedes hacerlo en la misma línea de declaración.

//La segunda línea, public string? Name { get; set; }, utiliza el sufijo de nulabilidad (?). Este sufijo indica explícitamente que la propiedad Name puede ser nula. Esto le permite al compilador emitir advertencias si intentas acceder a la propiedad sin verificar primero si es nula, lo que ayuda a prevenir errores de NullReferenceException en tiempo de compilación. Este es el enfoque preferido y más seguro cuando una propiedad de tipo string puede, de hecho, tener un valor nulo.
}
