/*      INDEX DE QUOTE      */



/* -----------------------------------------------------------------------------
      TABLE : PERSON
----------------------------------------------------------------------------- */

create table PERSON
  (
     ID smallint identity (1, 1)   ,
     PSEUDO varchar(30)  null  ,
     PASSWORD varchar(255)  null  ,
     MAIL varchar(100)  null  
     ,
     constraint PK_PERSON primary key (ID)
  )