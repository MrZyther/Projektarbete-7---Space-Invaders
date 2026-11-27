internal sealed class Scoreboard
{
    private int score;
    private int waveNumber;

    internal void StartWave()
    {
        waveNumber++;
    }

    internal void AddPoints(int points)
    {
        score += points;
    }

    internal void Draw()
    {
        Console.WriteLine($"Våg: {waveNumber}   Poäng: {score}");
    }
}
