using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specflowdemo.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private string? _email;
        private string? _password;

        [Given("an anonymous user has login credentials to an existing Todoist account")]
        public void GivenAnonymousUserHasLoginCredentials()
        {
            _email = ConfigHelper.GetSecret("Todoist", "Email");
            _password = ConfigHelper.GetSecret("Todoist", "Password");
        }

        [When("the anonymous user sends a login request")]
        public void WhenUserSendsLoginRequest()
        {
            // Implement the HTTP POST login call
        }

        [Then("the anonymous user will receive a 200 response code")]
        public void ThenUserReceivesSuccessResponse()
        {
            // Implement assertion for status 200
        }
    }
}
