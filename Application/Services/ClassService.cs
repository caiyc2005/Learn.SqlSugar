using Application.Constracts.Dtos;
using Domain.Entitys;
using Domain.Shared.Consts;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using SqlSugarCoreExtra.Furion.Component.Repositorys;
using SqlSugarCoreExtra.Furion.Component.ServiceExts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    [ApiDescriptionSettings(groups: ApiGroups.Main, Order = 7000, Tag = "班级信息管理")]
    public class ClassService : CrudAppService<Class, ClassResponse, ClassPageListRequest,
    CreateOrUpdateClassRequest, Guid>, IDynamicApiController
    {
        public ClassService(IRepo<Class, Guid> repository) : base(repository)
        {

        }
    }
}
