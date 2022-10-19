using Microsoft.AspNetCore.Mvc.Testing;

namespace ExpenseRecordTest;

public class CreateItemTest
{
    [Fact]
    public async Task Should_Return_All_Pets_When_Get_All_Pets()
    {
        // given
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(_ => { });
        var client = application.CreateClient();
        const string name = "Bob";

        // when
        //var response = await client.GetAsync("Greeting?name=" + name);
        var response = await client.PostAsync();
        // then
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.Equal("Hello, Bob", responseBody);
    }
}