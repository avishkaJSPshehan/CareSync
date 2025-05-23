CREATE DATABASE CARESYNC_DB;

USE CARESYNC_DB;

CREATE TABLE AspNetUsers (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    UserName NVARCHAR(256),
    NormalizedUserName NVARCHAR(256),
    Email NVARCHAR(256),
    NormalizedEmail NVARCHAR(256),
    EmailConfirmed BIT,
    PasswordHash NVARCHAR(MAX),
    SecurityStamp NVARCHAR(MAX),
    ConcurrencyStamp NVARCHAR(MAX),
    PhoneNumber NVARCHAR(MAX),
    PhoneNumberConfirmed BIT,
    TwoFactorEnabled BIT,
    LockoutEnd DATETIMEOFFSET,
    LockoutEnabled BIT,
    AccessFailedCount INT
);

CREATE TABLE Doctors (
    DoctorId INT PRIMARY KEY IDENTITY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Specialty NVARCHAR(100),
    PhoneNumber NVARCHAR(15),
    ProfileImage NVARCHAR(255),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);


CREATE TABLE Patients (
    PatientId INT PRIMARY KEY IDENTITY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    DOB DATE,
    Gender NVARCHAR(10),
    PhoneNumber NVARCHAR(15),
    Address NVARCHAR(255),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);


CREATE TABLE DoctorSchedules (
    ScheduleId INT PRIMARY KEY IDENTITY,
    DoctorId INT NOT NULL,
    DayOfWeek INT NOT NULL, -- 0=Sunday, 6=Saturday
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);


CREATE TABLE Appointments (
    AppointmentId INT PRIMARY KEY IDENTITY,
    DoctorId INT NOT NULL,
    PatientId INT NOT NULL,
    AppointmentDate DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    Status NVARCHAR(20) NOT NULL, -- e.g., Pending, Approved
    Notes NVARCHAR(MAX),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    CONSTRAINT UQ_DoctorAppointment UNIQUE (DoctorId, AppointmentDate, StartTime)
);


CREATE TABLE Prescriptions (
    PrescriptionId INT PRIMARY KEY IDENTITY,
    AppointmentId INT NOT NULL,
    FileUrl NVARCHAR(255),
    IssuedDate DATETIME NOT NULL DEFAULT GETDATE(),
    Notes NVARCHAR(MAX),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId)
);

CREATE TABLE Notifications (
    NotificationId INT PRIMARY KEY IDENTITY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    Message NVARCHAR(500) NOT NULL,
    SentAt DATETIME NOT NULL DEFAULT GETDATE(),
    IsRead BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);

