using Application.MockDomains;
using Domain.MockDomain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MockDomainsController : BaseApiController
{
    [HttpGet]
    public async Task<List<MockDomain>> GetMockDomains()
    {
        return await Mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    public async Task<MockDomain> GetMockDomain(Guid id)
    {
        return await Mediator.Send(new Details.Query{Id = id});
    }

    [HttpPost]
    public async Task<IActionResult> CreateMockDomain(MockDomain mockDomain)
    {
        await Mediator.Send(new Create.Command { MockDomain = mockDomain });
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditMockDomain(Guid id, MockDomain mockDomain)
    {
        mockDomain.Id = id;
        await Mediator.Send(new Edit.Command { MockDomain = mockDomain });

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMockDomain(Guid id)
    {
        await Mediator.Send((new Delete.Command { Id = id }));
        
        return Ok();
    }
    
} 