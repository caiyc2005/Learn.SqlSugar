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
    [ApiDescriptionSettings(groups: ApiGroups.Main, Order = 4000, Tag = "学生信息管理")]
    public class StudentService : CrudAppService<Student, StudentResponse, StudentPageListRequest,
    CreateOrUpdateStudentRequest, Guid>, IDynamicApiController
    {
        public StudentService(IRepo<Student, Guid> repository) : base(repository)
        {

        }

        /// <summary>
        /// 查询学生具体信息。（包含班级、家长）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<StudentResponse> GetAsync(Guid id)
        {
            var student = await Queryable()
                .Includes(x => x.ParentList)
                .Includes(x => x.ClassData)
                .FirstAsync();
            return student.Adapt<StudentResponse>();
        }
    }
}
