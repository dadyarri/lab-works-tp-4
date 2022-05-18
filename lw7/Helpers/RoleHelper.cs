using Microsoft.AspNetCore.Identity;

namespace lw7.Helpers;

public class RoleHelper
{
    private static async Task EnsureRoleCreated(RoleManager<IdentityRole> roleManager, string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
    public static async Task EnsureRolesCreated(RoleManager<IdentityRole> roleManager)
    {
        // add all roles, that should be in database, here
        await EnsureRoleCreated(roleManager, "Administrator");
    }
}