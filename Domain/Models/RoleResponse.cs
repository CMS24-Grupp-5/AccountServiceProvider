using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RoleResponse<T>:BaseResponseResult
    {
        public List<T> ?Roles { get; set; }
    }
}
