using Pac_Man.Business;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement.Ghost_Algorithms;

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

GhostPathAlgorithms ghostPathAlgorithms = new GhostPathAlgorithms(dijkstraAlgorithm);
GhostFleeAlgorithm ghostFleeAlgorithm = new GhostFleeAlgorithm(graph);

var nextMove = ghostFleeAlgorithm.Flee(board.Ghosts["Pinky"], board.Character);

var path = ghostPathAlgorithms.MainGhostMovements(board.Ghosts["Blinky"], board.Character);

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
