CREATE TABLE sbt.User (
    Id  			INT         NOT NULL	GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	Guid 			UUID 		NOT NULL	DEFAULT uuid_generate_v4(),
	UserName 		TEXT		NULL,
	Email			TEXT 		NULL,
	FirstName 		TEXT		NULL,	
	LastName    	TEXT		NULL,	
	CreatedOn   	TIMESTAMP 	NOT NULL	DEFAULT CURRENT_TIMESTAMP,
    CreatedById     INT         NOT NULL    REFERENCES sbt.User(Id),
	UpdatedOn   	TIMESTAMP   NULL	    DEFAULT CURRENT_TIMESTAMP,
    UpdatedById     INT         NULL        REFERENCES sbt.User(Id),
	IsActive    	BOOLEAN	    NOT NULL	DEFAULT TRUE

);

INSERT INTO sbt.User
(	Id,
	Guid,
	UserName,
	Email,
	FirstName,
	LastName,
	CreatedOn,
	CreatedById,
	UpdatedOn,
	UpdatedById,
	IsActive)
	OVERRIDING SYSTEM VALUE 
VALUES (
	-1,
	uuid_generate_v4(),
	'ApiUser',
	null,
	null,
	null,
	CURRENT_TIMESTAMP,
	-1,
	null,
	null,
	true
)


ALTER TABLE sbt.User
    ADD CONSTRAINT fk_createdby FOREIGN KEY (CreatedById) REFERENCES sbt.User(Id),
    ADD CONSTRAINT fk_updatedby FOREIGN KEY (UpdatedById) REFERENCES sbt.User(Id);


CREATE UNIQUE INDEX user_guid_idx on sbt.User(Guid); 

