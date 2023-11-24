using Pac_Man.Business;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement.GhostAlgorithms;
using Pac_Man.Domain.Models;

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

GhostFleeAlgorithm ghostFleeAlgorithm = new GhostFleeAlgorithm(graph);
GhostPathAlgorithms ghostPathAlgorithms = new GhostPathAlgorithms(dijkstraAlgorithm, ghostFleeAlgorithm, board);

board[9, 7] = new Character();
board.Character = new MoveablesContainer(new Character());
board.Character.position = new KeyValuePair<int, int>(9, 7);
board[3,7] = new Ghost();
board.Ghosts["Clyde"].position = new KeyValuePair<int, int>(3, 7);
board.PrintBoard();

var path = ghostPathAlgorithms.MainGhostMovements("Clyde", board.Ghosts["Clyde"], board.Character);

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
