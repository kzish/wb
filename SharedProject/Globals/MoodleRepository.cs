using SharedModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Globals
{
    public class MoodleRepository
    {
        public dynamic CreateMoodleUser(MMoodleUser user)
        {
            try
            {
                //create tutor in moodle via api
                var http_client = new HttpClient();
                http_client.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");

                var parameters = new Dictionary<string, string>();
                parameters.Add("wsfunction", "core_user_create_users");
                parameters.Add("users[0][username]", $"{user.Firstname.ToLower()}");
                parameters.Add("users[0][password]", user.Password);
                parameters.Add("users[0][firstname]", user.Firstname);
                parameters.Add("users[0][lastname]", user.Surname);
                parameters.Add("users[0][email]", user.Email);

                var http_response = http_client.PostAsync(AppSettings.moodle_api_endpoint, new FormUrlEncodedContent(parameters))
                    .Result
                    .Content
                    .ReadAsStringAsync()
                    .Result;

                dynamic resObject = JsonConvert.DeserializeObject(http_response);
                dynamic response = new ExpandoObject();
                if (resObject.ToString().Contains("exception"))
                {
                    response.res = "err";
                    response.msg = resObject.message.ToString();
                }
                else
                {
                    response.res = "ok";
                    response.moodle_user_id = resObject[0].id;
                }

                return response;
            }
            catch (Exception ex)
            {
                dynamic err = new ExpandoObject();
                err.res = "err";
                err.msg = ex.Message;
                return err;
            }
        }

        public dynamic DeleteMoodleUser(MMoodleUser user)
        {
            try
            {
                //create tutor in moodle via api
                var http_client = new HttpClient();
                http_client.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");

                var parameters = new Dictionary<string, string>();
                parameters.Add("wsfunction", "core_user_delete_users");
                parameters.Add("userids[0]", $"{user.MoodleId}");

                var http_response = http_client.PostAsync(AppSettings.moodle_api_endpoint, new FormUrlEncodedContent(parameters))
                    .Result
                    .Content
                    .ReadAsStringAsync()
                    .Result;

                dynamic resObject = JsonConvert.DeserializeObject(http_response);
                dynamic response = new ExpandoObject();
                if (resObject != null && resObject.ToString().Contains("exception"))
                {
                    response.res = "err";
                    response.msg = resObject.message.ToString();
                }
                else
                {
                    response.res = "ok";
                }

                return response;
            }
            catch (Exception ex)
            {
                dynamic err = new ExpandoObject();
                err.res = "err";
                err.msg = ex.Message;
                return err;
            }
        }

        public dynamic CreateMoodleCourse(MTutorCourse course)
        {
            try
            {
                //create tutor in moodle via api
                var http_client = new HttpClient();
                http_client.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");

                var parameters = new Dictionary<string, string>();
                parameters.Add("wsfunction", "core_course_create_courses");
                parameters.Add("courses[0][fullname]", $"{course.Title.ToLower()}");
                parameters.Add("courses[0][shortname]", $"{course.Title.ToLower()}");
                parameters.Add("courses[0][summary]", course.Description);
                parameters.Add("courses[0][categoryid]", "1");

                var http_response = http_client.PostAsync(AppSettings.moodle_api_endpoint, new FormUrlEncodedContent(parameters))
                    .Result
                    .Content
                    .ReadAsStringAsync()
                    .Result;

                dynamic resObject = JsonConvert.DeserializeObject(http_response);
                dynamic response = new ExpandoObject();
                if (resObject.ToString().Contains("exception"))
                {
                    response.res = "err";
                    response.msg = resObject.message.ToString();
                }
                else
                {
                    response.res = "ok";
                    response.moodle_course_id = resObject[0].id;
                }

                return response;
            }
            catch (Exception ex)
            {
                dynamic err = new ExpandoObject();
                err.res = "err";
                err.msg = ex.Message;
                return err;
            }
        }

        public dynamic DeleteMoodleCourse(MTutorCourse course)
        {
            try
            {
                //create tutor in moodle via api
                var http_client = new HttpClient();
                http_client.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");

                var parameters = new Dictionary<string, string>();
                parameters.Add("wsfunction", "core_course_delete_courses");
                parameters.Add("courseids[0]", $"{course.MoodleCourseId}");

                var http_response = http_client.PostAsync(AppSettings.moodle_api_endpoint, new FormUrlEncodedContent(parameters))
                    .Result
                    .Content
                    .ReadAsStringAsync()
                    .Result;

                dynamic resObject = JsonConvert.DeserializeObject(http_response);
                dynamic response = new ExpandoObject();
                if (resObject != null && resObject.ToString().Contains("exception"))
                {
                    response.res = "err";
                    response.msg = resObject.message.ToString();
                }
                else
                {
                    response.res = "ok";
                }

                return response;
            }
            catch (Exception ex)
            {
                dynamic err = new ExpandoObject();
                err.res = "err";
                err.msg = ex.Message;
                return err;
            }
        }

        public dynamic EditMoodleCourse(MTutorCourse course)
        {
            try
            {
                //create tutor in moodle via api
                var http_client = new HttpClient();
                http_client.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");

                var parameters = new Dictionary<string, string>();
                parameters.Add("wsfunction", "core_course_update_courses");
                parameters.Add("courses[0][id]", $"{course.MoodleCourseId}");
                parameters.Add("courses[0][fullname]", $"{course.Title.ToLower()}");
                parameters.Add("courses[0][shortname]", $"{course.Title.ToLower()}");
                parameters.Add("courses[0][summary]", course.Description);
                parameters.Add("courses[0][categoryid]", "1");

                var http_response = http_client.PostAsync(AppSettings.moodle_api_endpoint, new FormUrlEncodedContent(parameters))
                    .Result
                    .Content
                    .ReadAsStringAsync()
                    .Result;

                dynamic resObject = JsonConvert.DeserializeObject(http_response);
                dynamic response = new ExpandoObject();
                if (resObject.ToString().Contains("exception"))
                {
                    response.res = "err";
                    response.msg = resObject.message.ToString();
                }
                else
                {
                    response.res = "ok";
                    //response.moodle_course_id = resObject[0].id;
                }

                return response;
            }
            catch (Exception ex)
            {
                dynamic err = new ExpandoObject();
                err.res = "err";
                err.msg = ex.Message;
                return err;
            }
        }
    }
}
