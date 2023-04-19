using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommandBase : MonoBehaviour 
{
	private string _commandId;
	private string _commandDescription;
	private string _commandFormat;
	private bool _commandIsGenerated;

	public string commandId { get { return _commandId; } }
	public string commandDescription { get { return _commandDescription; } }
	public string commandFormat { get { return _commandFormat; } }
	public bool commandIsGenerated { get { return _commandIsGenerated; } }


	public DebugCommandBase (string id, string description, string format,bool commandIsGenerated)
    {
		_commandId = id;
		_commandDescription = description;
		_commandFormat = format;
		_commandIsGenerated = commandIsGenerated;

	}

}

public class DebugCommand : DebugCommandBase
{
	public  Action command;
	
	public DebugCommand(string id, string description, string format, Action command) : base(id, description, format,false)
    {
		this.command = command;

    }

	public void Invoke()
    {
		command.Invoke();
    }

}

public class DebugCommand<T1> : DebugCommandBase
{
	public Action<T1> command;

	public DebugCommand(string id, string description, string format, Action<T1> command) : base(id, description, format,true)
	{
		this.command = command;
	}

	public void Invoke(T1 value)
	{
		command.Invoke(value);
	}

}


