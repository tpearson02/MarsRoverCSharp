using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position)
        {
            this.Position = position;
            this.Mode = "NORMAL";
            this.GeneratorWatts = 110;

        }
        public void ReceiveMessage (Message message)
        {
            foreach(Command command in message.Commands)
            {
                if (command.NewMode == "LOW_POWER")
                {
                    this.Mode = command.NewMode;
                }
                else if (this.Mode == "NORMAL")
                {
                    this.Position = command.NewPosition;
                    this.Mode = command.NewMode;
                }
                
            }
        }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

    }
}
