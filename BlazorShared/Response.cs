using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        //propiedad del obejto que recibimos, devolvemos ya sea la lista de empleados o departamentos o ids
        public T? Value{ get; set; }
        public string? Message { get; set; }
    }
}
 