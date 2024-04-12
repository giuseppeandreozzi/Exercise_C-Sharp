using System.Data;

public class Grid {
    public (int width, int heigth) sizeGrid { get; set; } = (4, 4);
    public (int x, int y) positionFountain { get; set; } = (0, 2);
    public (int x, int y) positionPlayer { get; set; } = (0, 0);
    public bool fountainState { get; set; } = false;

    public bool MovePlayer(string direction) {
        if (direction == "north") {
            if (positionPlayer.x - 1 < 0)
                return false;

            positionPlayer = (positionPlayer.x - 1, positionPlayer.y);
        } else if (direction == "west") {
            if (positionPlayer.y - 1 < 0)
                return false;

            positionPlayer = (positionPlayer.x, positionPlayer.y - 1);
        } else if (direction == "east") {
            if (positionPlayer.y + 1 > sizeGrid.width)
                return false;

            positionPlayer = (positionPlayer.x, positionPlayer.y + 1);
        } else if (direction == "west") {
            if (positionPlayer.y - 1 < 0)
                return false;

            positionPlayer = (positionPlayer.x, positionPlayer.y - 1);
        } else if (direction == "south") {
            if (positionPlayer.x + 1 > sizeGrid.heigth)
                return false;

            positionPlayer = (positionPlayer.x + 1, positionPlayer.y);
        }

        return true;
    }

    public bool CheckWin() {
        return fountainState == true && positionPlayer == (0, 0);
    }
}
