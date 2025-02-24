CREATE TABLE sbt.Team (
    Id  			INT		NOT NULL	GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	Guid 			UUID 		NOT NULL	DEFAULT uuid_generate_v4(),
	TeamName 		TEXT		NOT NULL,
	Description 	TEXT		NULL,	
	CreatedOn   	TIMESTAMP 	NOT NULL	DEFAULT CURRENT_TIMESTAMP,
    CreatedById     INT     NOT NULL    REFERENCES sbt.User(Id),
	UpdatedOn   	TIMESTAMP 	NOT NULL	DEFAULT CURRENT_TIMESTAMP,
    UpdatedById     INT     NOT NULL    REFERENCES sbt.User(Id),
	IsActive    	BOOLEAN	    NOT NULL	DEFAULT TRUE,
);

CREATE UNIQUE INDEX team_guid_idx on sbt.Team(Guid); 
