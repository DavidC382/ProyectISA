using ApiSQR.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BaseSQRContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/Admin", () => {
    using (var context = new BaseSQRContext()) { 
        return context.Admins.ToList();
    }

});
app.MapGet("/Admin/{id}", async (int id,BaseSQRContext context) => {
    
    var admin = await context.Admins.FindAsync(id);
    return admin != null ? Results.Ok(admin) : Results.NotFound();
});
app.MapPost("/Admin", async (Admin admin, BaseSQRContext context) => { 
    context.Admins.Add(admin);
    await context.SaveChangesAsync();

    return Results.Created($"/Admin/{admin.Idadmin}", admin);
});
app.MapPut("/Amdin/{id}", async (int id, BaseSQRContext context, Admin inputAdmin) => { 
    var admin = await context.Admins.FindAsync(id);
    if (admin == null) return Results.NotFound();

    admin.Nomadmin = inputAdmin.Nomadmin;
    admin.Apeadmin = inputAdmin.Apeadmin;
    admin.Paswadim = inputAdmin.Paswadim;
    admin.Proyectos = inputAdmin.Proyectos;

    await context.SaveChangesAsync();
    return Results.NoContent();

});

app.MapDelete("/Admin/{id}", async (int id, BaseSQRContext context) => {
    if (await context.Admins.FindAsync(id) is Admin admin) { 
        context.Admins.Remove(admin);
        await context.SaveChangesAsync();
        return Results.Ok(admin);
    }
    return Results.NotFound();
});



app.MapGet("/Docente", async (BaseSQRContext context) => {
     return await context.Docentes.ToListAsync();

});
app.MapGet("/Docente/{id}", async (int id, BaseSQRContext context) => {

    var doc = await context.Docentes.FindAsync(id);
    return doc != null ? Results.Ok(doc) : Results.NotFound();
});
app.MapPost("/Docente", async (Docente doc, BaseSQRContext context) =>
{
    context.Docentes.Add(doc);
    await context.SaveChangesAsync();
    return Results.Created($"/Docente/{doc.Iddoc}", doc);
});
app.MapPut("/Docente/{id}", async (int id, BaseSQRContext context, Docente inputDoc) => {
    var doc = await context.Docentes.FindAsync(id);
    if (doc == null) return Results.NotFound();

    doc.Coddoc = inputDoc.Coddoc;
    doc.Nomdoc = inputDoc.Nomdoc;
    doc.Apedoc = inputDoc.Apedoc;
    doc.Roldoc = inputDoc.Roldoc;
    doc.Pawdoc = inputDoc.Pawdoc;
    await context.SaveChangesAsync();
    return Results.NoContent();

});
app.MapDelete("/Docente/{id}", async (int id, BaseSQRContext context) => {
    if (await context.Docentes.FindAsync(id) is Docente doc)
    {
        context.Docentes.Remove(doc);
        await context.SaveChangesAsync();
        return Results.Ok(doc);
    }
    return Results.NotFound();
});



app.MapGet("/Estudiante", async (BaseSQRContext context) => {
    return await context.Estudiantes.ToListAsync();

});
app.MapGet("/Estudiante/{id}", async (int id, BaseSQRContext context) => {

    var est = await context.Estudiantes.FindAsync(id);
    return est != null ? Results.Ok(est) : Results.NotFound();
});
app.MapPost("/Estudiante", async (Estudiante est, BaseSQRContext context) =>
{
    context.Estudiantes.Add(est);
    await context.SaveChangesAsync();
    return Results.Created($"/Estudiante/{est.Idest}", est);
});
app.MapPut("/Estudiante/{id}", async (int id, BaseSQRContext context, Estudiante inputEst) => {
    var est = await context.Estudiantes.FindAsync(id);
    if (est == null) return Results.NotFound();

    est.Codest = inputEst.Codest;
    est.Semest = inputEst.Semest;
    est.Nomest = inputEst.Nomest;
    est.Apeest = inputEst.Apeest;
    est.Paswest = inputEst.Paswest;
    
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/Estudiante/{id}", async (int id, BaseSQRContext context) => {
    if (await context.Estudiantes.FindAsync(id) is Estudiante est)
    {
        context.Estudiantes.Remove(est);
        await context.SaveChangesAsync();
        return Results.Ok(est);
    }
    return Results.NotFound();
});


app.MapGet("/Proyecto", async (BaseSQRContext context) => {
    return await context.Proyectos.ToListAsync();

});
app.MapGet("/Proyecto/{id}", async (int id, BaseSQRContext context) => {

    var est = await context.Proyectos.FindAsync(id);
    return est != null ? Results.Ok(est) : Results.NotFound();
});
app.MapPost("/Proyecto", async (Proyecto proy, BaseSQRContext context) =>
{
    context.Proyectos.Add(proy);
    await context.SaveChangesAsync();
    return Results.Created($"/Proyecto/{proy.Idest}", proy);
});
app.MapPut("/Proyecto/{id}", async (int id, BaseSQRContext context, Proyecto inputProy) => {
    var proy = await context.Proyectos.FindAsync(id);
    if (proy == null) return Results.NotFound();

    proy.Nomproy = inputProy.Nomproy;
    proy.Archivoproy = inputProy.Archivoproy;
    proy.Idadmin = inputProy.Idadmin;
    proy.Idest = inputProy.Idest;
    await context.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/Proyecto/{id}", async (int id, BaseSQRContext context) => {
    if (await context.Proyectos.FindAsync(id) is Proyecto proy)
    {
        context.Proyectos.Remove(proy);
        await context.SaveChangesAsync();
        return Results.Ok(proy);
    }
    return Results.NotFound();
});


app.Run();
