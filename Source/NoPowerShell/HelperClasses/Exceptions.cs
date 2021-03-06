﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NoPowerShell.HelperClasses
{
    class NoPowerShellException : Exception
    {
        public NoPowerShellException() : base()
        {
        }

        public NoPowerShellException(string message) : base(message)
        {
        }
    }

    class CommandNotFoundException : NoPowerShellException
    {
        public string Command { get; set; }
        public override string Message => string.Format("{0} : The term '{0}' is not recognized as the name of a cmdlet.", Command);

        public CommandNotFoundException(string command) : base()
        {
            Command = command;
        }
    }

    class ParameterBindingException : CommandNotFoundException
    {
        public string Parameter { get; set; }
        public override string Message => string.Format("{0} : A parameter cannot be found that matches parameter name '{1}'.", Command, Parameter);

        public ParameterBindingException(string command, string parameter) : base(command)
        {
            Parameter = parameter;
        }
    }

    class ItemNotFoundException : NoPowerShellException
    {
        public string Path { get; set; }
        public override string Message => string.Format("Cannot find path '{0}' because it does not exist.", Path);

        public ItemNotFoundException(string path) : base()
        {
            Path = path;
        }
    }
}
