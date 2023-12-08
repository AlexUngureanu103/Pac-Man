using Pac_Man.Business;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Movement.GhostAlgorithms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IGameCharacters gameCharacters = new GameCharacters();
IBoard board = new Board(gameCharacters);

IGraph graph = new Graph(board, gameCharacters);

IDijkstraAlgorithm dijkstraAlgorithm = new DijkstraAlgorithm(graph);
IGhostFleeAlgorithm ghostFleeAlgorithm = new GhostFleeAlgorithm(graph);
IGhostPathAlgorithms ghostPathAlgorithms = new GhostPathAlgorithms(dijkstraAlgorithm, ghostFleeAlgorithm, board);

var app = builder.Build();

var gamelogic = new GameLogic(dijkstraAlgorithm, ghostFleeAlgorithm, ghostPathAlgorithms, board, graph);

gamelogic.StartGame();

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
