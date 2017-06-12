using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Vickn.Platform.DataDictionaries;
using Vickn.Platform.DataDictionaries.Dtos;

namespace Vickn.Platform.Web.Controllers
{
    public class DataDictionaryItemsController : PlatformControllerBase
    {
        private IDataDictionaryItemAppService _dataDictionaryItemAppService;

        public DataDictionaryItemsController(IDataDictionaryItemAppService dataDictionaryItemAppService)
        {
            _dataDictionaryItemAppService = dataDictionaryItemAppService;
        }

        // GET: DataDictionaryItems
        public ActionResult Index(int dataDictionaryId)
        {
            ViewBag.dataDictionaryId = dataDictionaryId;
            return View();
        }

        public async Task<ActionResult> Create(int dataDictionaryId, int? id)
        {
            var result = await _dataDictionaryItemAppService.GetForEditAsync(new NullableIdDto(id));
            if (!result.DataDictionaryItemEditDto.Id.HasValue)
                result.DataDictionaryItemEditDto.DataDictionaryId = dataDictionaryId;
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DataDictionaryItemForEdit dto)
        {
            if (!base.CheckModelState(await _dataDictionaryItemAppService.CheckErrorAsync(dto)))
                return View(dto);

            await _dataDictionaryItemAppService.CreateOrUpdateAsync(dto);
            return RedirectToAction("Index", new { dataDictionaryId = dto.DataDictionaryItemEditDto.DataDictionaryId });
        }
    }
}