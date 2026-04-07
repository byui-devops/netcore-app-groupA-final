using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace NetCoreContosoUniversityApp.Testing.Integration;

public class ContosoUniversityIntegrationTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ContosoUniversityIntegrationTests(
        WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task HomePage_ReturnsSuccessStatusCode()
    {
        var response = await _client.GetAsync("/");
        response.IsSuccessStatusCode.Should().BeTrue(
            because: "the home page should be reachable");
    }

    [Fact]
    public async Task StudentsPage_ReturnsSuccessStatusCode()
    {
        var response = await _client.GetAsync("/Students");
        response.IsSuccessStatusCode.Should().BeTrue(
            because: "the students listing page should be reachable");
    }

    [Fact]
    public async Task CoursesPage_ReturnsSuccessStatusCode()
    {
        var response = await _client.GetAsync("/Courses");
        response.IsSuccessStatusCode.Should().BeTrue(
            because: "the courses listing page should be reachable");
    }

    [Fact]
    public async Task InstructorsPage_ReturnsSuccessStatusCode()
    {
        var response = await _client.GetAsync("/Instructors");
        response.IsSuccessStatusCode.Should().BeTrue(
            because: "the instructors listing page should be reachable");
    }

    [Fact]
    public async Task DepartmentsPage_ReturnsSuccessStatusCode()
    {
        var response = await _client.GetAsync("/Departments");
        response.IsSuccessStatusCode.Should().BeTrue(
            because: "the departments listing page should be reachable");
    }
}
