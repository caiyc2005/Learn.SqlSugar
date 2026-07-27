using Application.Constracts.Dtos;
using Core.Furion.Component.Contracts;
using Domain.Entitys;
using Domain.Shared.Consts;
using Furion.DynamicApiController;
using Furion.FriendlyException;
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
        private readonly IRepo<Class, Guid> _classRepo;//注入班级仓储
        //private readonly IRepo<Student, Guid> _studentRepo;//注入学生仓储

        public GradeService(IRepo<Grade, Guid> repository, IRepo<Class, Guid> class_repository) : base(repository)
        {
            _classRepo = class_repository;
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
                // 1、学校编号筛选
                .Includes(x => x.SchoolData)
                .WhereIF(!string.IsNullOrEmpty(input.SchoolCode),x => x.SchoolData.SchoolCode == input.SchoolCode)
                // 2、班级名称筛选
                .Includes(x => x.ClassList.WhereIF(!string.IsNullOrEmpty(input.ClassName), x => x.ClassName.Contains(input.ClassName)).ToList())
                .ToPageListAsync(input.PageIndex, input.PageSize, totalNumber);

            //IEnumerable<T> source, int pageIndex, int pageSize, int totalCount
            return new PageData<GradeResponse>(q.Adapt<List<GradeResponse>>(), input.PageIndex, input.PageSize, totalNumber);
        }

        /// <summary>
        /// 导出Exccel重写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override Task<IActionResult> ExportAsync(GradePageListRequest input)
        {
            return base.ExportAsync(input);
        }

        /// <summary>
        /// 获取特定年级下的班级列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<ClassResponse>> GetClassList(Guid id)
        {
            #region 方案一：导航关联查询
            //var grade = await Queryable()// 1、查出年级信息
            //    .Includes(x => x.ClassList) // 2、加载班级数据
            //    .FirstAsync(x => x.Id == id); // 3、执行查询
            //// 处理年级数据为空
            //if(grade == null)
            //{
            //    throw Oops.Bah($"年级{id}不存在");
            //}
            //// 处理年级下面没有班级数据的情况
            //if (grade.ClassList == null || !grade.ClassList.Any())
            //{
            //    return new List<ClassResponse>();
            //}
            //return grade.ClassList.Adapt<List<ClassResponse>>();
            #endregion

            #region 方案2：直接查询班级表
            //没有 await 时，Adapt 可能无法正确处理 Task，导致结果为空。
            //加上 await 后，ToListAsync() 真正执行了查询，拿到了数据，所以 Adapt 才能正确映射。
            var classlist = await _classRepo.Queryable()
                .Where(x => x.GradeID == id)
                .ToListAsync();

            //var result = classlist.Adapt<List<ClassResponse>>();
            //// 🔍 调试：先看原始数据
            //if (classlist != null && classlist.Any())
            //{
            //    Console.WriteLine($"原始数据条数: {classlist.Count}");
            //    Console.WriteLine($"第一个班级名称: {classlist.First().ClassName}");
            //}
            //Console.WriteLine($"映射后条数: {result?.Count ?? 0}");
            //return result;
            return classlist.Adapt<List<ClassResponse>>();
            #endregion
        }
    }
}
