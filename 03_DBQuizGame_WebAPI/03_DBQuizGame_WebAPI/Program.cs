using _01_DBQuizGame_Persistence.Entity;
using _02_DBQuizGame_Service.Service;
using _02_DBQuizGame_Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBQuizGameContext>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddCors();

#region Service Scopes
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IObjectStateService, ObjectStateService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ICertificateService, CertificateService>();
builder.Services.AddScoped<IPlayerCertificateService, PlayerCertificateService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IPlayerQuizService, PlayerQuizService>();
builder.Services.AddScoped<IQuizCertificateService, QuizCertificateService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionTypeService, QuestionTypeService>();
builder.Services.AddScoped<IOptionService, OptionService>();
#endregion  

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(options =>
     options.WithOrigins("https://njm2000.github.io", "https://html-classic.itch.zone")
            .AllowAnyHeader()
            .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
