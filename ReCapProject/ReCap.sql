use ReCap

CREATE TABLE Car
(
    Id int,
    BrandId int,
    ColorId int,
    ModelYear int,
    DailyPrice int,
    [Description] varchar(50)
);

CREATE TABLE Brand
(
    Id int,
    [Name] varchar(50)
);

CREATE TABLE Color
(
    Id int,
    [Name] varchar(50)
);
INSERT INTO Car (Id, BrandId, ColorId, ModelYear, DailyPrice, [Description])
VALUES 
(1, 1, 1, 2020, 100, 'Sedan'),
(2, 2, 2, 2019, 150, 'SUV'),
(3, 3, 3, 2021, 200, 'Coupe');

INSERT INTO Brand (Id, [Name])
VALUES 
(1, 'Toyota'),
(2, 'Ford'),
(3, 'BMW');

INSERT INTO Color (Id, [Name])
VALUES 
(1, 'Red'),
(2, 'Blue'),
(3, 'Black');


