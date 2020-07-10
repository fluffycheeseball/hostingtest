using Moq;

using Serilog;

using Services;
using Services.Models.Responses;

using static Interfaces.Constants.Constants;

using Xunit;
using Interfaces.Models;

namespace Test {
    public class UserProfileServiceTests
    {

        private readonly Mock<ILogger> _loggerMock = new Mock<ILogger>();
        private readonly Mock<IProfileDataService> _dataServiceMock = new Mock<IProfileDataService>();
        private  UserProfileService _uut;


        private string OkEmail = "anyone@anywhere.com";
        private string OKAddtionalData = "{\"this\" :\"is OK json\" }";
        private string OkUserName = "username";

        public UserProfileServiceTests()
        {
            
        }

        [Fact]
        public void Add_Returns_BadRequest_for_null_userProfile() {
            _uut = new UserProfileService(_loggerMock.Object, _dataServiceMock.Object);
            UserProfileResponse expected = new UserProfileResponse(HttpBadRequest);

            var actual = _uut.Add(null).GetAwaiter().GetResult();

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData((string) null)]
        public void Add_Returns_BadRequest_for_bad_userName(string badUserName) {
            _uut = new UserProfileService(_loggerMock.Object, _dataServiceMock.Object);
            UserProfileResponse expected = new UserProfileResponse(HttpBadRequest);
            var badUserProfile = new UserProfile {
                UserName = badUserName,
                Email = OkEmail, 
                AdditionalData = OKAddtionalData
            };

            var actual = _uut.Add(badUserProfile).GetAwaiter().GetResult();

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData((string)null)]
        [InlineData("missingAt.Symbol")]
        [InlineData("missingFullStop")]
        public void Add_Returns_BadRequest_for_bad_email(string badEmail) {
            _uut = new UserProfileService(_loggerMock.Object, _dataServiceMock.Object);
            UserProfileResponse expected = new UserProfileResponse(HttpBadRequest);
            var badUserProfile = new UserProfile {
                UserName = OkUserName,
                Email = badEmail,
                AdditionalData = OKAddtionalData
            };

            var actual = _uut.Add(badUserProfile).GetAwaiter().GetResult();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("This is not json")]
        public void Add_Returns_BadRequest_for_bad_additionalData(string badAdditionalData) {
            _uut = new UserProfileService(_loggerMock.Object, _dataServiceMock.Object);
            UserProfileResponse expected = new UserProfileResponse(HttpBadRequest);
            var badUserProfile = new UserProfile {
                UserName = OkUserName,
                Email = OkEmail,
                AdditionalData = badAdditionalData
            };

            var actual = _uut.Add(badUserProfile).GetAwaiter().GetResult();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("{\"this\" :\"is OK json\" }")]
        [InlineData("    ")]
        [InlineData((string)null)]
        public void Add_Returns_Ok_for_good_additionalData(string okAdditionalData) {

            _uut = new UserProfileService(_loggerMock.Object, _dataServiceMock.Object);
            var expectedProfile = new UserProfile {
                UserName = OkUserName,
                Email = OkEmail,
                AdditionalData = okAdditionalData
            };

            _dataServiceMock.Setup(p => p.Add(It.IsAny<UserProfile>())).ReturnsAsync(expectedProfile);
            var expected = new UserProfileResponse(HttpOK, expectedProfile);

            var actual = _uut.Add(expectedProfile).GetAwaiter().GetResult();

            Assert.Equal(expected, actual);
        }

    }
}
