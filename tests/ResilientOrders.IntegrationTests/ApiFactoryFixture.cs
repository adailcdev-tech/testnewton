using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ResilientOrders.IntegrationTests;

// Sobe a API em memória (TestServer) para os testes de endpoint.
// O HttpClient exposto já tem o BaseAddress configurado — basta passar
// para o RestClient: new RestClient(_fixture.HttpClient)
public class ApiFactoryFixture : IDisposable
{
    public WebApplicationFactory<Program> Factory { get; }
    public HttpClient HttpClient { get; }

    public ApiFactoryFixture()
    {
        Factory    = new WebApplicationFactory<Program>();
        HttpClient = Factory.CreateClient();
    }

    public void Dispose()
    {
        HttpClient.Dispose();
        Factory.Dispose();
        GC.SuppressFinalize(this);
    }
}

[CollectionDefinition("api")]
public class ApiCollection : ICollectionFixture<ApiFactoryFixture> { }