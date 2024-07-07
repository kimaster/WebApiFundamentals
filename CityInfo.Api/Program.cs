using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.WebEncoders.Testing;
using System.Reflection.PortableExecutable;

var builder = WebApplication.CreateBuilder(args);

/*
 
 1- builder.Services.AddControllers()

        1-1 builder.Services.AddMvc();
 
 */
//* adding and configuring service
//
//
//*/
// Add services to the container.

builder.Services.AddControllers(options =>
{
    //set the not support media type
    options.ReturnHttpNotAcceptable = true;

    // formatter
    // firt formatter is the defaulkt one

    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

    
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddProblemDetails(options =>

{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions.Add("addtionInformation", "addint info example");
        context.ProblemDetails.Extensions.Add("server", Environment.MachineName);
    };

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//*sawaggger information**/
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();



var app = builder.Build();


// configuring middle ware that handle the httprequests


//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
//older versoipm
// app.UseRouting();
// use the ogic for selction the routing wich controller and action need to be executed


app.UseAuthorization();





//app.UseEndpoints(endpoints => endpoints.MapControllers());
// calling the endpoints


// this is need to map the routing  for the controller 
// endpoint routing 
//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-8.0
// this is short cut as this is mapController the Webapplication object emplmmnet  implement UseRouting() IEndpointRouting
//app.MapControllers();

app.UseEndpoints(
    endpoints =>
endpoints.MapControllers());


app.Run();
