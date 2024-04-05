public class EastCommand : RobotCommand {
    public EastCommand() : base() { }

    public override void Run(Robot robot) {
        if (robot.IsPowered == true) {
            robot.X += 1;
        }
    }
}
