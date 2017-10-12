using System.Linq;
using Newtonsoft.Json;

namespace RDJTP
{
    public static class API
    {
        private static Model model;

        public static void createAPI()
        {
            model = new Model();
        }

        public static void create(Server.Request request, ref Server.Response response)
        {
            var pathExists = pathStatus(request, response);
            if (model.getPath(request.Path) != null)
            {
                response.Status = "4 Bad Request";
                pathExists = false;
            }
            else
            {
                pathExists = bodyStatus(request, response);
            }
            if (!pathExists) return;

            var myBody = model.Create(request.Path, JsonConvert.DeserializeObject<Category>(request.Body).Name);
            response.Body = JsonConvert.SerializeObject(myBody);
        }


        public static void read(Server.Request request, ref Server.Response response)
        {
            if (request.Path == "/api/categories")
            {
                response.Status = "1 Ok";
                response.Body = JsonConvert.SerializeObject(model.ReadAll());
            }
            else
            {
                var pathExists = pathStatus(request, response) || !pathIdExists(request, response);
                if (!API.pathExists(request, response)) pathExists = false;
                if (!pathExists) return;

                response.Status = "1 Ok";
                response.Body = JsonConvert.SerializeObject(model.getPath(request.Path));
            }
        }

        public static void update(Server.Request request, ref Server.Response response)
        {
            var pathExists = pathStatus(request, response);
            if (!API.pathExists(request, response))
            {
                pathExists = false;
            }
            if (!bodyStatus(request, response))
            {
                pathExists = false;
            }

            if (!pathIdExists(request, response)) {
                pathExists = false;
            }
            if (!pathExists) {
                return;
            }

            var b = model.updateName(request.Path, JsonConvert.DeserializeObject<Category>(request.Body).Name);
            response.Status += "3 updated";
            response.Body = JsonConvert.SerializeObject(b);
       
        }

        public static void delete(Server.Request request, ref Server.Response response)
        {
            var pathExists = pathStatus(request, response);
            if (!API.pathExists(request, response))
            {
                pathExists = false;
            }
            if (!pathIdExists(request, response)) {
                return;
            }


            if (pathExists)
            {
                model.Delete(request.Path);
                response.Status += "1 ok";
            }

        }

        public static void echo(Server.Request request, ref Server.Response response)
        {
            bodyStatus(request, response);
            response.Body = request.Body;
        }



        private static bool pathIdExists(Server.Request request, Server.Response response)
        {
            if (response.Status != null && response.Status.ToLower().Contains("5 not found")
                && request.Path != null && !request.Path.Any(char.IsDigit))
            {
                response.Status = "4 Bad Request";
                return false;
            }
            return true;
        }

        private static bool pathExists(Server.Request request, Server.Response response)
        {
            if (model.getPath(request.Path) != null) return true;
            if (!response.Status.Contains("Bad Request"))
                response.Status += "5 not found, ";
            return false;
        }

        private static bool pathStatus(Server.Request request, Server.Response response)
        {
            if (string.IsNullOrEmpty(request.Path))
            {
                response.Status += "missing resource";
                return false;
            }
            if (model.getPath(request.Path) == null)
            {
        
                if (request.Path.Contains("/api/categories"))
                {

                    response.Status = "5 Not Found";
                } else
                {
                    response.Status = "4 Bad Request";
                }

                return false;
            }
            return true;
        }

        private static bool bodyStatus(Server.Request request, Server.Response response)
        {
            if (string.IsNullOrEmpty(request.Body))
            {
                response.Status += "missing body";
                return false;
            }
            if (Functions.isInvalidbody(request.Body))
            {
                response.Status += "illegal body";
                return false;
            }
            return true;

        }

       


    }


}