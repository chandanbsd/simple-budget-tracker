CREATE TABLE sbt.Ledger (
    Id  			INT		NOT NULL	GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	Guid 			UUID 		NOT NULL	DEFAULT uuid_generate_v4(),
	TeamId  		INT		NOT NULL    REFERENCES sbt.Team(Id),
	Description 	TEXT		NULL,	
	CreatedOn   	TIMESTAMP 	NOT NULL	DEFAULT CURRENT_TIMESTAMP,
    CreatedById     INT     NOT NULL    REFERENCES sbt.User(Id),
	UpdatedOn   	TIMESTAMP 	NOT NULL	DEFAULT CURRENT_TIMESTAMP,
    UpdatedById     INT     NOT NULL    REFERENCES sbt.User(Id),
	IsActive    	BOOLEAN	    NOT NULL	DEFAULT TRUE,
);

CREATE UNIQUE INDEX ledger_guid_idx on sbt.Ledger(Guid); 
