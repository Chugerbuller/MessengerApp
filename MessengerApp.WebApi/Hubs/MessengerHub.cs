﻿using MessengerApp.DAL;
using MessengerApp.Model;
using MessengerApp.WebApi.Helpers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace MessengerApp.WebApi.Hubs;

public class MessengerHub : Hub
{
    private readonly MessengerDbContext _dbContext;
    private readonly MethodsHelper _messageDictionary;
    public MessengerHub(MessengerDbContextFactory dbContextFactory)
    {
        _messageDictionary = new MethodsHelper();

        _dbContext = dbContextFactory.CreateDbContext();
    }
    public async Task EnterInMessenger(Guid personId)
    {
        var chats = await _dbContext.PersonsInChat.
            Where(pic => pic.PersonId == personId).
            ToListAsync();

        foreach (var chat in chats) 
            await Groups.AddToGroupAsync(Context.ConnectionId, chat.ChatId.ToString());
        
    }
    public async Task SendMsg(MessagesInChat message)
    {
        await _dbContext.MessagesInChat.AddAsync(message);
        await _dbContext.SaveChangesAsync();

        await Clients.Group(message.ChatId.ToString())
                     .SendAsync(_messageDictionary.MethodsMap[Methods.ReciveMsg], message);
    }
}
