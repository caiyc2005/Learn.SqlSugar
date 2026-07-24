//using Application.Constracts.Dtos;
//using Domain.Entitys;
//using Domain.Shared.Consts;
//using Furion.DynamicApiController;
//using Microsoft.AspNetCore.Mvc;
//using SqlSugarCoreExtra.Furion.Component.Repositorys;
//using SqlSugarCoreExtra.Furion.Component.ServiceExts;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Application.Services
//{
//    [ApiDescriptionSettings(groups: ApiGroups.Main, Order = 8500, Tag = "年级信息管理")]
//    public class GradeService : CrudAppService<Grade, GradeResponse, GradePageListRequest,
//    CreateOrUpdateGradeRequest, Guid>, IDynamicApiController
//    {
//        public GradeService(IRepo<Grade, Guid> repository) : base(repository)
//        {

//        }
//    }
//}
