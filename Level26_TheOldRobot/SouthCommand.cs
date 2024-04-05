public class SouthCommand : RobotCommand {
    public SouthCommand() : base() { }

    public override void Run(Robot robot) {
        if (robot.IsPowered == true) {
            robot.Y -= 1;
        }
    }
}

