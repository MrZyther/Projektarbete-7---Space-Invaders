class Scoreboard
{
    private int score;

    public void AddPoints(int points)
    {
        score += points;
    }

    public void Draw()
    {
        Console.WriteLine($"Poäng: {score}");
    }
}