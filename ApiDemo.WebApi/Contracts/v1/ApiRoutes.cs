using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.WebApi.Contracts.v1
{
    public static class ApiRoutes
    {
        public const string root = "api";
        public const string version = "v1";
        public const string Base = root + "/" + version;

        public static class Cliente {
            public const string RestBase = Base + "/Cliente";
        }

        public static class Usuario {
            public const string Login = Base + "/Usuario/Login";
        }
    }
}
