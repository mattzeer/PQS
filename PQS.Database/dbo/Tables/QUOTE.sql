/* -----------------------------------------------------------------------------
      TABLE : QUOTE
----------------------------------------------------------------------------- */

create table QUOTE
  (
     ID smallint identity (1, 1)   ,
     IDUSER smallint  not null  ,
     CODE varchar(5)  not null  ,
     IDATTACHMENT smallint  null  ,
     NAME varchar(50)  null  ,
     CAPTION char(300)  null  
     ,
     constraint PK_QUOTE primary key (ID)
  )
GO
/* -----------------------------------------------------------------------------
      REFERENCES SUR LES TABLES
----------------------------------------------------------------------------- */



alter table QUOTE 
     add constraint FK_QUOTE_PERSON foreign key (IDUSER) 
               references PERSON (ID)
GO
alter table QUOTE 
     add constraint FK_QUOTE_TYPEQUOTE foreign key (CODE) 
               references TYPEQUOTE (CODE)
GO
alter table QUOTE 
     add constraint FK_QUOTE_ATTACHMENT foreign key (IDATTACHMENT) 
               references ATTACHMENT (ID)