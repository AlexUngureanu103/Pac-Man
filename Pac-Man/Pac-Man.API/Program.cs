using Pac_Man.Business;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Movement.GhostAlgorithms;
using Pac_Man.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IGameCharacters gameCharacters = new GameCharacters();
Board board = new Board(gameCharacters);
//board.PrintBoard();

IGraph graph = new Graph(board, gameCharacters);
//graph.PrintAdjacencyList();

IDijkstraAlgorithm dijkstraAlgorithm = new DijkstraAlgorithm(graph);
IGhostFleeAlgorithm ghostFleeAlgorithm = new GhostFleeAlgorithm(graph);
IGhostPathAlgorithms ghostPathAlgorithms = new GhostPathAlgorithms(dijkstraAlgorithm, ghostFleeAlgorithm, board);

//board[9, 7] = new Character();
//board.GameCharacters.Character = new MoveablesContainer(new Character());
//board.GameCharacters.Character.position = new KeyValuePair<int, int>(9, 7);
//board[3, 7] = new Ghost();
//board.GameCharacters.Ghosts["Clyde"].position = new KeyValuePair<int, int>(3, 7);
//board.PrintBoard();

//var path = ghostPathAlgorithms.MainGhostMovements("Clyde", board.GameCharacters.Ghosts["Clyde"], board.GameCharacters.Character);

var app = builder.Build();

var gamelogic = new GameLogic(dijkstraAlgorithm, ghostFleeAlgorithm, ghostPathAlgorithms);

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
