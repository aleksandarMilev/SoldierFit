namespace System.Security.Claims
{
    /// <summary>
    /// Extension methods for <see cref="ClaimsPrincipal"/> to simplify access to claim values.
    /// </summary>
    public static class ClaimsPrincipleExtension
    {
        /// <summary>
        /// Gets the user identifier (ID) from the claims principal.
        /// </summary>
        /// <param name="user">The claims principal.</param>
        /// <returns>The user ID as a string.</returns>
        public static string GetId(this ClaimsPrincipal user) 
            => user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
