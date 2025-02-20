﻿namespace MessengerApp.Model;

public class Chat
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string ChatName { get; set; }
    public List<PersonsInChat>? PersonsInChat { get; set; }
    public List<MessagesInChat>? MessagesInChats { get; set; }
}
