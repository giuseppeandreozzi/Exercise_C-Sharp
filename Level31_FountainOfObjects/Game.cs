public abstract class Grid {
    public (int width, int heigth) sizeGrid { get; set; }
    public (int x, int y) positionFountain { get; set; }
    public (int x, int y)[] pits { get; set; }
}

public class GridSmall : Grid {
    public GridSmall() {
        sizeGrid = (4, 4);
        positionFountain = (0, 2);
        pits = [(2, 2)];
    }
}

public class GridMedium : Grid {
    public GridMedium() {
        sizeGrid = (6, 6);
        positionFountain = (2, 4);
        pits = [(2, 2), (4, 3)];
    }
}

public class GridLarge : Grid {
    public GridLarge() {
        sizeGrid = (8, 8);
        positionFountain = (4, 6);
        pits = [(2, 2), (4, 3), (6, 6), (3, 3)];
    }
}

public class Game {
    private Grid grid;
    public (int x, int y) positionPlayer { get; set; } = (0, 0);
    public bool fountainState { get; set; } = false;

    public Game() {

    }
    public Game (Grid grid) {
        this.grid = grid;
    }

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
            if (positionPlayer.y + 1 > grid.sizeGrid.width)
                return false;

            positionPlayer = (positionPlayer.x, positionPlayer.y + 1);
        } else if (direction == "west") {
            if (positionPlayer.y - 1 < 0)
                return false;

            positionPlayer = (positionPlayer.x, positionPlayer.y - 1);
        } else if (direction == "south") {
            if (positionPlayer.x + 1 > grid.sizeGrid.heigth)
                return false;

            positionPlayer = (positionPlayer.x + 1, positionPlayer.y);
        }

        return true;
    }

    public bool CheckWin() {
        return fountainState == true && positionPlayer == (0, 0);
    }

    public (int x, int y) GetPositionFountain() {
        return grid.positionFountain;
    }

    public bool CheckPits() {
        foreach ((int row, int column) positionPit in grid.pits)
        {
            if (positionPlayer == positionPit)
                return true;
        }

        return false;
    }

    public bool CheckAdjacentRoomsForPits() {
        (int row, int columns)[] adjacentRooms = [(positionPlayer.x - 1, positionPlayer.y), (positionPlayer.x + 1, positionPlayer.y), (positionPlayer.x, positionPlayer.y - 1), (positionPlayer.x, positionPlayer.y + 1),
                                                (positionPlayer.x - 1, positionPlayer.y + 1), (positionPlayer.x - 1, positionPlayer.y - 1), (positionPlayer.x + 1, positionPlayer.y + 1), (positionPlayer.x + 1, positionPlayer.y - 1)];

        foreach(var positionPit in grid.pits) {
            foreach(var positionAdjacentRooms in adjacentRooms) {
                if (positionPit == positionAdjacentRooms)
                    return true;
            }
        }

        return false;
    }
}
