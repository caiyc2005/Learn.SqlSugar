using Application.Constracts.Dtos;
using Domain.Entitys;
using Domain.Shared.Consts;
using Furion.DynamicApiController;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SqlSugarCoreExtra.Furion.Component.Repositorys;
using SqlSugarCoreExtra.Furion.Component.ServiceExts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    [ApiDescriptionSettings(groups: ApiGroups.Main, Order = 5000, Tag = "教师信息管理")]
    public class TeacherService : CrudAppService<Teacher, TeacherResponse, TeacherPageListRequest,
    CreateOrUpdateTeacherRequest, Guid>, IDynamicApiController
    {
        public TeacherService(IRepo<Teacher, Guid> repository) : base(repository)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<TeacherResponse> GetAsync(Guid id)
        {
            var tea = await Queryable().Includes(x => x.GradeData).FirstAsync();
            return tea.Adapt<TeacherResponse>();
        }
    }
}
