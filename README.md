Вопрос 1.
Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. 

Код и тесты в проектах AreaCalculator и UnitTests.
Реализовал код для трёх фигур - треугольника, круга и произвольного N-угольника(полигон).
Если пользователю библиотеки нужна будет информацич по площади какой-то aигуры,то он может созадть экземпляр нужного типа и узнать площадь

Вопрос №2
Допустим, что мы условный DNS, который продаёт разные товары, предварительно поделив все продукты по категориям.
Тогда это выглядело бы так.
SQL запросы по заданию 2

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL
);

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);

CREATE TABLE ProductCategories (
    ProductID INT,
    CategoryID INT,
    PRIMARY KEY (ProductID, CategoryID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

INSERT INTO Products
VALUES (1, 'Картофель'), (2, 'Porsche 911'), (3, 'Квартира'), (4, 'Швабра');

INSERT INTO Categories
VALUES (1, 'Пища'), (2, 'Недвижимость'), (3, 'Инвестиция'), (4, 'Раритет'), (5, 'Приспособление для детей');

INSERT INTO ProductCategories
VALUES (1, 1), (2, 3), (2, 4), (3, 2), (3, 3);

SELECT p.ProductName, c.CategoryName
FROM Products p
LEFT JOIN ProductCategories pc ON p.ProductID = pc.ProductID
LEFT JOIN Categories c ON pc.CategoryID = c.CategoryID;

Вывод будет следующий

"Картофель"  	"Пища"
"Porsche 911" 	"Инвестиция"
"Porsche 911"	"Раритет"
"Квартира"   	"Недвижимость"
"Квартира"	    "Инвестиция"
"Швабра"	     null
