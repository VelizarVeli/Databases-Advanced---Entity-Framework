using System;
using System.Linq;
using TeamBuilder.App.Core;
using TeamBuilder.App.Core.Command;

namespace TeamBuilder.App
{
    public class CommandDispatcher
    {
        private readonly AuthenticationManager _authManager;

        public CommandDispatcher(AuthenticationManager authManager)
        {
            this._authManager = authManager;
        }

        public string Dispatch(string input)
        {
            string[] args = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = args.Length > 0 ? args[0] : string.Empty;

            string[] commandArgs = args.Skip(1).ToArray();

            switch (commandName)
            {
                case "Exit":
                    ExitCommand exitCommand = new ExitCommand();
                    return exitCommand.Execute(new string[0]);
                case "RegisterUser":
                    RegisterUserCommand registerUserCommand = new RegisterUserCommand(_authManager);
                    return registerUserCommand.Execute(commandArgs);
                case "Login":
                    LoginCommand loginCommand = new LoginCommand(this._authManager);
                    return loginCommand.Execute(commandArgs);
                case "Logout":
                    LogoutCommand logoutCommand = new LogoutCommand(this._authManager);
                    return logoutCommand.Execute(commandArgs);
                case "DeleteUser":
                    DeleteUserCommand deleteUserCommand = new DeleteUserCommand(this._authManager);
                    return deleteUserCommand.Execute(commandArgs);

                default:
                    throw new NotSupportedException($"Command {commandName} not supported!");
            }
        }
    }
}
