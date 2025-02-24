CREATE TABLE sbt.User (
    Id  			BIGINT		NOT NULL	GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	Guid 			UUID 		NOT NULL	DEFAULT uuid_generate_v4(),
	UserName 		TEXT		NOT NULL,
	FirstName 		TEXT		NULL,	
	LastName    	TEXT		NULL,	
	CreatedOn   	TIMESTAMP 	NOT NULL	DEFAULT CURRENT_TIMESTAMP,
    CreatedById     BIG INT     NOT NULL    REFERENCES User(Id),
	UpdatedOn   	TIMESTAMP 	NOT NULL	DEFAULT CURRENT_TIMESTAMP,
    UpdatedById     BIG INT     NOT NULL    REFERENCES User(Id),
	IsDeleted   	BOOLEAN 	NOT NULL	DEFAULT FALSE
);

