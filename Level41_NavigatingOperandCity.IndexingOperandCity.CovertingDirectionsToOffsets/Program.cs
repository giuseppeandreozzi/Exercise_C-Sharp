BlockCoordinate coordinate = new BlockCoordinate(2, 4);
BlockOffset offset = new BlockOffset(1, 1);
BlockCoordinate firstSum = coordinate + offset;
BlockCoordinate secondSum = coordinate + Direction.South;

Console.WriteLine("I will sum these two object: " + coordinate + " and " + offset + " = " + firstSum);
Console.WriteLine("Now I will sum these two object: " + coordinate + " and " + Direction.South + " = " + secondSum);

Console.WriteLine("Row: " + coordinate[0] + " Column: " + coordinate[1]);

BlockCoordinate thirdSum = coordinate + (BlockOffset) Direction.West;
Console.WriteLine("I will sum these two object: " + coordinate + " and " + Direction.West + " = " + thirdSum);

public record BlockCoordinate(int Row, int Column) {
    public int this[int index] {
        get {
            if (index == 0)
                return Row;
            else
                return Column;
        }
    }
    public static BlockCoordinate operator +(BlockCoordinate x, BlockOffset y) {
        return new BlockCoordinate(x.Row + y.RowOffset, x.Column + y.ColumnOffset);
    }

    public static BlockCoordinate operator +(BlockCoordinate x, Direction y) {

        return y switch {
            Direction.South => new BlockCoordinate(x.Row + 1, x.Column),
            Direction.North => new BlockCoordinate(x.Row - 1, x.Column),
            Direction.East => new BlockCoordinate(x.Row, x.Column + 1),
            Direction.West => new BlockCoordinate(x.Row, x.Column - 1),
            _ => throw new ArgumentException("Invalid direction")
        }; 
        
    }
}
public record BlockOffset(int RowOffset, int ColumnOffset) {
    public static explicit operator BlockOffset(Direction direction) {
        return direction switch {
            Direction.North => new BlockOffset(-1, 0),
            Direction.South => new BlockOffset(1, 0),
            Direction.East => new BlockOffset(0, 1),
            Direction.West => new BlockOffset(0, -1),
            _ => throw new ArgumentException("Invalid direction")
        };
    }
}
public enum Direction { North, East, South, West }
