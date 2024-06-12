using JiraIntegration.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddSingleton(new JiraService(
    _jiraDomain: "sayidahror.atlassian.net",
    _jiraApiToken:"ATATT3xFfGF067Y6qPYTmo_umuzPQBpaHYpOgzVoFsAC-dTJbNPSXOcnqseHTg9m9COoPxVB46NDzFsWJ7Zj6q6ddvWvKZwdlFWboc7W7Fg5JSpZDaHo36hPNh1p8uUJPHe0EYswkZ3kZi4U26u3GV8ncQeNHBeEM_krJ8IGvI4_lueNKyEhHcM=3B5A3036",
    _projectKey: "KAN"
));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
