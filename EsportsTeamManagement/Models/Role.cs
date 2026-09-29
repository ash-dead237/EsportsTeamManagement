using System;
using System.Collections.Generic;

namespace EsportsTeamManagement.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;
    //above =null! is used to indicate that the property is non-nullable and will be 
    //initialized with a non-null value before it is accessed, even though it is not assigned a value in the constructor.

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
