CREATE TABLE [User]
(
	[email] varchar (255) PRIMARY KEY NOT NULL,
	[name] varchar (255) NOT NULL,
	[lastName] varchar (255) NOT NULL,
	[birthdate] date NOT NULL,
	[passwordHash] varchar (255) NOT NULL
);

CREATE TABLE [Admin]
(
	[email] varchar (255) PRIMARY KEY NOT NULL,
	FOREIGN KEY([email]) REFERENCES [User] ([email])
);

CREATE TABLE [Driver]
(
	[email] varchar (255) PRIMARY KEY NOT NULL,
	FOREIGN KEY([email]) REFERENCES [User] ([email])
);

CREATE TABLE [Bonus]
(
	[id] integer PRIMARY KEY NOT NULL,
	[name] varchar (255) NOT NULL,
	[validFrom] date NOT NULL,
	[validTo] date NOT NULL,
	[fk_AdminEmail] varchar (255) NOT NULL,
	FOREIGN KEY([fk_AdminEmail]) REFERENCES [Admin] ([email])
);

CREATE TABLE [UserBan]
(
	[id] integer PRIMARY KEY NOT NULL,
	[from] date NOT NULL,
	[to] date NOT NULL,
	[fk_UserEmail] varchar (255) NOT NULL,
	[fk_AdminEmail] varchar (255) NOT NULL,
	FOREIGN KEY([fk_UserEmail]) REFERENCES [User] ([email]),
	FOREIGN KEY([fk_AdminEmail]) REFERENCES [Admin] ([email])
);

CREATE TABLE [RegistrationVerification]
(
	[id] integer PRIMARY KEY NOT NULL,
	[date] date NOT NULL,
	[fk_AdminEmail] varchar (255) NOT NULL,
	[fk_UserEmail] varchar (255) NOT NULL,
	FOREIGN KEY([fk_AdminEmail]) REFERENCES [Admin] ([email]),
	FOREIGN KEY([fk_UserEmail]) REFERENCES [User] ([email])
);

CREATE TABLE [Advert]
(
	[id] integer PRIMARY KEY NOT NULL,
	[addressFrom] varchar (255) NOT NULL,
	[addressTo] varchar (255) NOT NULL,
	[startTime] date NOT NULL,
	[totalSeats] int NOT NULL,
	[availableSeats] int NOT NULL,
	[ticketPrice] double precision NOT NULL,
	[isValid] bit DEFAULT 0 NOT NULL,
	[fk_DriverEmail] varchar (255) NOT NULL,
	[fk_AdminEmail] varchar (255) NOT NULL,
	FOREIGN KEY([fk_DriverEmail]) REFERENCES [Driver] ([email]),
	FOREIGN KEY([fk_AdminEmail]) REFERENCES [Admin] ([email])
);

CREATE TABLE [Passenger]
(
	[email] varchar (255) PRIMARY KEY NOT NULL,
	[fk_BonusId] integer NOT NULL,
	FOREIGN KEY([fk_BonusId]) REFERENCES [Bonus] ([id]),
	FOREIGN KEY([email]) REFERENCES [User] ([email])
);

CREATE TABLE [TripState]
(
	[id] integer PRIMARY KEY NOT NULL,
	[name] varchar (255) NOT NULL,
);

INSERT INTO [TripState] ([id], [name])
VAlUES
  (1, 'notStarted'),
  (2, 'inProgress'),
  (3, 'ended');

CREATE TABLE [Trip]
(
	[id] integer PRIMARY KEY NOT NULL,
	[startTime] date NOT NULL,
	[endTime] date NOT NULL,
	[endedByDriver] bit NOT NULL,
	[state] integer DEFAULT 1 NOT NULL,
	[fk_AdvertId] integer NOT NULL,
	FOREIGN KEY([state]) REFERENCES [TripState] ([id]),
	FOREIGN KEY([fk_AdvertId]) REFERENCES [Advert] ([id])
);

CREATE TABLE [Ticket]
(
	[id] integer PRIMARY KEY NOT NULL,
	[price] double precision NOT NULL,
	[validTill] date NOT NULL,
	[isUsed] bit DEFAULT 0 NOT NULL,
	[fk_PassengerEmail] varchar (255) NOT NULL,
	[fk_AdvertId] integer NOT NULL,
	FOREIGN KEY([fk_PassengerEmail]) REFERENCES [Passenger] ([email]),
	FOREIGN KEY([fk_AdvertId]) REFERENCES [Advert] ([id])
);

CREATE TABLE [Comment]
(
	[id] integer PRIMARY KEY NOT NULL,
	[date] date NOT NULL,
	[text] varchar (255) NOT NULL,
	[fk_AdvertId] integer NOT NULL,
	[fk_DriverEmail] varchar (255) NOT NULL,
	[fk_PassengerEmail] varchar (255) NOT NULL,
	FOREIGN KEY([fk_AdvertId]) REFERENCES [Advert] ([id]),
	FOREIGN KEY([fk_DriverEmail]) REFERENCES [Driver] ([email])
);

CREATE TABLE [Rating]
(
	[id] integer PRIMARY KEY NOT NULL,
	[rate] double precision NOT NULL,
	[fk_PassengerEmail] varchar (255) NOT NULL,
	[fk_TripId] integer NOT NULL,
	FOREIGN KEY([fk_PassengerEmail]) REFERENCES [Passenger] ([email]),
	FOREIGN KEY([fk_TripId]) REFERENCES [Trip] ([id])
);

CREATE TABLE [RatingReason]
(
	[id] integer PRIMARY KEY NOT NULL,
	[text] varchar (255) NOT NULL,
	[fk_RatingId] integer NOT NULL,
	FOREIGN KEY([fk_RatingId]) REFERENCES [Rating] ([id])
);