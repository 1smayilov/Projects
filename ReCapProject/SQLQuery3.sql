create database ReCapProject
use ReCapProject
CREATE TABLE Cars (
    CarID INT PRIMARY KEY IDENTITY(1,1),
    BrandId INT NOT NULL,
    ColorId INT NOT NULL,
    ModelYear INT NOT NULL,
    DailyPrice DECIMAL(18, 2) NOT NULL,
    Description NVARCHAR(255)
);

create table Brands (
	BrandId int primary key identity(1,1),
	Name Nvarchar(255) 
)

create table Colors 
(
	ColorId int primary key identity(1,1),
	name nvarchar(255)
)

INSERT INTO Cars (BrandId, ColorId, ModelYear, DailyPrice, Description)
VALUES 
(1, 1, 2015, 550.00, 'BMW M5'),
(2, 2, 2015, 500.00, 'Mercedes CLS AMG'),
(3, 3, 2018, 600.00, 'Audi A6'),
(4, 4, 2020, 700.00, 'Tesla Model S'),
(5, 5, 2019, 650.00, 'Volvo XC90');

insert into Brands (Name)
Values
('BMW'),
('Mercedes'),
('Audi'),
('Tesla'),
('Volvo');

INSERT INTO Colors (Name)
VALUES 
('Qýrmýzý'),
('Göy'),
('Yaþýl'),
('Qara'),
('Að');
