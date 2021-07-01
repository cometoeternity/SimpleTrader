using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Tests.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTest
    {
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private Mock<IAccountService> _mockAccountService;
        private AuthenticationService _authenticationService;

        [SetUp]
        public void Setup()
        {

            _mockAccountService = new Mock<IAccountService>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _authenticationService = new AuthenticationService(_mockAccountService.Object, _mockPasswordHasher.Object);
        }



        [Test]
        public async Task Login_WithTheCorrectPasswordForExistingUser_ReturnAccountForCorrectUsername()
        {
            //Arrange
            string expectedUsername = "testUser";
            string password = "testPassword";

            _mockAccountService
                .Setup(s => s.GetByUsername(expectedUsername))
                .ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername } });

            

            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Success);

            

            //Act
            Account account = await _authenticationService.Login(expectedUsername, password);

            //Assert
            string actualUsername = account.AccountHolder.Username;
            Assert.AreEqual(actualUsername, expectedUsername);
        }

        [Test]
        public void Login_WithInCorrectPasswordForExistingUser_ThrowInvalidPasswordExceptionForUsername()
        {
            //Arrange
            string expectedUsername = "testUser";
            string password = "testPassword";

            _mockAccountService
                .Setup(s => s.GetByUsername(expectedUsername))
                .ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername } });

            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Failed);

            //Act
            InvalidPasswordException exception = Assert.ThrowsAsync<InvalidPasswordException>(() => _authenticationService.Login(expectedUsername, password));

            //Assert
            string actualUsername = exception.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public void Login_WithNonExistingUser_ThrowInvalidPasswordExceptionForUsername()
        {
            //Arrange
            string expectedUsername = "testUser";
            string password = "testPassword";

            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Failed);

            //Act
            UserNotFoundException exception = Assert.ThrowsAsync<UserNotFoundException>(() => _authenticationService.Login(expectedUsername, password));

            //Assert
            string actualUsername = exception.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }


        [Test]
        public async Task Register_WithPasswordsNotMatching_ReturnsPasswordsDoNotMatch()
        {
            //Arrange
            string password = "testpassword";
            string confirmPassword = "confirmtestpassword";
            RegistrationResult expected = RegistrationResult.PasswordDoNotMatch;

            RegistrationResult actual = await _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), password, confirmPassword);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithAlreadyExistingEmails_ReturnsEmailAlreadyExists()
        {
            //Arrange
            string email = "test@test.com";
            _mockAccountService.Setup(s => s.GetByEmail(email)).ReturnsAsync(new Account());

            RegistrationResult expected = RegistrationResult.EmailAlreadyExists;

            RegistrationResult actual = await _authenticationService.Register(email, It.IsAny<string>(), "tests", "tests");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithAlreadyExistingUsername_ReturnsUsernameAlreadyExists()
        {
            //Arrange
            string username = "testusername";
            _mockAccountService.Setup(s => s.GetByUsername(username)).ReturnsAsync(new Account());

            RegistrationResult expected = RegistrationResult.UsernameAlreadyExists;

            RegistrationResult actual = await _authenticationService.Register(It.IsAny<string>(), username, "tests", "tests");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithNonExistingUserAndMatchingPassword_ReturnsSuccess()
        {

            RegistrationResult expected = RegistrationResult.Success;

            RegistrationResult actual = await _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }
    }
}
