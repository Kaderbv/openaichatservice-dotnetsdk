using Azure;
using Azure.AI.OpenAI;

namespace openaichatservice_dotnetsdk;

class Program
{
    const string endpoint = "https://<youropenaidomain>.openai.azure.com";
    const string key = "<<Your Key>>";
    const string deploymentName = "GPT-35-Turbo"; 

   
    static void Main(string[] args)
    {
        OpenAIClient client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));
        //Console.WriteLine("Hello, World!");
        // Build completion options object
        ChatCompletionsOptions chatCompletionsOptions = new ChatCompletionsOptions()
        {
            Messages =
            {
                new ChatRequestSystemMessage("You are a helpful AI bot."),
                new ChatRequestUserMessage("What is Azure OpenAI?"),
            },
            DeploymentName = deploymentName
        };

        // Send request to Azure OpenAI model
        ChatCompletions response = client.GetChatCompletions(chatCompletionsOptions);

        // Print the response
        string completion = response.Choices[0].Message.Content;
        Console.WriteLine("Response: " + completion + "\n");
    }
}
