/* -----------------------------------------------------------------------------
      TABLE : ATTACHMENT
----------------------------------------------------------------------------- */

create table ATTACHMENT
  (
     ID smallint identity (1, 1)   ,
     NAME varchar(30)  null  ,
     URL varchar(4000)  null  
     ,
     constraint PK_ATTACHMENT primary key (ID)
  )