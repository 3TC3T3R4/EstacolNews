# EstacolNews

## Description
Se hace entrega de una aplicacion orientada a la creacion de Noticias o Articulos, de parte del Editor el cual puede auto gestionar y compartir con redes sociales su contenido

## Diagrama UML
![image](https://user-images.githubusercontent.com/101427427/232625977-77b716d5-fbfd-4f75-bd90-308a04598848.png)
![image](https://user-images.githubusercontent.com/101427427/232626096-fc89bc49-3059-44d9-a8af-00a23749b9b4.png)

## DataBase

CREATE DATABASE EstacolNews;
use  EstacolNews;


CREATE TABLE Editor (
--id_editor int IDENTITY PRIMARY KEY NOT NULL,
id_editor varchar(50)PRIMARY KEY,
complete_name varchar(100),
--phone varchar(11) NOT NULL,
estate bit NOT NULL,
);

CREATE TABLE Content(
id_content int IDENTITY PRIMARY KEY NOT NULL,
title varchar(50) ,
estate_process varchar(50) ,
estate bit ,
keywords varchar(50),
type_publication varchar (30) ,
url varchar(100) ,
finish_date DateTime ,
publication_date DATETIME ,
program_date DATETIME ,
number_of_collaborators int ,
likes int,
dislikes int,
number_of_share int, 
description varchar(1000)

);

CREATE TABLE Publication(
id_publication int IDENTITY PRIMARY KEY NOT NULL,
id_editor_publication varchar(50),
id_content_publication int ,
estate bit ,
CONSTRAINT Fk_IdEditor
FOREIGN KEY(id_editor_publication)
REFERENCES Editor(id_editor),
CONSTRAINT Fk_IdContent
FOREIGN KEY(id_content_publication)
REFERENCES Content(id_content)

);

