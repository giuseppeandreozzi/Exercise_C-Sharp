public class OffCommand : RobotCommand {
    public OffCommand() : base() { }

    public override void Run(Robot robot) {
        robot.IsPowered = false;
    }
}
