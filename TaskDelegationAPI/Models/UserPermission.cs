﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TaskDelegationAPI.Models;

public partial class UserPermission
{
    public int UserPermissionsID { get; set; }

    public int? UserID { get; set; }

    public int? PermissionID { get; set; }

    public virtual Permission Permission { get; set; }

    public virtual User User { get; set; }
}