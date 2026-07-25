using Application.Constracts.Dtos;
using Core.Furion.Component.Contracts;
using Domain.Entitys;
using Domain.Shared.Consts;
using Furion.DynamicApiController;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using SqlSugarCoreExtra.Furion.Component.Repositorys;
using SqlSugarCoreExtra.Furion.Component.ServiceExts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    [ApiDescriptionSettings(groups: ApiGroups.Main, Order = 9000, Tag = "年级信息管理")]
    public class GradeService : CrudAppService<Grade, GradeResponse, GradePageListRequest,
    CreateOrUpdateGradeRequest, Guid>, IDynamicApiController
    {
        public GradeService(IRepo<Grade, Guid> repository) : base(repository)
        {

        }

        /// <summary>
        /// 年级信息分页，可查所在学校具体信息。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<PageData<GradeResponse>> PageListAsync(GradePageListRequest input)
        {
            RefAsync<int> totalNumber = 0;
            var q = await Queryable(input)
                .Includes(x => x.SchoolData)
                //
                //.Includes(x => x.ClassList.WhereIF(!string.IsNullOrEmpty(input.ClassName), x => x.ClassName.Contains(input.ClassName)).ToList())//筛选字段
                 .ToPageListAsync(input.PageIndex, input.PageSize, totalNumber);

            //IEnumerable<T> source, int pageIndex, int pageSize, int totalCount
            return new PageData<GradeResponse>(q.Adapt<List<GradeResponse>>(), input.PageIndex, input.PageSize, totalNumber);
        }
    }
}
