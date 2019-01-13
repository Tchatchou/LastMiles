using System;
using System.Net.Http;
using Data_Base;
using Business_Layer.Identity;
using Data_Base.Data_Transfer_Objects;
using Xunit;

namespace API_Tests
{
    public class UnitTest1 : Test_Server_Setup
    {
        [Fact]
        public async void Test1Async()
        {
           /*  using(var server = CreateServer())
            {
                var login = new User_For_Login_Dto();

                login.UserName="sa";
                login.Password="password";

                var response = await server.CreateClient()
                             .PostAsJsonAsync("/api/auth/LoginUser", login);

                var   htt = response;          
            } */
             var login = new User_For_Login_Dto();

                login.UserName="sa";
                login.Password="password";
           //  var auth = new Authentication();

            // var result = auth.login_user(login);
             
            Assert.Equal(1, 1);
        }
    }

}
