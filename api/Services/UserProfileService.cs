using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using Interfaces.ExtensionMethods;
using Interfaces.Models;
using Microsoft.AspNetCore.JsonPatch;
using Serilog;
using Services.Models;
using Services.Models.Responses;
using static Interfaces.Constants.Constants;

namespace Services {
    public interface IProfileService {

        Task<UserProfileListResponse> Get();

        Task<UserProfileResponse> Add(UserProfile? userProfile);

        Task<UserProfileResponse> GetById(int? id);

        Task<UserProfileResponse> DeleteById(int? id);

        Task<UserProfileResponse> Update(int? id, JsonPatchDocument<UserProfile>? userProfilePatch);
    }

    public class UserProfileService : IProfileService {
        private readonly ILogger _logger;
        private readonly IProfileDataService _profileDataService;

        public UserProfileService(ILogger logger, IProfileDataService profileDataService) {
            _logger = logger;
            _profileDataService = profileDataService;
        }

        public async Task<UserProfileListResponse> Get() {
            try {
                var userProfiles = await _profileDataService.Get();
                return new UserProfileListResponse {
                    UserProfiles = userProfiles,
                    HttpCode = HttpOK
                };
            } catch (Exception e) {
                _logger.Error(e, "Failed to get user profiles");
                return new UserProfileListResponse(HttpInternalServerError);
            }
        }

        public async Task<UserProfileResponse> GetById(int? id) {
            if (id.IsNotPositiveInt()) {
                _logger.Warning("null " + nameof(id));
                return new UserProfileResponse(HttpBadRequest);
            }

            try {
                Debug.Assert(id != null, nameof(id) + " != null");
                var user = await _profileDataService.GetById(id.Value);
                return new UserProfileResponse(HttpOK, user);
            } catch (Exception e) {
                _logger.Error(e, "Failed to get userProfile for id:{Id}", id);
                return new UserProfileResponse(HttpInternalServerError);
            }
        }

        public async Task<UserProfileResponse> DeleteById(int? id) {
            if (id.IsNotPositiveInt()) {
                _logger.Warning("null " + nameof(id));
                return new UserProfileResponse(HttpBadRequest);
            }

            try {
                Debug.Assert(id != null, nameof(id) + " != null");
                var result = await _profileDataService.DeleteById(id.Value);
                return new UserProfileResponse(result);
            } catch (Exception e) {
                _logger.Error(e, "Failed to delete userProfile for id:{Id}", id);
                return new UserProfileResponse(HttpInternalServerError);
            }
        }

        public async Task<UserProfileResponse> Update(int? id, JsonPatchDocument<UserProfile>? userProfilePatch) {
            if (!id.HasValue) {
                _logger.Warning("null " + nameof(id));
                return new UserProfileResponse(HttpBadRequest, null);
            }

            if (IsBadUserProfilePatch(userProfilePatch)) return new UserProfileResponse(HttpBadRequest);
            ;

            var updateResult = await _profileDataService.Update(id.Value, userProfilePatch);
           
            if (updateResult != HttpOK) return new UserProfileResponse(updateResult);

            //round trip get should be in new transaction
            var roundTrippedUserProfile = await _profileDataService.GetById(id.Value);
            return roundTrippedUserProfile is null ? new UserProfileResponse(HttpInternalServerError) : new UserProfileResponse(HttpOK, roundTrippedUserProfile);
        }

        private bool IsBadUserProfilePatch(JsonPatchDocument<UserProfile>? userProfilePatch) {
            if (userProfilePatch == null) {
                _logger.Warning("null " + nameof(userProfilePatch));
                return true;
            }

            if (userProfilePatch.Operations?.Count == 0) {
                _logger.Warning("invalid " + nameof(userProfilePatch) + ": {UserProfilePatch}", userProfilePatch);
                return true;
            }

            return false;
        }

        public async Task<UserProfileResponse> Add(UserProfile? userProfile)
        {
            TrimWhitespaceInUserProfile(userProfile);
            if (IsBadProfile(userProfile)) return new UserProfileResponse(HttpBadRequest);
            try {
                userProfile = await _profileDataService.Add(userProfile);
                if (userProfile == null) return new UserProfileResponse(HttpInternalServerError);
                return new UserProfileResponse(HttpOK, userProfile);
   } catch (Exception e) {
                _logger.Error(e, "Failed to add userProfile: {UserProfile}", userProfile);
                return new UserProfileResponse(HttpInternalServerError);
            }
        }

        private void TrimWhitespaceInUserProfile(UserProfile? userProfile)
        {
            if (userProfile == null)
            {
                return;
            }
            userProfile.UserName = userProfile.UserName.Trim();
            userProfile.Email = userProfile.Email.Trim();
            userProfile.AdditionalData = userProfile.AdditionalData.Trim();
        }

        private bool IsBadProfile(UserProfile? userProfile) {
            if (userProfile == null) {
                _logger.Warning(nameof(UserProfile) + " is null");
                return true;
            }

            if (userProfile.Email.IsEmpty()) {
                _logger.Warning("Empty " + nameof(userProfile.Email));
                return true;
            }
            if (userProfile.Email.IsNotEmailFormat()) {
                _logger.Warning("Bad " + nameof(userProfile.Email));
                return true;
            }
            if (userProfile.UserName.IsEmpty()) {
                _logger.Warning("Empty " + nameof(userProfile.UserName));
                return true;
            }
            if (userProfile.AdditionalData.IsNotEmpty() && userProfile.AdditionalData.IsNotValidJson())
            {
               return true;
            }
            return false;
        }
    }
}
