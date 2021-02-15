sp_help

CREATE TABLE GolfGame
  (
     GolfGameID    INT IDENTITY(1, 1) PRIMARY KEY,
     MemberNumber  INT
          FOREIGN KEY(MemberNumber) REFERENCES Members(MemberNumber),
     GolfGameDate  DATETIME NOT NULL,
     TimeSubmitted DATETIME NOT NULL,
     GolfCourse    NVARCHAR(50) NOT NULL,
     CourseRating  DECIMAL NOT NULL,
     SlopeRating   DECIMAL NOT NULL
  )

CREATE TABLE GolfGameHole
  (
     HoleID     INT IDENTITY(1, 1) PRIMARY KEY,
     GolfGameID INT
          FOREIGN KEY(GolfGameID) REFERENCES GolfGame(GolfGameID),
     HoleNumber INT NOT NULL,
     Score      INT NOT NULL
  ) 

  go

CREATE PROCEDURE GetHandicapIndex (@MemberNumber INT = NULL)
AS
    DECLARE @ReturnCode INT

    SET @ReturnCode = 1

    IF @MemberNumber IS NULL
      RAISERROR('MemberNumber is required',16,1)
    ELSE IF NOT EXISTS (SELECT *
                   FROM   members
                   WHERE  membernumber = @MemberNumber)
      RAISERROR('Member doesnt exist',16,1)
    ELSE
      BEGIN
          SELECT round(Avg(Cast(best8.totalscore AS DECIMAL)),0) AS 'AvgScore'
          FROM   (SELECT TOP 8 last20.totalscore
                  FROM   (SELECT TOP 20 ( ( 113 / sloperating ) * (
                                          (SELECT Sum(score)
                                            FROM   GolfGameHole
                                            WHERE  GolfGameHole.GolfGameID =
                 GolfGame.GolfGameID)
                 - courserating ) ) AS 'TotalScore'
                 FROM   GolfGame
                 WHERE  MemberNumber = @MemberNumber
                 ORDER  BY GolfGameDate DESC) AS last20) AS best8

          IF @@Error = 0
            SET @ReturnCode = 0
          ELSE
            RAISERROR('GetHandicapIdx - Select Error',16,1)
      END

    RETURN @ReturnCode

go

CREATE PROCEDURE GetBest8Avg (@MemberNumber INT = NULL)
AS
    DECLARE @ReturnCode INT

    SET @ReturnCode = 1

    IF @MemberNumber IS NULL
      RAISERROR('MemberNumber is required',16,1)
    ELSE IF NOT EXISTS (SELECT *
                   FROM   members
                   WHERE  membernumber = @MemberNumber)
      RAISERROR('Member doesnt exist',16,1)
    ELSE
      BEGIN
          SELECT round(Avg(Cast(Best8.TotalScore AS DECIMAL)),0) AS 'AvgScore'
          FROM   (SELECT TOP 8 last20.TotalScore
                  FROM   (SELECT TOP 20 ROUND(( ( 113 / SlopeRating ) * (
                                          (SELECT Sum(Score)
                                            FROM   GolfGameHole
                                            WHERE  GolfGameHole.GolfGameID =
                 GolfGame.GolfGameID)
                 - courserating ) ),1) AS 'TotalScore'
                 FROM   GolfGame
                 WHERE  membernumber = @MemberNumber
                 ORDER  BY GolfGameDate DESC) AS Last20) AS Best8

          IF @@Error = 0
            SET @ReturnCode = 0
          ELSE
            RAISERROR('GetBest8Avg - Select Error',16,1)
      END

    RETURN @ReturnCode

go

CREATE PROCEDURE GetLast20AVG (@MemberNumber INT = NULL)
AS
    DECLARE @ReturnCode INT

    SET @ReturnCode = 1

    IF @MemberNumber IS NULL
      RAISERROR('MemberNumber is required',16,1)
    ELSE IF NOT EXISTS (SELECT *
                   FROM   members
                   WHERE  membernumber = @MemberNumber)
      RAISERROR('Member doesnt exist',16,1)
    ELSE
      BEGIN
          SELECT round(Avg(Cast(Last20.TotalScore AS DECIMAL)),0) AS 'AvgScore'
          FROM   (SELECT TOP 20 ( ( 113 / sloperating ) * (
                                  (SELECT Sum(score)
                                   FROM   GolfGameHole
                                   WHERE  GolfGameHole.GolfGameID
                                          =
      GolfGame.GolfGameID)
      - courserating ) ) AS
      'TotalScore'
      FROM   GolfGame
      WHERE  membernumber = @MemberNumber
      ORDER  BY GolfGameDate DESC) AS Last20

          IF @@Error = 0
            SET @ReturnCode = 0
          ELSE
            RAISERROR('GetLast20Avg - Select Error',16,1)
      END

    RETURN @ReturnCode

