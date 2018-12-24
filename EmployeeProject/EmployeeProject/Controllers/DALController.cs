using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeProject.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace EmployeeProject.Controllers
{
    public class DALController : ApiController
    {
        public abstract class JsonCreationConverter<T> : JsonConverter
        {
            protected abstract T Create(Type objectType, JObject jObject);

            public override bool CanConvert(Type objectType)
            {
                return typeof(T) == objectType;
            }

            public override object ReadJson(JsonReader reader, Type objectType,
                object existingValue, JsonSerializer serializer)
            {
                try
                {
                    var jObject = JObject.Load(reader);
                    var target = Create(objectType, jObject);
                    serializer.Populate(jObject.CreateReader(), target);
                    return target;
                }
                catch (JsonReaderException)
                {
                    return null;
                }
            }

            public override void WriteJson(JsonWriter writer, object value,
                JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }

        public class EmployeeConverter : JsonCreationConverter<Employee>
        {
            protected override Employee Create(Type objectType, JObject jObject)
            {
                Factory factory = new FactoryImplementation();
                return factory.FactoryMethod((int)jObject["id"].Value<int>(), (string)jObject["name"].Value<string>(), (string)jObject["contractTypeName"].Value<string>(),
                                                (int)jObject["roleId"].Value<int>(), (string)jObject["roleName"].Value<string>(), (string)jObject["roleDescription"].Value<string>(),
                                                (int)jObject["hourlySalary"].Value<int>(), (int)jObject["monthlySalary"].Value<int>());
            }
        }

        public static List<Employee> GetEmployeeAsync()
        {
            List<Employee> employees = new List<Employee>();

            string Baseurl = "http://masglobaltestapi.azurewebsites.net/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var Res = client.GetStringAsync("api/Employees").Result;


                employees = JsonConvert.DeserializeObject<List<Employee>>(Res, new EmployeeConverter());

                return employees;
            }
        }

    }
}
