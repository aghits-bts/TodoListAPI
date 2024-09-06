using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TodoListAPI.Data;

namespace TodoListAPI.Controllers
{
    public class HealthController : IHealthCheck
    {
        private readonly TodoDbContext _context;
        public HealthController(TodoDbContext context)
        {
            _context = context;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.Database.CanConnectAsync(cancellationToken);
                return HealthCheckResult.Healthy("Database is healthy");
            }
            catch (Exception)
            {
                return HealthCheckResult.Unhealthy("Database connection failed");
            }
        }
    }
}
