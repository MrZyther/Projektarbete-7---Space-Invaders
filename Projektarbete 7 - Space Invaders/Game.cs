class Game
{
    public void Start()
    {
        Map map = new Map(15, 15);
        Position playerPosition = new Position(7, 14, 15, 15);
        Player player = new Player(
         new PlayerMovement(), new PlayerCannon(),
         playerPosition, 3, 'U');
        Position[] positions =
        [
         new Position(4, 2, 15, 15),
 new Position(7, 2, 15, 15),
 new Position(10, 2, 15, 15)
        ];
        EnemyMovement enemyMovement = new EnemyMovement(positions);
        // Subtypspolymorfism: samlingen rymmer tre konkreta IEnemy-typer.
        IEnemy[] enemies =
        [
         new BasicEnemy(enemyMovement, new RegularEnemyCannon(),
 positions[0], 1, 'E'),
 new ArmoredEnemy(enemyMovement, new BlasterCannon(),
 positions[1], 3, 'A'),
 new RapidfireEnemy(enemyMovement, new RapidfireCannon(),
 positions[2], 2, 'R')
        ];
        Wave wave = new Wave(enemies, enemyMovement);
        IControls playerControl = player;
        List<Bullet> playerBullets = [];
        List<Bullet> enemyBullets = [];
    }
}