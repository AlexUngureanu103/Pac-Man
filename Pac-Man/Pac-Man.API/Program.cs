using Pac_Man.Business;
using Pac_Man.Business.GraphRepresentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


Board board = new Board();
board.PrintBoard();

Graph graph = new Graph(board);
graph.PrintAdjacencyList();

DijkstraAlgorithm dijkstraAlgorithm = new DijkstraAlgorithm(graph);
var ghostPositions = graph.Ghosts["Inky"].position;
var playerPositions = graph.Character.position;
var distances = dijkstraAlgorithm.Execute($"({ghostPositions.Key}, {ghostPositions.Value})",$"({playerPositions.Key}, {playerPositions.Value})",500);

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
