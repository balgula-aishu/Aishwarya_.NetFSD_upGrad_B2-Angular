----CREATE DATABASE ----
CREATE DATABASE EventDb;
USE EventDb;

-----CREATE USER INFO TABLE----
CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL,
    Password VARCHAR(20) NOT NULL,

    CONSTRAINT CHK_UserName_Length 
        CHECK (LEN(UserName) BETWEEN 1 AND 50),

    CONSTRAINT CHK_Role 
        CHECK (Role IN ('Admin', 'Participant')),

    CONSTRAINT CHK_Password_Length 
        CHECK (LEN(Password) BETWEEN 6 AND 20)
)
-----------CREATE TABLE EVENT DETAILS---
CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description VARCHAR(255) NULL,
    Status VARCHAR(20) NOT NULL,

    CONSTRAINT CHK_EventName_Length 
        CHECK (LEN(EventName) BETWEEN 1 AND 50),

    CONSTRAINT CHK_EventCategory_Length 
        CHECK (LEN(EventCategory) BETWEEN 1 AND 50),

    CONSTRAINT CHK_Event_Status 
        CHECK (Status IN ('Active', 'In-Active'))
);
------CREATE TABLE SPEAKER DETAILS---
CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL,

    CONSTRAINT CHK_SpeakerName_Length 
        CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);
-----CREATE TABLE SESSION INTO ---
CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,
    Description VARCHAR(255) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(255) NULL,

    CONSTRAINT CHK_SessionTitle_Length 
        CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),

    CONSTRAINT FK_Session_Event 
        FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Session_Speaker 
        FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);
---CREATE TABLE PARTICIPANT DETAILS---
CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    EmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT NOT NULL,

    CONSTRAINT FK_Participant_User 
        FOREIGN KEY (EmailId) REFERENCES UserInfo(EmailId),

    CONSTRAINT FK_Participant_Event 
        FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Participant_Session 
        FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);



---INSERTING VALUES INTO EVENT DETAILS---
INSERT INTO EventDetails VALUES
(1,'Tech Summit','Technology','2026-04-15','Annual tech Event','Active'),
(2,'Health Expo','HealthCare','2026-05-20','Mediacl Event','Active')

SELECT * FROM EventDetails;

------INSERTING VALUES INTO SPEAKER DETAILS---
INSERT INTO SpeakersDetails VALUES
(101,'Dr.Sharma'),
(102,'Mr.Jhon')

SELECT * FROM SpeakersDetails

----INSERTING VALUES INTO SESSION INFO---
INSERT INTO SessionInfo VALUES
(1001,1,'AI Impact',101,'Descussion on AI','2026-04-15 10:00:00','2026-04-15 12:00:00','http://session1.com'),
(1002,2,'Health Tips',102,'Descussion about Health','2026-05-05 2:00:00','2026-05-05 4:00:00','http://session2.com')

SELECT * FROM SessionInfo

----INSERTING VALUES INTO ParticipantDetails---
INSERT INTO ParticipantEventDetails VALUES
(1,'a@gmail.com',1,1001,1)
SELECT * FROM ParticipantEventDetails


---INSERTING VALUES INTO USER INFO----
INSERT INTO UserInfo VALUES 
('admin@gmail.com','AdminUser','Admin','admin123'),
('a@gmail.com','Aishu','Participant','aishu123');
SELECT * FROM UserInfo