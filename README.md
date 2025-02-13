# __Таблицы в бд__

1.Users

  id(Guid) | Login(TEXT) | Password(TEXT) | PersonId(GUID)
  -- | -- | -- | --

2.Persons

  id(Guid) | Name(TEXT) | Surname(TEXT)
  -- | -- | -- 

3.Chats

  id(Guid) | Name(TEXT) 
  -- | -- 

4.Messeges

  id(Guid) | Content(TEXT) 
  -- | -- 

## __Таблицы связей в бд__

1.PersonsInChat(_список людей в чате_)

  PersonId(Guid) | ChatId(Guid)
  -- | -- 

2.MessegesInChat(_сообщения в чате_)

  ChatId(Guid) | MessegesId(Guid)
  -- | -- 
