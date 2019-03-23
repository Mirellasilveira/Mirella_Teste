-- Cria a base de dados da aplica��o
CREATE DATABASE TesteAplicativoCarona;
GO

-- Muda o contexto da conex�o
USE TesteAplicativoCarona;
GO

---- Tabela de dados de motoristas
CREATE TABLE Motoristas
(
	Id INT IDENTITY PRIMARY KEY,
	Nome VARCHAR(255) NOT NULL,
	DataNascimento DATE NOT NULL,
	CPF VARCHAR(14) NOT NULL UNIQUE,
	ModeloCarro VARCHAR(255) NOT NULL,
	Sexo CHAR(1) NOT NULL,
	Status BIT NOT NULL DEFAULT 1
)
GO

---- Tabela de dados de passageiros
CREATE TABLE Passageiros
(
	Id INT IDENTITY PRIMARY KEY,
	Nome VARCHAR(255) NOT NULL,
	DataNascimento DATE NOT NULL,
	CPF VARCHAR(14) NOT NULL UNIQUE,
	Sexo CHAR(1) NOT NULL
)
GO

---- Tabela de dados de Corridas
-- * Id do motorista � chave extrangeira da tb Motoriastas
-- * Id do passageiro � chave extrangeira da tb Passageiros
-- * Constraint de corrida �nica de um motorista para um passageiro na mesma data
CREATE TABLE Corridas
(
	IdCorrida INT identity PRIMARY KEY,
	IdMotorista INT FOREIGN KEY REFERENCES Motoristas(Id) NOT NULL,
	IdPassageiro INT FOREIGN KEY REFERENCES Passageiros(Id) NOT NULL,
	DataCorrida DATETIME NOT NULL DEFAULT GETDATE(),
	Valor DECIMAL(18,2) NOT NULL,
	CONSTRAINT UC_Corrida UNIQUE (IdMotorista, IdPassageiro, DataCorrida)
)
GO