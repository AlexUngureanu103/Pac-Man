using Pac_Man.Domain.Models;

namespace Pac_Man.Business
{
    public class GameCharacters : IGameCharacters
    {
        public MoveablesContainer Character { get; set; } = new MoveablesContainer(new Character());
        public Dictionary<string, MoveablesContainer> Ghosts { get; set; } = new Dictionary<string, MoveablesContainer>
            {
                { Domain.Ghosts.Blinky, new MoveablesContainer(new Ghost{Icon ="B"}) },
                { Domain.Ghosts.Pinky, new MoveablesContainer(new Ghost{Icon = "H"}) },
                { Domain.Ghosts.Inky, new MoveablesContainer(new Ghost{Icon = "I"}) },
                { Domain.Ghosts.Clyde, new MoveablesContainer(new Ghost{Icon = "C"}) }
            };
    }
}
