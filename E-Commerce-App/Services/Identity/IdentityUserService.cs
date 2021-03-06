using System;
using System.Security.Claims;
using System.Threading.Tasks;
using E_Commerce_App.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace E_Commerce_App.Services.Identity
{
    public interface IUserService
    {
        Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState);
        Task<UserDto> Authenticate(LoginData data);
        Task<UserDto> GetUser(ClaimsPrincipal user);
        Task SetProfileImage(ClaimsPrincipal user, string url);
    }

    public class IdentityUserService : IUserService
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public IdentityUserService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<IdentityUserService> logger)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            Logger = logger;
        }

        public ILogger<IdentityUserService> Logger { get; }

        public async Task<UserDto> Authenticate(LoginData data)
        {
            var user = await userManager.FindByNameAsync(data.Username);

            if (await userManager.CheckPasswordAsync(user, data.Password))
            {
                await signInManager.SignInAsync(user, false);
                return await CreateUserDto(user);
            }

            Logger.LogInformation("Invalid login for username '{Username}'", data.Username);
            return null;
        }

        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            if (user == null) return null;

            return await CreateUserDto(user);
        }

        public async Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState)
        {
            var user = new IdentityUser
            {
                Email = data.Email,
                UserName = data.Username,
            };
            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                if (data.Email.EndsWith("@newbo.co"))
                    await userManager.AddToRoleAsync(user, "Administrator");

                if (data.MakeMeAnEditor)
                    await userManager.AddToRoleAsync(user, "Editor");

                await signInManager.SignInAsync(user, false);
                return await CreateUserDto(user);
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }

        public async Task SetProfileImage(ClaimsPrincipal principal, string url)
        {
            var user = await userManager.GetUserAsync(principal);

            // Could add this to ApplicationUser
            // user.ProfileUrl = url;
            // await userManager.UpdateAsync(user);

            var existingProfileUrls = principal.FindAll("ProfileUrl");
            await userManager.RemoveClaimsAsync(user, existingProfileUrls);

            await userManager.AddClaimAsync(user, new Claim("ProfileUrl", url));
            await signInManager.RefreshSignInAsync(user);
        }

        private async Task<UserDto> CreateUserDto(IdentityUser user)
        {
            return new UserDto
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.UserName,
            };
        }
    }
}
