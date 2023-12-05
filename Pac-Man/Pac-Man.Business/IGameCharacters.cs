namespace Pac_Man.Business
{
    public interface IGameCharacters
    {
        MoveablesContainer Character { get; set; }
        Dictionary<string, MoveablesContainer> Ghosts { get; set; }
    }
}
