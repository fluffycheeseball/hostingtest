using System;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Moq;
using Serilog;
using Services;
using Services.Models.Responses;
using Xunit;


using static Interfaces.Constants.Constants;

namespace Test {
    public class UserProfileServiceTests
    {

    //    private readonly Mock<ILogger> _loggerMock = new Mock<ILogger>();
   //     private readonly Mock<IProfileDataService> _dataServiceMock = new Mock<IProfileDataService>();
   //     private  UserProfileService _uut;

        public UserProfileServiceTests()
        {
            
        }

        //[Fact]
        //public void Add_Returns_BadRequest_for_null_userProfile()
        //{
        //    _uut = new UserProfileService(_loggerMock.Object, _dataServiceMock.Object);
        //    UserProfileResponse expected = new UserProfileResponse(HttpBadRequest);
            
        //    var actual = _uut.Add(null).GetAwaiter().GetResult();
        //    Assert.Equal(expected, actual);
        //}

        [Fact]
        public void Test()
        {
            Assert.Equal(1, 1);
        }
    }
}
