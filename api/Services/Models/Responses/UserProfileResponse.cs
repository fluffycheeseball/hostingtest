using System;
using Interfaces.Models;

namespace Services.Models.Responses {

    public class UserProfileResponse : IEquatable<UserProfileResponse>
    {
        public int HttpCode { get; }

        public UserProfile? UserProfile { get; }

        public UserProfileResponse(int httpCode, UserProfile? userProfile = null)
        {
            HttpCode = httpCode;
            UserProfile = userProfile;
        }

        public bool Equals(UserProfileResponse? input)
        {
            return input != null
                   && HttpCode == input.HttpCode
                   && (
                       (UserProfile is null && input.UserProfile is null)
                       || (UserProfile != null
                           && input.UserProfile != null
                           && UserProfile.UserName == input.UserProfile.UserName
                           && UserProfile.Email == input.UserProfile.Email
                           && UserProfile.AdditionalData == input.UserProfile.AdditionalData)
                   );
        }

        public override int GetHashCode() {
        var hash = 19;
        unchecked { // allow "wrap around" in the int
            hash = hash * 31 + HttpCode; 
            hash = hash * 31 + (UserProfile == null? 0: UserProfile.Email.GetHashCode());
            hash = hash * 31 + (UserProfile == null ? 0 : UserProfile.UserName.GetHashCode());
            hash = hash * 31 + (UserProfile == null ? 0 : UserProfile.AdditionalData.GetHashCode());
        }
        return hash;
        }
    }
}
