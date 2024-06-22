namespace System.Security.Claims
{
    public static class ClaimsPrincipleExtension
    {
        public static string GetId(this ClaimsPrincipal user) 
            => user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
