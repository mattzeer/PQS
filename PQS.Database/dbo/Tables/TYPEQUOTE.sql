/* -----------------------------------------------------------------------------
      TABLE : TYPEQUOTE
----------------------------------------------------------------------------- */

create table TYPEQUOTE
  (
     CODE varchar(5)  not null  ,
     LABEL varchar(30)  null  
     ,
     constraint PK_TYPEQUOTE primary key (CODE)
  )