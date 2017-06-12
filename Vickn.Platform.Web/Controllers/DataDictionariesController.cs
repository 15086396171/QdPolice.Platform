using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Vickn.Platform.DataDictionaries;
using Vickn.Platform.DataDictionaries.Authorization;
using Vickn.Platform.DataDictionaries.Dtos;

namespace Vickn.Platform.Web.Controllers
{
    [AbpMvcAuthorize(DataDictionaryAppPermissions.DataDictionary)]
    public class DataDictionariesController : PlatformControllerBase
    {
        private readonly IDataDictionaryAppService _dataDictionaryAppService;

        public DataDictionariesController(IDataDictionaryAppService dataDictionaryAppService)
        {
            _dataDictionaryAppService = dataDictionaryAppService;
        }

        // GET: DataDictionaries
        public ActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(DataDictionaryAppPermissions.DataDictionary_CreateDataDictionary)]
        public async Task<ActionResult> Create(int? id)
        {
            return View(await _dataDictionaryAppService.GetForEditAsync(new NullableIdDto(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Create(DataDictionaryForEdit dto)
        {
            if (!CheckModelState(await _dataDictionaryAppService.CheckErrorAsync(dto)))
                return View(dto);

            await _dataDictionaryAppService.CreateOrUpdateAsync(dto);
            return RedirectToAction("Index");
        }
    }
}