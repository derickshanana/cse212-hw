/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left. If you can, then move. If you can't, throw an exception.
    /// </summary>
    public void MoveLeft()
    {
        var currentPos = (_currX, _currY);
        if (_mazeMap.TryGetValue(currentPos, out var directions) && directions[0])
        {
            _currX -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right. If you can, then move. If you can't, throw an exception.
    /// </summary>
    public void MoveRight()
    {
        var currentPos = (_currX, _currY);
        if (_mazeMap.TryGetValue(currentPos, out var directions) && directions[1])
        {
            _currX += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up. If you can, then move. If you can't, throw an exception.
    /// </summary>
    public void MoveUp()
    {
        var currentPos = (_currX, _currY);
        if (_mazeMap.TryGetValue(currentPos, out var directions) && directions[2])
        {
            _currY -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down. If you can, then move. If you can't, throw an exception.
    /// </summary>
    public void MoveDown()
    {
        var currentPos = (_currX, _currY);
        if (_mazeMap.TryGetValue(currentPos, out var directions) && directions[3])
        {
            _currY += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
