/*create tabele for categories*/
CREATE TABLE IF NOT EXISTS "Category" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL,
	PRIMARY KEY("Id" AUTOINCREMENT)
);

/*create table for products*/
CREATE TABLE IF NOT EXISTS "Product" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL,
	PRIMARY KEY("Id" AUTOINCREMENT)
);

/*create multiple to multiple relation*/
CREATE TABLE IF NOT EXISTS "ProductToCategory" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"ProductId"	INTEGER NOT NULL,
	"CategoryId"	INTEGER NOT NULL,
	PRIMARY KEY("Id" AUTOINCREMENT)
);

/*contain categories*/
INSERT INTO "Category" VALUES (1,'Eat');
INSERT INTO "Category" VALUES (2,'Adult');
INSERT INTO "Category" VALUES (3,'Drink');
INSERT INTO "Category" VALUES (4,'Children');
INSERT INTO "Category" VALUES (5,'Vegetables');
INSERT INTO "Category" VALUES (6,'Fruit');
INSERT INTO "Category" VALUES (7,'Milk');
INSERT INTO "Category" VALUES (8,'Toy');

/*contain products*/
INSERT INTO "Product" VALUES (1,'Milk');
INSERT INTO "Product" VALUES (2,'Beer');
INSERT INTO "Product" VALUES (3,'Orange juce');
INSERT INTO "Product" VALUES (4,'Carrot');
INSERT INTO "Product" VALUES (5,'Apple mash');
INSERT INTO "Product" VALUES (6,'Knife');

/*contain relations*/
INSERT INTO "ProductToCategory" VALUES (1,1,2);
INSERT INTO "ProductToCategory" VALUES (2,1,3);
INSERT INTO "ProductToCategory" VALUES (3,1,4);
INSERT INTO "ProductToCategory" VALUES (4,1,7);
INSERT INTO "ProductToCategory" VALUES (5,2,2);
INSERT INTO "ProductToCategory" VALUES (6,2,3);
INSERT INTO "ProductToCategory" VALUES (7,3,2);
INSERT INTO "ProductToCategory" VALUES (8,3,3);
INSERT INTO "ProductToCategory" VALUES (9,3,4);
INSERT INTO "ProductToCategory" VALUES (10,3,6);
INSERT INTO "ProductToCategory" VALUES (11,4,1);
INSERT INTO "ProductToCategory" VALUES (12,4,2);
INSERT INTO "ProductToCategory" VALUES (13,4,4);
INSERT INTO "ProductToCategory" VALUES (14,4,5);
INSERT INTO "ProductToCategory" VALUES (15,5,1);
INSERT INTO "ProductToCategory" VALUES (16,5,3);
INSERT INTO "ProductToCategory" VALUES (17,5,6);

/*SQL request for all pairs product-category include product without category*/
SELECT Product.Name, Category.Name
FROM Product
LEFT JOIN ProductToCategory ON Product.Id == ProductToCategory.ProductId
LEFT JOIN Category ON ProductToCategory.CategoryId == Category.Id
