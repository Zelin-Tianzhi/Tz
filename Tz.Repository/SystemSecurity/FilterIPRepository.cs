/*******************************************************************************
 * Copyright © 2017 Zl 版权所有
 * Author: Zl
 * Description: Tz通用权限
*********************************************************************************/
using System;
using Tz.Data.Repository;
using Tz.Domain.Entity.SystemSecurity;
using Tz.Domain.IRepository.SystemSecurity;

namespace Tz.Repository.SystemSecurity
{
    public class FilterIPRepository : RepositoryBase<FilterIPEntity>, IFilterIPRepository
    {
    }
}
