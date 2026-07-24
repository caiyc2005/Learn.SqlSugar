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
    [ApiDescriptionSettings(groups: ApiGroups.Main, Order = 9000, Tag = "学校信息管理")]
    public class SchoolService : CrudAppService<School, SchoolResponse, SchoolPageListRequest,
    CreateOrUpdateSchoolRequest, Guid>, IDynamicApiController
    {
        public SchoolService(IRepo<School, Guid> repository) : base(repository)
        {

        }
    }
}
