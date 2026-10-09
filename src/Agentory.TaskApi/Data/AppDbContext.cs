using Microsoft.EntityFrameworkCore;

namespace Agentory.TaskApi.Data;

/// <summary>
/// EF Core database context for the API. Entities are added with BL-3 (Project) and BL-4 (TaskItem).
/// </summary>
public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options);
