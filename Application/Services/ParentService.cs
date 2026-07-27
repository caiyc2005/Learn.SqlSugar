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
    [ApiDescriptionSettings(groups: ApiGroups.Main, Order = 3000, Tag = "家长信息管理")]
    public class ParentService : CrudAppService<Parent, ParentResponse, ParentPageListRequest,
    CreateOrUpdateParentRequest, Guid>, IDynamicApiController
    {
        public ParentService(IRepo<Parent, Guid> repository) : base(repository)
        {

        }
    }
}
