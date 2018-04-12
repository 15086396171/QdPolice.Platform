using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Web.Mvc.Authorization;
using Vickn.Platform.Attendances.KqMachines;
using Vickn.Platform.Attendances.KqMachines.Authorization;
using Vickn.Platform.Attendences.KqMachines;
using Vickn.Platform.Attendences.KqMachines.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.KqMachines.Controllers
{
    public class KqMachineController : PlatformControllerBase
    {
        private readonly IKqMachineAppService _kqMachineAppService;


        public KqMachineController(IKqMachineAppService kqMachineAppService)
        {
            _kqMachineAppService = kqMachineAppService;
        }


        // GET: KqMachines/KqMachine
        [AbpMvcAuthorize(KqMachineAppPermissions.KqMachine)]
        public ActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(KqMachineAppPermissions.KqMachine_CreateKqMachine, KqMachineAppPermissions.KqMachine_EditKqMachine)]
        public async Task<ActionResult> Create(long? id)
        {
            var kqmachineDto = await _kqMachineAppService.GetForEditAsync(new NullableIdDto<long>(id));

            return View(kqmachineDto);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(KqMachineDto kqmachinedto)
        {
         
            await _kqMachineAppService.CreateOrUpdateAsync(kqmachinedto);
            return RedirectToAction("Index");
        }

       


    }
}