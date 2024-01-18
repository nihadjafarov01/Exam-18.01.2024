using Exam4.Business.Repositories.Services.Interfaces;
using Exam4.Business.ViewModels.AuthVMs;
using Exam4.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Exam4.Business.Repositories.Services.Implements
{
    public class AuthService : IAuthService
    {
        UserManager<IdentityUser> _userManager {  get; }
        SignInManager<IdentityUser> _signInManager {  get; }
        RoleManager<IdentityRole> _roleManager {  get; }

        public AuthService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Register(RegisterVM vm)
        {
            IdentityUser user;
            user = new IdentityUser
            {
                Email = vm.Email,
                UserName = vm.Username
            };
            if(user == null )
            {
                return false;
            }
            var result = await _userManager.CreateAsync(user,vm.Password);
            if(!result.Succeeded)
            {
                return false;
            }
            await _userManager.AddToRoleAsync(user, Roles.Member.ToString());
            return true;
        }

        public async Task<bool> Login(LoginVM vm)
        {
            IdentityUser user;
            if (vm.UsernameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);    
            }
            else
            {
                user = await _userManager.FindByNameAsync(vm.UsernameOrEmail);
            }
            if (user == null)
            {
                return false;
            }
            var result = await _signInManager.PasswordSignInAsync(user,vm.Password,vm.RememberMe,false);
            if(!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CreateRoles()
        {
            foreach (string item in Enum.GetNames(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(item))
                {
                    await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = item,
                    });
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> CreateInit()
        {
            foreach (string item in Enum.GetNames(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(item))
                {
                    await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = item,
                    });
                }
                else
                {
                    return false;
                }
            }
            IdentityUser user;
            user = await _userManager.FindByNameAsync("admin");
            if (user == null)
            {
                user = new IdentityUser
                {
                    Email = "admin@gmail.com",
                    UserName = "admin123"
                };
                var result = await _userManager.CreateAsync(user, "Admin123");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                return false;
            }
            return true;
        }

    }
}
