CREATE TABLE Category(
	idCategory INT PRIMARY KEY NOT NULL IDENTITY,
	label_fr TEXT,
	label_en TEXT,
	label_es TEXT,
	label_de TEXT,
	ordering INT
);

CREATE TABLE Property(
	idProperty INT PRIMARY KEY NOT NULL IDENTITY,
);

CREATE TABLE HeroSkills(
	idHeroSkill INT PRIMARY KEY NOT NULL IDENTITY,
	name NVARCHAR(255),
	daysNeeded  INT,
	description_fr TEXT,
	description_en TEXT,
	description_es TEXT,
	description_de TEXT,
	icon NVARCHAR(255),
	label_fr TEXT,
	label_en TEXT,
	label_es TEXT,
	label_de TEXT,
	nbUses INT
);

CREATE TABLE Item(
	idItem INT PRIMARY KEY NOT NULL IDENTITY,
	idCategory INT,
	deco INT,
	label_fr TEXT,
	label_en TEXT,
	label_es TEXT,
	label_de TEXT,
	description_fr TEXT,
	description_en TEXT,
	description_es TEXT,
	description_de TEXT,
	guard INT,
	img NVARCHAR(255),
	isHeaver BIT,
	name NVARCHAR(255),
	FOREIGN KEY(idCategory) REFERENCES Category(idCategory),
);

CREATE TABLE Recipe(
	idRecipe INT PRIMARY KEY NOT NULL IDENTITY,
	isShamanOnly BIT,
	name NVARCHAR(255),
	type NVARCHAR(255)
);

CREATE TABLE Action(
	idAction INT PRIMARY KEY NOT NULL IDENTITY,
);

CREATE TABLE WishList(
	idWishList INT PRIMARY KEY NOT NULL IDENTITY,
);

CREATE TABLE Bank(
	idBank INT PRIMARY KEY NOT NULL IDENTITY,
);

CREATE TABLE Town (
	idTown INT PRIMARY KEY NOT NULL IDENTITY
);

CREATE TABLE Citizen(
	idCitizen INT PRIMARY KEY NOT NULL IDENTITY,
	name NVARCHAR(255),
	userId INT,
	userKey NVARCHAR(255)
);

CREATE TABLE LastUpdateInfo(
	idLastUpdateInfo INT PRIMARY KEY NOT NULL IDENTITY,
	dateUpdate DATETIME2 NOT NULL,
	idCitizen INT,
	FOREIGN KEY(idCitizen) REFERENCES Citizen(idCitizen)
);

CREATE TABLE TownBank(
	idTown INT,
	idBank INT,
	idLastUpdateInfo INT,
	PRIMARY KEY (idTown, idBank, idLastUpdateInfo),
	FOREIGN KEY(idTown) REFERENCES Town(idTown),
	FOREIGN KEY(idBank) REFERENCES Bank(idBank),
	FOREIGN KEY(idLastUpdateInfo) REFERENCES LastUpdateInfo(idLastUpdateInfo)
);

CREATE TABLE BankItem(
	idBank INT,
	idItem INT,
	count INT,
	PRIMARY KEY (idBank, idItem),
	FOREIGN KEY(idItem) REFERENCES Item(idItem),
	FOREIGN KEY(idBank) REFERENCES Bank(idBank),
);

CREATE TABLE TownCitizen(
	idTown INT,
	idCitizen INT,
	idLastUpdateInfo INT,
	homeMessage TEXT,
	jobName TEXT,
	jobUID NVARCHAR(255),
	positionX INT,
	positionY INT,
	isGhost BIT,
	PRIMARY KEY (idTown, idCitizen, idLastUpdateInfo),
	FOREIGN KEY(idTown) REFERENCES Town(idTown),
	FOREIGN KEY(idCitizen) REFERENCES Citizen(idCitizen),
	FOREIGN KEY(idLastUpdateInfo) REFERENCES LastUpdateInfo(idLastUpdateInfo)
);

CREATE TABLE TownWishList(
	idTown INT,
	idWishList INT,
	idLastUpdateInfo INT,
	PRIMARY KEY (idTown, idWishList, idLastUpdateInfo),
	FOREIGN KEY(idTown) REFERENCES Town(idTown),
	FOREIGN KEY(idWishList) REFERENCES WishList(idWishList),
	FOREIGN KEY(idLastUpdateInfo) REFERENCES LastUpdateInfo(idLastUpdateInfo)
);

CREATE TABLE WishListItem(
	idWishList INT,
	idItem INT,
	priority INT,
	count INT,
	PRIMARY KEY (idWishList, idItem),
	FOREIGN KEY(idWishList) REFERENCES WishList(idWishList),
	FOREIGN KEY(idItem) REFERENCES Item(idItem)
);

CREATE TABLE ItemAction(
	idItem INT,
	idAction INT,
	PRIMARY KEY (idItem, idAction),
	FOREIGN KEY(idItem) REFERENCES Item(idItem),
	FOREIGN KEY(idAction) REFERENCES Action(idAction)
);

CREATE TABLE ItemProperty(
	idItem INT,
	idProperty INT,
	PRIMARY KEY (idItem, idProperty),
	FOREIGN KEY(idItem) REFERENCES Item(idItem),
	FOREIGN KEY(idProperty) REFERENCES Property(idProperty)
);

CREATE TABLE RecipeItemResult(
	idRecipe INT,
	idItem INT,
	PRIMARY KEY (idRecipe, idItem),
	FOREIGN KEY(idRecipe) REFERENCES Recipe(idRecipe),
	FOREIGN KEY(idItem) REFERENCES Item(idItem)
);

CREATE TABLE RecipeItemComponent(
	idRecipe INT,
	idItem INT,
	PRIMARY KEY (idRecipe, idItem),
	FOREIGN KEY(idRecipe) REFERENCES Recipe(idRecipe),
	FOREIGN KEY(idItem) REFERENCES Item(idItem)
);