go

CREATE PROCEDURE GetLast20Scores (@MemberNumber INT = NULL)
AS
    DECLARE @ReturnCode INT

    SET @ReturnCode = 1

    IF @MemberNumber IS NULL
      RAISERROR('MemberNumber is required',16,1)
    ELSE IF NOT EXISTS (SELECT *
                   FROM   members
                   WHERE  membernumber = @MemberNumber)
      RAISERROR('Member doesnt exist',16,1)
    ELSE
      BEGIN
          SELECT TOP 20 ( ( 113 / sloperating ) * ( (SELECT Sum(score)
                                                     FROM   GolfGameHole
                                                     WHERE  GolfGameHole.GolfGameID =
														GolfGame.GolfGameID)
																- courserating )
)
AS
'TotalScore'
FROM   GolfGame
WHERE  membernumber = @MemberNumber
ORDER  BY GolfGameDate DESC

IF @@Error = 0
SET @ReturnCode = 0
ELSE
RAISERROR('GetLast20Scores - Select Error',16,1)
END

    RETURN @ReturnCode 

DROP PROCEDURE InsertGolfGame (@MemberNumber INT = NULL,
     @GolfGameDate DATETIME = NULL, 
     @TimeSubmitted DATETIME = NULL,
     @GolfCourse NVARCHAR(50) = NULL,
     @CourseRating DECIMAL = NULL,
     @SlopeRating DECIMAL = NULL
	 )
AS
    DECLARE @ReturnCode INT

    SET @ReturnCode = 1

    IF @MemberNumber IS NULL
      RAISERROR('MemberNumber is required',16,1)
    ELSE IF NOT EXISTS (SELECT *
                   FROM   members
                   WHERE  membernumber = @MemberNumber)
      RAISERROR('Member doesnt exist',16,1)
    ELSE
		IF @GolfGameDate IS NULL
      RAISERROR('GolfGameDate is required',16,1)
	   ELSE
		IF @GolfCourse IS NULL
      RAISERROR('GolfCourse is required',16,1)
	     ELSE
		IF @CourseRating IS NULL
      RAISERROR('CourseRating is required',16,1)
	  ELSE
		IF @SlopeRating IS NULL
      RAISERROR('SlopeRating is required',16,1)
	  ELSE
      BEGIN
          INSERT INTO GolfGame(
     MemberNumber,
     GolfGameDate,
     TimeSubmitted,
     GolfCourse,
     CourseRating,
     SlopeRating )
		  VALUES (
     @MemberNumber,
     @GolfGameDate,
     @TimeSubmitted,
     @GolfCourse,
     @CourseRating ,
     @SlopeRating); 
	 
	 SELECT @@IDENTITY;

          IF @@Error = 0
            SET @ReturnCode = 0
          ELSE
            RAISERROR('Golf Game - Insert Error',16,1)
      END

    RETURN @ReturnCode


	


	 CREATE PROCEDURE InsertGameHoleScore (
     @GolfGameID INT = NULL,
     @HoleNumber INT = NULL,
     @Score      INT = NULL)
AS
    DECLARE @ReturnCode INT

    SET @ReturnCode = 1

    IF @GolfGameID IS NULL
      RAISERROR('@GolfGameID is required',16,1)
    ELSE IF NOT EXISTS (SELECT *
                   FROM   GolfGame
                   WHERE  GolfGameID = @GolfGameID)
      RAISERROR('GolfGameID doesnt exist',16,1)
    ELSE
		IF @HoleNumber IS NULL
      RAISERROR('HoleNumber is required',16,1)
	   ELSE
		IF @Score IS NULL
      RAISERROR('CourseRating is required',16,1)
	  ELSE
      BEGIN
          INSERT INTO GolfGameHole(
     GolfGameID,
     HoleNumber,
     Score
     )
		  VALUES (
     @GolfGameID,
     @HoleNumber,
     @Score
    ); 
 

          IF @@Error = 0
            SET @ReturnCode = 0
          ELSE
            RAISERROR('Golf Game HOle - Insert Error',16,1)
      END

    RETURN @ReturnCode

	