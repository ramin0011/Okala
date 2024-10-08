### Okala Ramin Test

This App is developed using different technologies, and its all based on dotnet aspire
so to start the App you need to run the Okala.AppHost project

Before running the project check the connection string :\Okala.Api.App\Okala.Api.App\appsettings.json

To login in swagger :username:admin password:1q2w3E*

ps:the unit tests are located in:\CryptoServices\Crypto.Tests

ps: the project has three main sections : dotnet aspire , crypto services , app services all in their own folder

### Technical Questions

### 1. How long did you spend on the coding assignment? What would you add to your solution if you had more time? If you didn't spend much time on the coding assignment then use this as an opportunity to explain what you would add.


I spent approximately 10 hours on the coding assignment. If I had more time, I would add the following enhancements:
- **Caching**: Implement caching to reduce the number of API calls and improve performance.
- **Mircoservice**: Improve the infrustructure of the microservices
- **Logging**: Implement logging to track the application's behavior and troubleshoot issues more effectively.
- **Dockerization**: Containerize the application using Docker for easier deployment and isoloation of the services.


### 2. What was the most useful feature that was added to the latest version of your language of choice? Please include a snippet of code that shows how you've used it.

Records could be one of the new interesting feature in dotnet, I have also used it in this project and 
here is a sample code:

```csharp
namespace Okala.Api.App.Applications.Dtos;

public record QuotesRequestModel(string Code);

```
another one is nullable reference types

```csharp
public class CryptoQuote
{
    public decimal? USD { get; set; }
    public decimal? EUR { get; set; }
    public decimal? BRL { get; set; }
    public decimal? GBP { get; set; }
    public decimal? AUD { get; set; }
}
```

### 3.How would you track down a performance issue in production? Have you ever had to do this?

- **Development**: I would use Retry patterns, ACL to connecting to the third party Apis
- **Chaching**: I would study the Third party behaviour and implement suitable caching system based on my App usage.
- **Logging**: Analyze logs to find any error messages or unusual patterns that could indicate performance issues, it would be appropriate to use ELK and logstash.
- **Profiling**: Use profiling tools like dotTrace to analyze the application’s performance.
- **Devops**: I would design the infrustructure to be able to handle high traffic and to be scalable horizonatally easier.

### What was the latest technical book you have read or tech conference you have been to? What did you learn?

The latest technical book I read was “Design Patterns Elements of Reusable Object Oriented Patterns” 
and I have recently published a new course on Maktabkhoneh based on this book:


### What do you think about this technical assessment?

this assignment effectively evaluates a candidate’s ability to solve real-world problems.
the best part about this test is that it delegates and leaves all the architechture and design system to the developer to decide the best one based on the limited time.
however it could be better to add more items to the evaluation criteria.

### 6. Please, describe yourself using JSON.

```json
{
    "full-name": "Ramin M.Hoseini",
    "role": "Software Engineer",
    "experience-in-years": 10,
    "passions": [
        "Developing innovative software solutions",
        "Having a good impact on the team/tech/product/business",
        "Learning new technologies",
        "Improving/working-on self development"
    ]
}

```
