USE SENAI_HROADS_TARDE;
GO

-- Selecionar todos os personagens;

SELECT * FROM personagem;
GO

-- Selecionar todos as classes;

SELECT * FROM classe;
GO

-- Selecionar somente o nome das classes;

SELECT nomeClasse AS Classe FROM classe;
GO

-- Selecionar todas as habilidades;

SELECT * FROM habilidade;
GO

-- Selecionar somente os id’s das habilidades classificando-os por ordem crescente;

SELECT idHabilidade AS id FROM habilidade;
GO

-- Selecionar todos os tipos de habilidades;

SELECT * FROM tipoHabilidade;
GO

-- Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte;

SELECT * FROM habilidade
LEFT JOIN tipoHabilidade
ON habilidade.idTipo = tipoHabilidade.idTipo;
GO

-- Selecionar todos os personagens e suas respectivas classes;

SELECT * FROM personagem
INNER JOIN classe
ON personagem.idClasse = classe.idClasse;
GO

-- Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens);

SELECT * FROM personagem
FULL OUTER JOIN classe
ON personagem.idClasse = classe.idClasse;
GO

-- Selecionar todas as classes e suas respectivas habilidades;

SELECT nomeClasse AS Classe, nomeHabilidade AS Habilidade FROM classe
INNER JOIN classe_habilidade
ON classe.idClasse  = classe_habilidade.idClasse
INNER JOIN habilidade
ON habilidade.idHabilidade = classe_habilidade.idHabilidade;
GO 

-- Selecionar todas as habilidades e suas classes (somente as que possuem correspondência);

SELECT nomeHabilidade AS Habilidade, nomeClasse AS Classe FROM habilidade
LEFT JOIN classe_habilidade
ON habilidade.idHabilidade = classe_habilidade.idHabilidade
LEFT JOIN classe
ON classe.idClasse = classe_habilidade.idClasse;
GO

-- Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).

SELECT nomeHabilidade AS Habilidade, nomeClasse AS Classe FROM habilidade
LEFT JOIN classe_habilidade
ON habilidade.idHabilidade = classe_habilidade.idHabilidade
FULL OUTER JOIN classe
ON classe.idClasse = classe_habilidade.idClasse;
GO

-- Realizar a contagem de quantas habilidades estão cadastradas;

SELECT COUNT(*) AS NumeroDeHabilidades FROM habilidade
GO