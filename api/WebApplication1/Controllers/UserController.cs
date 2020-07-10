using System.Collections.Generic;
using System.Threading.Tasks;

using Interfaces.Models;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using Services;

namespace WebApplication1.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IProfileService _profileService;

        public UserController(IProfileService profileService) {
            _profileService = profileService;
            }

        [HttpGet("")]
        public async Task<ActionResult<List<UserProfile>>> Get() {
            var response = await _profileService.Get();
            return StatusCode(response.HttpCode, response.UserProfiles);
            }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfile>> GetById(int? id) {
            var userResponse = await _profileService.GetById(id);
            return StatusCode(userResponse.HttpCode, userResponse.UserProfile);
            }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int? id) {
            var userResponse = await _profileService.DeleteById(id);
            return StatusCode(userResponse.HttpCode, userResponse.UserProfile);
            }

        [HttpPost("")]
        public async Task<ActionResult<UserProfile?>> Add(UserProfile? userProfile) {
            var userResponse = await _profileService.Add(userProfile);
            return StatusCode(userResponse.HttpCode, userResponse.UserProfile);
            }

        [HttpPatch("{id}")]
        public async Task<ActionResult<UserProfile?>> Patch(int? id, [FromBody]JsonPatchDocument<UserProfile> userProfilePatch) {
            var userResponse = await _profileService.Update(id, userProfilePatch);
            return StatusCode(userResponse.HttpCode, userResponse.UserProfile);
            }
        }
    }
