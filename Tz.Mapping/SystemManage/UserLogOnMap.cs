/*******************************************************************************
 * Copyright © 2017 Zl 版权所有
 * Author: Zl
 * Description: Tz通用权限
*********************************************************************************/
using System;
using System.Data.Entity.ModelConfiguration;
using Tz.Domain.Entity.SystemManage;

namespace Tz.Mapping.SystemManage
{
    public class UserLogOnMap : EntityTypeConfiguration<UserLogOnEntity>
    {
        public UserLogOnMap()
        {
            this.ToTable("Sys_UserLogOn");
            this.HasKey(t => t.F_Id);
        }
    }
}
