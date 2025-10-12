namespace AHIOTAM_Api.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "AHIOTAM..010203040506070809ASPNETCORE8RESTURANTWEBSITE?_!%&/('";
        public const int Expire = 60; /*60 minutes*/
    }
}
