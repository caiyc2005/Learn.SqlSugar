using Application.Constracts.Dtos;
using Domain.Entitys;
using Domain.Shared.Consts;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Microsoft.AspNetCore.Mvc;
using SqlSugarCoreExtra.Furion.Component.Repositorys;
using SqlSugarCoreExtra.Furion.Component.ServiceExts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    [ApiDescriptionSettings(groups: ApiGroups.Main, Order = 10000, Tag = "学校信息管理")]
    public class SchoolService : CrudAppService<School, SchoolResponse, SchoolPageListRequest,
    CreateOrUpdateSchoolRequest, Guid>, IDynamicApiController
    {
        public SchoolService(IRepo<School, Guid> repository) : base(repository)
        {
            
        }


        public override async Task<SchoolResponse> CreateAsync(CreateOrUpdateSchoolRequest input)
        {
            var school = await _repository.Queryable(x => x.SchoolCode == input.SchoolCode)
                .FirstAsync();//这是执行语句
            if (school != null)
            {
                //throw Oops.Oh(404, "学校编号不允许重复");//"message": "[404] 系统异常，请联系管理员",s
                throw Oops.Bah("学校编号不允许重复！");
                // 如果理想状态是返回200状态码（或者是特定状态码），但是给出message的提示应该怎么做？
            }

            return await base.CreateAsync(input);
        }
    }
}
