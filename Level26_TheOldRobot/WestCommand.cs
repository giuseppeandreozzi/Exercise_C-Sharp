public class WestCommand : RobotCommand {
    public WestCommand() : base() { }

    public override void Run(Robot robot) {
        if (robot.IsPowered == true) {
            robot.X -= 1;
        }
    }
}
