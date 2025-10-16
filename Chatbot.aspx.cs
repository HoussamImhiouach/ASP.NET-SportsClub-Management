using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class Chatbot : System.Web.UI.Page
    {
        private static readonly string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        private static readonly string apiUrl = "https://api.openai.com/v1/chat/completions";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Validate session
            if (Session["UserID"] == null)
            {
                Response.Redirect("loginsport.aspx");
                return;
            }

            if (!IsPostBack)
            {
                // Initialize chat history
                if (Session["ChatHistory"] == null)
                    Session["ChatHistory"] = "";
            }

            // Update chat messages
            chatMessages.InnerHtml = Session["ChatHistory"]?.ToString();
        }

        protected async void btnSend_Click(object sender, EventArgs e)
        {
            string userMessage = txtUserInput.Text.Trim();
            if (!string.IsNullOrEmpty(userMessage))
            {
                // Append user message to chat history
                Session["ChatHistory"] += $"<div class='message user'>{userMessage}</div>";

                // Get chatbot response
                string botResponse = await GetChatbotResponse(userMessage);

                // Append bot response to chat history
                Session["ChatHistory"] += $"<div class='message bot'>{botResponse}</div>";

                // Update the chat display
                chatMessages.InnerHtml = Session["ChatHistory"].ToString();

                // Clear user input
                txtUserInput.Text = "";
            }
        }

        private async Task<string> GetChatbotResponse(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var payload = new
                    {
                        model = "gpt-3.5-turbo",
                        messages = new[]
                        {
                            new { role = "system", content = "You are FitBot, a cheerful fitness assistant. Keep answers to the point and lighthearted. use emojis when you can " },
                            new { role = "user", content = message }
                        }
                    };

                    string jsonPayload = JsonConvert.SerializeObject(payload);
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);
                        return jsonResponse.choices[0].message.content.ToString();
                    }
                    else
                    {
                        return $"Error: {response.ReasonPhrase}";
                    }
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}";
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("loginsport.aspx");
        }
    }
}
