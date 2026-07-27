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
using SqlSugarCoreExtra.Furion.Component.ServiceExts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Application.Services
{
    [ApiDescriptionSettings(groups: ApiGroups.Main, Order = 7000, Tag = "班级信息管理")]
    public class ClassService : CrudAppService<Class, ClassResponse, ClassPageListRequest,CreateOrUpdateClassRequest, Guid>, 
                                IDynamicApiController
    {
        
        private readonly IRepo<Student, Guid> _studentRepo;//注入学生仓储
        private readonly IRepo<Teacher, Guid> _teacherRepo;//注入教师仓储

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="studentRepo"></param>
        /// <param name="teacherRepo"></param>
        public ClassService(IRepo<Class, Guid> repository,
                            IRepo<Student, Guid> studentRepo,
                            IRepo<Teacher, Guid> teacherRepo) : base(repository)
        {
            _studentRepo = studentRepo;
            _teacherRepo = teacherRepo;
        }

        /// <summary>
        /// 班级列表查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override Task<List<ClassResponse>> ListAsync(ListInput input)
        {
            return base.ListAsync(input);
        }

        /// <summary>
        /// 班级数据详细查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<ClassResponse> GetAsync(Guid id)
        {
            var q = await Queryable(x => x.Id == id)
                .Includes(x => x.GradeData)
                .FirstAsync();
            return q.Adapt<ClassResponse>();
        }

        /// <summary>
        /// 重写分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<PageData<ClassResponse>> PageListAsync(ClassPageListRequest input)
        {
            RefAsync<int> totalNumber = 0;
           var q =await Queryable(input)
                .WhereIF(!string.IsNullOrEmpty(input.ClassName), x => x.ClassName.Contains(input.ClassName))
                .Includes(x => x.GradeData).ToPageListAsync(input.PageIndex, input.PageSize, totalNumber);

            //IEnumerable<T> source, int pageIndex, int pageSize, int totalCount
            return new PageData<ClassResponse>(q.Adapt<List<ClassResponse>>(), input.PageIndex, input.PageSize, totalNumber);
        }

        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<bool> DeleteSoftAsync(Guid id)
        {
            // 判断班级实体是否存在
            var classEntity = await _repository.GetByIdAsync(id);
            if (classEntity==null)
            {
                throw Oops.Bah("班级不存在!");
            }

            // 判断班级下是否还有学生？
            var students = await _studentRepo.QueryAsync(x => x.ClassId == id);
            if (students.Count > 0)
            {
                throw Oops.Bah("班级下仍存在学生，请先移除后再删除班级！");
            }

            //var result = await _repository.DeleteByIdAsync(id);
            //if (!result)
            //    throw Oops.Bah($"删除班级失败");
            //return true;
            return await base.DeleteSoftAsync(id);
        }

        /// <summary>
        /// 分配班级班主任信息
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="teacherid"></param>
        /// <returns></returns>
        [DisplayName("分配班主任")]
        public async Task<bool> SetClassManagerAsync(Guid classid,Guid teacherid)
        {
            var isclass = await _repository.QueryByIdAsync(classid);
            if (isclass == null)
            {
                throw Oops.Bah("班级不存在！");
            }
            var gradeid_class = isclass.GradeID;
            Console.WriteLine("gradeid_class" + gradeid_class);

            var isteacher = await _teacherRepo.QueryByIdAsync(teacherid);
            if(isteacher == null)
            {
                throw Oops.Bah("教师不存在，请重新选择！");
            }
            var gradeid_teacher = isteacher.GradeID;
            Console.WriteLine("gradeid_teacher" + gradeid_teacher);
            if (!gradeid_class.Equals(gradeid_teacher))
            {
                throw Oops.Bah("教师暂不属于该年级，请重新选择！");
            }

            var newclass = isclass;
            newclass.TeacherId = isteacher.Id;
            newclass.TeacherName = isteacher.TeacherName;
            return await _repository.UpdateAsync(newclass);
        }
    }
}
