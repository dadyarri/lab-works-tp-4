using Microsoft.AspNetCore.Identity;

namespace lw7.Data;

public class RoleManager : RoleManager<IdentityRole>
{
    private readonly ILogger<RoleManager<IdentityRole>> _logger;

    public RoleManager(
        IRoleStore<IdentityRole> store,
        IEnumerable<IRoleValidator<IdentityRole>> roleValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        ILogger<RoleManager> logger)
        : base(store, roleValidators, keyNormalizer, errors, logger)
    {
        _logger = logger;
    }
}