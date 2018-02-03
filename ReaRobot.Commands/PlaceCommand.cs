using ReaRobot.Model;

namespace ReaRobot.Commands
{
    public class PlaceCommand : AbstractBaseCommand
    {
        private readonly Configuration configuration;

        public PlaceCommand(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public PlaceCommand(int x,int y,Direction direction) : this(new Configuration(x,y,direction))
        {
        }
      
        protected override Configuration ApplyInternal(Configuration input)
        {
            return configuration;
        }
    }
}
