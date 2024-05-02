using System.Dynamic;
using SplashKitSDK;


public class Player
{
    private Bitmap _playerBitmap;
    public double x { get; private set; }
    public double y { get; private set; }

    public bool Quit { get; private set; } = false;

    public int Width
    {
        get
        {
            return _playerBitmap.Width;
        }
    }
    public int Height
    {
        get
        {
            return _playerBitmap.Height;
        }
    }

    public Player(Window gameWindow)
    {
        _playerBitmap = new Bitmap("Player", "Player.png");

        x = (gameWindow.Width - Width) / 2;
        y = (gameWindow.Height - Height) / 2;
    }

    public void Draw()
    {
        _playerBitmap.Draw(x, y);
    }

    private const int Speed = 5;
    public void HandleInput()
    {
        Quit = SplashKit.KeyDown(KeyCode.EscapeKey);

        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            x -= Speed;
        }

        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            x += Speed;
        }

        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            y -= Speed;
        }

        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            y += Speed;
        }


    }

    private const int GAP = 10;

    public void StayOnWindow(Window limit)
    {

        if (x < GAP)
        {
            x = GAP;
        }
        else if (x + Width > limit.Width - GAP)
        {
            x = limit.Width - Width - GAP;
        }
        if (y < GAP)
        {
            y = GAP;
        }
        else if (y + Height > limit.Height - GAP)
        {
            y = limit.Height - Height - GAP;
        }

    }

    public bool CollidedWith(Robot other)
    {
        return _playerBitmap.CircleCollision(x, y, other.CollisionCircle);
    }

}