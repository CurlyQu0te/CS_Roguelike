using RLNET;
 
namespace RogueLike
{
  public class Game
  {
    private static readonly int _screenWidth = 100;
    private static readonly int _screenHeight = 70;
    private static RLRootConsole _rootConsole;

    private static readonly int _mapWidth = 80;
    private static readonly int _mapHeight = 48;
    private static RLConsole _mapConsole;

    private static readonly int _messageWidth = 80;
    private static readonly int _messageHeight = 11;
    private static RLConsole _messageConsole;

    private static readonly int _statusWidth = 20;
    private static readonly int _statusHeight = 70;
    private static RLConsole _statusConsole;

    private static readonly int _inventoryWidth = 80;
    private static readonly int _inventoryHeight = 11;
    private static RLConsole _inventoryConsole;
 
    public static void Main()
    {
      string fontFileName = "terminal8x8.png";
      string consoleTitle = "RougeSharp V3 Tutorial - Level 1";
      _rootConsole = new RLRootConsole( fontFileName, _screenWidth, _screenHeight, 
        8, 8, 1f, consoleTitle );
      _mapConsole = new RLConsole( _mapWidth, _mapHeight );
      _messageConsole = new RLConsole( _messageWidth, _messageHeight );
      _statusConsole = new RLConsole( _statusWidth, _statusHeight );
      _inventoryConsole = new RLConsole( _inventoryWidth, _inventoryHeight );
      _rootConsole.Update += OnRootConsoleUpdate;
      _rootConsole.Render += OnRootConsoleRender;
      _rootConsole.Run();
    }

    private static void OnRootConsoleUpdate( object sender, UpdateEventArgs e )
    {
      _mapConsole.SetBackColor( 0, 0, _mapWidth, _mapHeight, Colors.FloorBackground );
      _mapConsole.Print( 1, 1, "Map Console", RLColor.White );

      _messageConsole.SetBackColor( 0, 0, _messageWidth, _messageHeight, Swatch.DbDarkWater );
      _messageConsole.Print( 1, 1, "Message Console", RLColor.White );

      _statusConsole.SetBackColor( 0, 0, _statusWidth, _statusHeight, Swatch.DbDarkStone );
      _statusConsole.Print( 1, 1, "Status Console", RLColor.White );

      _inventoryConsole.SetBackColor( 0, 0, _inventoryWidth, _inventoryHeight, Swatch.DbDarkWood );
      _inventoryConsole.Print( 1, 1, "Inventory Console", RLColor.White );
    }

    private static void OnRootConsoleRender( object sender, UpdateEventArgs e )
    {
      RLConsole.Blit( _mapConsole, 0, 0, _mapWidth, _mapHeight, _rootConsole, 0, _inventoryHeight );
      RLConsole.Blit(_statusConsole, 0, 0, _statusWidth, _statusHeight, _rootConsole, _mapWidth, 0 );
      RLConsole.Blit(_messageConsole, 0, 0, _messageWidth, _messageHeight, _rootConsole, 0, _screenHeight - _messageHeight );
      RLConsole.Blit(_inventoryConsole, 0, 0, _inventoryWidth, _inventoryHeight, _rootConsole, 0, 0);
      _rootConsole.Draw();
    }
  }
}