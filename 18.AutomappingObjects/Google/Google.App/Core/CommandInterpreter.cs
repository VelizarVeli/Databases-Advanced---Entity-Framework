using System;
using Google.App.Core.Contracts;

namespace Google.App.Core
{
  public  class CommandInterpreter:ICommandInterpreter
  {
      private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] input)
        {
            throw new System.NotImplementedException();
        }
    }
}
