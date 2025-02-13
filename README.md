# __Таблицы в бд__

* Users

  id(Guid) | Login(TEXT) | Password(TEXT) | PersonId(GUID)
  -- | -- | -- | --

* Persons

  id(Guid) | Name(TEXT) | Surname(TEXT)
  -- | -- | -- 

* Chats

  id(Guid) | Name(TEXT) 
  -- | -- 

* Messeges

  id(Guid) | Content(TEXT) 
  -- | -- 

## __Таблицы связей в бд__

* PersonsInChat(_список людей в чате_)

  PersonId(Guid) | ChatId(Guid)
  -- | -- 

* MessegesInChat(_сообщения в чате_)

  ChatId(Guid) | MessegesId(Guid)
  -- | -- 
