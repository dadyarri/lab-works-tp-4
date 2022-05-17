using Microsoft.AspNetCore.Identity;

namespace lw6.Controllers;

public class GameRoleManager : RoleManager<IdentityRole>
{
    private readonly ILogger<RoleManager<IdentityRole>> _logger;

    public GameRoleManager(
        IRoleStore<IdentityRole> store,
        IEnumerable<IRoleValidator<IdentityRole>> roleValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        ILogger<GameRoleManager> logger)
        : base(store, roleValidators, keyNormalizer, errors, logger)
    {
        _logger = logger;
    }
}