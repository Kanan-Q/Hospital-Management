using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

public class IpRestrictionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<IpRestrictionMiddleware> _logger;
    private readonly List<string> _allowedIps;

    public IpRestrictionMiddleware(RequestDelegate next, ILogger<IpRestrictionMiddleware> logger)
    {
        _next = next;  
        _logger = logger;

        _allowedIps = LoadAllowedIpsFromFile();

        if (!_allowedIps.Contains("127.0.0.1")) _allowedIps.Add("127.0.0.1");
        if (!_allowedIps.Contains("::1")) _allowedIps.Add("::1");

        string myIp = "192.168.1.71";
        if (!_allowedIps.Contains(myIp)) _allowedIps.Add(myIp);

        _logger.LogInformation($"Loaded allowed IPs: {string.Join(", ", _allowedIps)}");
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var remoteIp = context.Connection.RemoteIpAddress?.ToString();

        _logger.LogInformation($"Incoming IP: {remoteIp}");

        if (!string.IsNullOrEmpty(remoteIp) && !_allowedIps.Contains(remoteIp))
        {
            _logger.LogWarning($"Unauthorized access attempt from IP: {remoteIp}");
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Access Denied: Your IP is not allowed.");
            return;
        }

        await _next(context);
    }

    private List<string> LoadAllowedIpsFromFile()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "allowed_ips.json");

        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<AllowedIpList>(json);
            return data?.AllowedIPs ?? new List<string>();
        }

        return new List<string>();
    }
}

public class AllowedIpList
{
    public List<string> AllowedIPs { get; set; }
}
