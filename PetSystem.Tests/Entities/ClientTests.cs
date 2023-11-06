using PetSystem.Core.Entities.Models;
using PetSystem.Tests.Builders.Models;
using Xunit;
using Xunit.Abstractions;
using Assert = PetSystem.Tests.Common.Assert;

namespace PetSystem.Tests.Entities;

public class ClientTests
{
    private readonly ClientBuilder _builder;
    private readonly ITestOutputHelper _output;

    public ClientTests(ITestOutputHelper output)
    {
        _builder = new ClientBuilder();
        _output = output;
    }

    [Fact(DisplayName = "#01 - Must create a client")]
    public void MustCreateAClient()
    {
        var builder = _builder.New().Build();
        var client = _builder.Build();

        client.ValidateForPersistence().Wait();
        client.ValidationResult = builder.ValidationResult;
        Assert.Equal<Client>(builder, client, _output);
    }

    #region Name
    [Fact(DisplayName = "#02 - Must create a client - valid NAME")]
    public void MustCreateAClient_ValidName()
    {
        var client = _builder.New().Build();
        client.Name = client.Name;

        client.ValidateForPersistence().Wait();
        Assert.True(client.IsValid,
                    string.Join(Environment.NewLine,
                    client.ValidationResult.Errors), _output, client);
    }

    [Fact(DisplayName = "#03 - Should not create a client - invalid NAME")]
    public void ShouldNotCreateAClient_InvalidName()
    {
        var client = _builder.New().Build();
        client.Name = null;

        client.ValidateForPersistence().Wait();
        Assert.False(client.IsValid,
                    string.Join(Environment.NewLine,
                    client.ValidationResult.Errors), _output, client);
    }
    #endregion
}