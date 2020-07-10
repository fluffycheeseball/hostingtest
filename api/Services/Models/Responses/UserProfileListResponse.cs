using System.Collections.Generic;
using Interfaces.Models;

namespace Services.Models.Responses {

    // This could be generic but using nullable reference types with generics throws up warnings.
    // If this gets fixed in future then use generics
    public class UserProfileListResponse {
        public int HttpCode { get; set; }

        public List<UserProfile>? UserProfiles { get; set; }

        public UserProfileListResponse() {
        }

        public UserProfileListResponse(int httpCode) {
            HttpCode = httpCode;
        }
    }
}
