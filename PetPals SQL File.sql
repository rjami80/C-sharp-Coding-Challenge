-- Coding Challenge - PetPals, The Pet Adoption Platform
--Name: Jami Ram Sai Rohan
-- Coding Challenge - PetPals, The Pet Adoption Platform
-- C Sharp Coding Challenge
CREATE DATABASE PetPals;

USE PetPals;

CREATE TABLE Pets (
    PetID INT PRIMARY KEY identity(1,1),
    Name VARCHAR(255),
    Age INT,
    Breed VARCHAR(255),
    Type VARCHAR(255),
    AvailableForAdoption BIT
);

CREATE TABLE Shelters (
    ShelterID INT PRIMARY KEY identity(1,1),
    Name VARCHAR(255),
    Location VARCHAR(255)
);

CREATE TABLE Donations (
    DonationID INT PRIMARY KEY identity(1,1),
    DonorName VARCHAR(255),
    DonationType VARCHAR(255),
    DonationAmount DECIMAL,
    DonationItem VARCHAR(255),
    DonationDate DATETIME
);

CREATE TABLE AdoptionEvents (
    EventID INT PRIMARY KEY identity(1,1),
    EventName VARCHAR(255),
    EventDate DATETIME,
    Location VARCHAR(255)
);

CREATE TABLE Participants (
    ParticipantID INT PRIMARY KEY identity(1,1),
    ParticipantName VARCHAR(255),
    ParticipantType VARCHAR(255),
    EventID INT,
    FOREIGN KEY (EventID) REFERENCES AdoptionEvents(EventID) on delete set null
);

CREATE TABLE Adoption(
	AdoptionID INT PRIMARY KEY identity(1,1),
	PetID INT FOREIGN KEY REFERENCES Pets(PetID) on delete set null,
	UserID INT FOREIGN KEY REFERENCES Participants(ParticipantID) on delete set null
);

INSERT INTO Pets (Name, Age, Breed, Type, AvailableForAdoption)
VALUES
    ('Max', 2, 'Labrador', 'Dog', 1),
    ('Pluto', 1, 'Persian', 'Cat', 0),
    ('Charlie', 3, 'German Shepherd', 'Dog', 0),
    ('Oscar', 1, 'Golden Retreiver', 'Dog', 1),
    ('Tucker', 2, 'Siamese', 'Cat', 1),
    ('Tod', 4, 'Beagle', 'Dog', 1),
    ('Hammy', 1, 'Corgi', 'Dog', 0),
    ('Olivia', 2, 'Ragdoll', 'Cat', 0),
    ('Chester', 1, 'Golden Retriever', 'Dog', 1),
    ('Emma', 3, 'Maine Coon', 'Cat', 0);

-- Insert 10 entries into Shelters table
INSERT INTO Shelters (Name, Location)
VALUES
    ('People For Animals', 'New Delhi'),
    ('DoDo', 'Goa'),
    ('Charlies Animal Rescue Centre', 'Bangalore'),
    ('Rainbow Shelter', 'Ahmedabad'),
    ('Friendicoes', 'Visakhapatnam'),
    ('Furry Friends Shelter', 'Hyderabad'),
    ('Posh Foundation', 'UttarPradesh'),
    ('Mathews Rescue Force', 'Kolkata'),
    ('Caring Souls Shelter', 'Jaipur, '),
    ('Resonance Shelter', 'Kochi');

-- Insert 10 entries into Donations table
INSERT INTO Donations (DonorName, DonationType, DonationAmount, DonationItem, DonationDate)
VALUES
    ('Bhaskar', 'Cash', 250.00, NULL, '2023-01-20 09:28:00'),
    ('Uday', 'Item', NULL, 'Pet Food', '2023-12-04 17:25:00'),
    ('Kiran', 'Cash', 380.00, NULL, '2023-08-31 06:18:00'),
    ('Sri Harsha', 'Item', NULL, 'Pet Toys', '2023-04-24 15:06:00'),
    ('Ramana', 'Cash', 200.00, NULL, '2023-11-27 18:22:00'),
    ('Vidya Sagar', 'Item', NULL, 'Pet Bed', '2023-05-22 23:21:00'),
    ('Aditya', 'Cash', 100.00, NULL, '2023-12-29 07:55:00'),
    ('Sathwik', 'Item', NULL, 'Cat Litter', '2023-08-20 11:14:00'),
    ('Jaswanth', 'Cash', 150.00, NULL, '2023-06-18 18:33:00'),
    ('Uma', 'Item', NULL, 'Dog Leash', '2023-07-11 15:54:00');

-- Insert 10 entries into AdoptionEvents table
INSERT INTO AdoptionEvents (EventName, EventDate, Location)
VALUES
    ('PetPal Adoption Day', '2023-01-25 11:00:00', 'DoDo, Goa'),
    ('Animal Carnival', '2023-03-15 14:30:00', 'Hyderabad Pet Park'),
    ('Charity for Pets', '2023-05-05 12:00:00', 'Rainbow Shelter, Ahmedabad'),
    ('Paw Paw Festival', '2023-07-10 10:00:00', 'Whisker Haven, Bangalore'),
    ('Feuds', '2023-09-02 15:00:00', 'Resonance Shelter, Kochi'),
    ('Love for Paws', '2023-10-18 13:45:00', 'Caring Souls Shelter, Jaipur,'),
    ('Excellence Petpal', '2023-12-01 09:30:00', 'Posh Foundation, UttarPradesh'),
    ('Love Care Pets', '2024-02-08 11:20:00', 'Hearts Shelter, Delhi'),
    ('Soul for the Soul', '2024-04-03 16:00:00', 'Furry Friends Shelter, Hyderabad'),
    ('Barked Pet Show', '2024-06-22 10:45:00', 'Rainbow Shelter, Chennai');

-- Insert 10 entries into Participants table
INSERT INTO Participants (ParticipantName, ParticipantType, EventID)
VALUES
    ('Saqib Rangrez', 'Shelter', 1),
    ('Virat Kohli', 'Adopter', 1),
    ('Rahul', 'Adopter', 2),
    ('Akshar', 'Shelter', 2),
    ('Thakur', 'Adopter', 6),
    ('Vince', 'Shelter', 3),
    ('Ronit', 'Shelter', 4),
    ('Preethi', 'Adopter', 4),
    ('Akanksha', 'Shelter', 8),
    ('Mahesh', 'Adopter', 5);

INSERT INTO Adoption VALUES 
	( 3, 1),
	( 7, 2);

select * from adoption
Select * from Pets;
Select * from Shelters;
Select * from Donations;
Select * from AdoptionEvents;
Select * from Participants;

