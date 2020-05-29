
namespace RestAPI_Project.Contract
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        
        public const string Version = "v1";
        
        public const string Base = Root + "/" + Version;

        public static class Posts
        {
            public const string GetAll = Base +  "/posts";

            public const string Get = Base + "/post/{postId}";

            public const string Create = Base + "/create";

            public const string Update = Base + "/update/{postId}";

            public const string Delete = Base + "/delete/{postId}";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
        }
    }
}
