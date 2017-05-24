/*******************************************************************************
 * Copyright © 2017 Zl 版权所有
 * Author: Zl
 * Description: Tz通用权限
*********************************************************************************/
using System;
using Tz.Data.Repository;
using Tz.Domain.Entity.SystemManage;
using Tz.Domain.IRepository.SystemManage;

namespace Tz.Repository.SystemManage
{
    public class ItemsRepository : RepositoryBase<ItemsEntity>, IItemsRepository
    {
    }
}
