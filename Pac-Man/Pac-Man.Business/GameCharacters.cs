using Pac_Man.Domain.Models;

namespace Pac_Man.Business
{
    public class GameCharacters : IGameCharacters
    {
        public MoveablesContainer Character { get; set; } = new MoveablesContainer(new Character());
        public Dictionary<string, MoveablesContainer> Ghosts { get; set; } = new Dictionary<string, MoveablesContainer>
            {
                { "Blinky", new MoveablesContainer(new Ghost()) },
                { "Pinky", new MoveablesContainer(new Ghost()) },
                { "Inky", new MoveablesContainer(new Ghost()) },
                { "Clyde", new MoveablesContainer(new Ghost()) }
            };
    }
}
