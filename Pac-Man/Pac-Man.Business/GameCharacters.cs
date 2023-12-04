using Pac_Man.Domain.Models;

namespace Pac_Man.Business
{
    public class GameCharacters : IGameCharacters
    {
        public MoveablesContainer Character { get; set; } = new MoveablesContainer(new Character());
        public Dictionary<string, MoveablesContainer> Ghosts { get; set; } = new Dictionary<string, MoveablesContainer>
            {
                { "Blinky", new MoveablesContainer(new Ghost{Icon ="B"}) },
                { "Pinky", new MoveablesContainer(new Ghost{Icon = "P"}) },
                { "Inky", new MoveablesContainer(new Ghost{Icon = "I"}) },
                { "Clyde", new MoveablesContainer(new Ghost{Icon = "C"}) }
            };
    }
}
