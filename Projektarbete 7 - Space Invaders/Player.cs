internal sealed class Player(IControls movement, ICannon cannon, Position start)
    : Ship(movement, cannon, start, 3, 'O')
{
}
