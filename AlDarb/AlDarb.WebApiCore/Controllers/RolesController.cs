/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using AlDarb.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("users/{id:int}/roles")]
    [Authorize(Policy = "AdminOnly")]
    public class RolesController : BaseApiController
    {
        protected readonly IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Assign(int id, RoleDTO role)
        {
            var result = await roleService.AssignToRole(id, role.Name);
            if (result.Succeeded)
                return Ok();

            return BadRequest(new { message = result.Errors.FirstOrDefault()?.Description });
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> Unassign(int id, RoleDTO role)
        {
            var result = await roleService.UnassignRole(id, role.Name);
            if (result.Succeeded)
                return Ok();

            return BadRequest(new { message = result.Errors.FirstOrDefault()?.Description });
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRoles(int id)
        {
            var result = await roleService.GetRoles(id);
            return Ok(result);
        }
    }
}