using IOTservice.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Azure.Devices;

namespace IOTservice.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StatusUpdateController : ApiController
    {
        ServiceClient serviceClient;
        static string connectionString = "___IoT-Hub-connection-string___";

        public StatusUpdateController() {
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
        }

        // POST api/values
        [HttpPost]
        public async Task<IHttpActionResult> Post(Selector selector)
        {
            using (SqlConnection myConnection = new SqlConnection(DbConnectionString))
            {
                myConnection.Open();
                var toBeSent = "0";
                switch(selector.Type)
                {
                    case 0:
                        SqlCommand myCommand0 = new SqlCommand("UPDATE [tabela] SET  state = 0 WHERE object >= 1", myConnection);
                        myCommand0.ExecuteNonQuery();
                        toBeSent = "0";
                        break;
                    case 1:
                        SqlCommand myCommand1 = new SqlCommand("UPDATE [tabela] SET  state = 1 WHERE object = 1", myConnection);
                        myCommand1.ExecuteNonQuery();
                        toBeSent = "1";
                        break;
                    case 2:
                        SqlCommand myCommand2 = new SqlCommand("UPDATE [tabela] SET  state = 1 WHERE object = 2", myConnection);
                        myCommand2.ExecuteNonQuery();
                        toBeSent = "2";
                        break;
                    case 3:
                        SqlCommand myCommand3 = new SqlCommand("UPDATE [tabela] SET  state = 1 WHERE object = 3", myConnection);
                        myCommand3.ExecuteNonQuery();
                        toBeSent = "3";
                        break;
                }

                var azureMessage = new Message(Encoding.ASCII.GetBytes(toBeSent));
                await serviceClient.SendAsync("RasberryPi3",azureMessage);
                return Ok();

            }
        }

        public static string DbConnectionString = "___AzureSQL-connection-string___";
    }
}
