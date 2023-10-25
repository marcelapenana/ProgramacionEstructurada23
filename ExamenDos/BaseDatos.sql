create database diferido_exa2;
use diferido_exa2;

create table notasEstudiantes(
 ID int identity(1,1) primary key,
carnet_estudiante int,
nombre_completo varchar(200),
nombre_materia varchar(200),
nota_materia float (3)
);

select*from notasEstudiantes;
insert into notasEstudiantes values(0235, 'Sandra Patricia Nájera Sánchez','Matematica','7.3' ),
                                   (2844, 'Oscar Alberto Hernández Nájera','Matematica','9.3' ),
                                   (2844, 'Marcela Beatriz Peña Nájera','Matematica','9.3' ) ;
                             
