using System.Text;
using backend.Services;
using backend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEncode, AES256>();
builder.Services.AddCors();

builder.Services.Configure<ForwardedHeadersOptions>(option =>
  option.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
  options.RequireHttpsMetadata = false;
  options.SaveToken = true;
  options.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidAudience = builder.Configuration["Jwt:Audience"],
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
  };
});

var app = builder.Build();
app.UseCors(x => x
   .AllowAnyMethod()
   .AllowAnyHeader()
   .AllowAnyOrigin()
);



app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions {
  FileProvider = new PhysicalFileProvider(Path.Combine("C:", "storage")), 
  RequestPath = "/storage",
              OnPrepareResponse = ctx => {
                ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
              }
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
