CREATE DATABASE SENAI_HROADS_TARDE;
GO

USE SENAI_HROADS_TARDE;
GO

INSERT INTO TipoHabilidade (NomeTipo)
VALUES ('Ataque'),('Defesa'),('Cura'),('Magia');
GO

SELECT * FROM Classe;
GO

INSERT INTO Habilidade (IdTipoHabilidade, NomeHabilidade)
VALUES (1,'Lança Mortal'),(2,'Escudo Supremo'),(3,'Recuperar Vida');
GO

INSERT INTO Classe (NomeClasse)
VALUES ('Bárbaro'),('Cruzado'),('Caçadora de Demônios'),('Monge'),('Necromancer'),('Feiticeiro'),('Arcanista');
GO

SELECT * FROM classe;

UPDATE classe set nomeClasse = 'Necromancer'
WHERE idClasse = 5

INSERT INTO classe_habilidade (idClasse, idHabilidade)
VALUES (1,1),(1,2),(2,2),(3,1),(4,3),(4,2),(5,NULL),(6,3),(7,NULL);
GO

INSERT INTO Personagem (IdClasse, NomePersonagem, VidaMax, ManaMax, DataCriacao, DataAtualizacao)
VALUES (1,'DeuBug',100,80,'18/01/2019', GETDATE()),(4,'BitBug',70,100,'17/03/2016',GETDATE()),
(7,'Fer8',75,60,'18/03/2018',GETDATE());

SELECT * FROM personagem;

UPDATE personagem set nomePersonagem = 'Fer7'
WHERE idPersonagem = 3

INSERT INTO TipoUsuario(Titulo)
VALUES ('ADMINISTRADOR'), ('JOGADOR');
GO

INSERT INTO Usuario(IdTipoUsuario, Email, Senha)
VALUES (1, 'administrador@adm.com', 'adm123'), (2, 'jogador@jogador.com', 'jogador123');
GO