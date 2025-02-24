CREATE TABLE sbt.UserName (
    Id  			INT                		NOT NULL	GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	Guid 			UUID 		NOT NULL	DEFAULT uuid_generate_v4(),
	UserName 		TEXT		NOT NULL,
    UserId          INT         NOT NULL,
	CreatedOn   	TIMESTAMP 	NOT NULL	DEFAULT CURRENT_TIMESTAMP,
    CreatedById     INT                      NOT NULL    REFERENCES sbt.User(Id),
	UpdatedOn   	TIMESTAMP   NOT NULL	DEFAULT CURRENT_TIMESTAMP,
    UpdatedById     INT                      NOT NULL    REFERENCES sbt.User(Id),
	IsActive    	BOOLEAN	    NOT NULL	DEFAULT TRUE,
);

CREATE UNIQUE INDEX user_guid_idx on sbt.UserName(Guid); 

CREATE UNIQUE INDEX user_username_idx on sbt.UserName(UserName); 

