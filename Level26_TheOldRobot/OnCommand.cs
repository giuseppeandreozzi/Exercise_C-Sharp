public class OnCommand : RobotCommand {
    public OnCommand() : base() { }

    public override void Run(Robot robot) {
        robot.IsPowered = true;
    }
}
