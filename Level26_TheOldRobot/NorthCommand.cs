public class NorthCommand : RobotCommand {
    public NorthCommand() : base() { }

    public override void Run(Robot robot){
        if(robot.IsPowered == true){
            robot.Y += 1;
        }
    }
}
