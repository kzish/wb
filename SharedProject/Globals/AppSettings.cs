using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Microsoft.Extensions.Configuration;
using Nest;
using SharedModels;

namespace Globals
{
    public class AppSettings
    {
        public static string moodle_ws_token;
        public static string resources_folder;
        public static string profile_pictures_folder;
        public static string moodle_api_endpoint;
        public static string connection_string;
        public static string logs;
        public static string api_endpoint;
        public static string es_endpoint;
        public static ElasticClient EsClient;
        public static dbContext db;
    }
}
