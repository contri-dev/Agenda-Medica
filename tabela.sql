create database consultorio	
use consultorio

create table ficha
(cd_fic				int					not null	primary key,
 nm_fic					varchar(64)			not null,
 alt_fic				float				not null,
 diag_fic				varchar(64)			not null,
 nasc_fic				date				not null);

select*from ficha;
 

 