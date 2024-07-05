using Microsoft.SemanticKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel.Connectors.HuggingFace;

var builder = Kernel.CreateBuilder();

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>();
IConfiguration configuration = configBuilder.Build();

string openAI_Key = configuration["OpenAI_API_Key"];
string huggingFace_ApiKey = configuration["HUGGINGFACEAPIKEY"];

builder.AddOpenAIChatCompletion("gpt-3.5-turbo",
                                openAI_Key);


//builder.AddHuggingFaceChatCompletion("google/flan-t5-xxl");                                    
                                     //huggingFace_ApiKey);
var kernel = builder.Build();
var results = await kernel.InvokePromptAsync("Give me a list of breakfast foods with their calorie count");


Console.WriteLine(results);

Console.ReadKey();
