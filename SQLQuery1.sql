--Create tables

--CREATE TABLE Clients (
--    RefClient INT PRIMARY KEY IDENTITY(1,1),
--    Nom NVARCHAR(100),
--    Telephone NVARCHAR(20),
--    Adresse NVARCHAR(255)
--);


--CREATE TABLE Pizzas (
--    Id INT PRIMARY KEY IDENTITY(1,1),
--    Nom NVARCHAR(100),
--    Prix DECIMAL(5,2)
--);


--CREATE TABLE Tailles (
--    Id INT PRIMARY KEY IDENTITY(1,1),
--    Nom NVARCHAR(50),
--    Ratio FLOAT
--);


--CREATE TABLE Croutes (
--    Id INT PRIMARY KEY IDENTITY(1,1),
--    Nom NVARCHAR(50),
--    Prix DECIMAL(5,2)
--);


--CREATE TABLE Garnitures (
--    Id INT PRIMARY KEY IDENTITY(1,1),
--    Nom NVARCHAR(100),
--    Prix DECIMAL(5,2)
--);


--Insertion data

INSERT INTO Clients (Nom, Telephone, Adresse) VALUES
('Bill Gates', '123', '1124 St-Laurent, Montreal'),
('Sophie Cote', '321', '298 Beaubien, Montreal');

INSERT INTO Pizzas (Nom, Prix) VALUES
('L''Italienne', 12.00),
('La Hawaienne', 10.00),
('La Mexicaine', 11.00),
('La Quebecoise', 13.00),
('La Toute Garnie', 14.00);

INSERT INTO Tailles (Nom, Ratio) VALUES
('Petite', 1),
('Moyenne', 1.5),
('Grande', 2);

INSERT INTO Croutes (Nom, Prix) VALUES
('Mince', 0),
('Normale', 1),
('Epaisse', 2);

INSERT INTO Garnitures (Nom, Prix) VALUES
('Bacon Jambon (2$)', 2.00),
('Extra Fromage (2.5$)', 2.50),
('Peperoni Halal (2.75$)', 2.75),
('Champignons (3$)', 3.00);
