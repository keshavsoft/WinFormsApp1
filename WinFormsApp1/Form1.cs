using Newtonsoft.Json;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = await ExampleGet();
        }

        public async Task<String> Example()
        {
            //The data that needs to be sent. Any object works.
            var pocoObject = new
            {
                Name = "KeshavSoft",
                Occupation = "Developers"
            };

            //Converting the object to a json string. NOTE: Make sure the object doesn't contain circular references.
            string json = JsonConvert.SerializeObject(pocoObject);

            //Needed to setup the body of the request
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            //The url to post to.
            //var url = "https://httpbin.org/post";


            var url = "https://localhost:4151";
            var client = new HttpClient();

            //Pass in the full URL and the json string content
            var response = await client.PostAsync(url, data);

            //It would be better to make sure this request actually made it through
            string result = await response.Content.ReadAsStringAsync();

            //close out the client
            client.Dispose();

            return result;
        }

        public async Task<String> ExampleGet()
        {
            //The data that needs to be sent. Any object works.
            var pocoObject = new
            {
                Name = "KeshavSoft",
                Occupation = "Developers"
            };

            //Converting the object to a json string. NOTE: Make sure the object doesn't contain circular references.
            string json = JsonConvert.SerializeObject(pocoObject);

            //Needed to setup the body of the request
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            //The url to post to.
            //var url = "https://httpbin.org/post";


            var url = "http://localhost:4119";
            var client = new HttpClient();

            //Pass in the full URL and the json string content
            var response = await client.GetAsync(url);

            //It would be better to make sure this request actually made it through
            string result = await response.Content.ReadAsStringAsync();

            //close out the client
            client.Dispose();

            return result;
        }



    }
}