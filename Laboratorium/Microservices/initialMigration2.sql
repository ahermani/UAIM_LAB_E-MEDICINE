
BEGIN TRANSACTION;
GO

CREATE TABLE [Speciality] (
    [Id] int NOT NULL IDENTITY,
    [Description] varchar(30) NOT NULL,
    [Number] int NOT NULL,
    CONSTRAINT [PK_Speciality] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Doctor] (
    [Id] int NOT NULL IDENTITY,
	[Name] varchar(30) NOT NULL,
	[Surname] varchar(30) NOT NULL,
	[Pesel] char(11) NOT NULL,
	[Gender] varchar(6) NOT NULL,
	[Wage] numeric(9,2) NOT NULL,
    CONSTRAINT [PK_Doctor] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [DoctorSpeciality] (
    [SpecialityId] int NOT NULL,
    [DoctorId] int NOT NULL,
    CONSTRAINT [PK_DoctorSpeciality] PRIMARY KEY ([SpecialityId], [DoctorId]),
    CONSTRAINT [FK_DoctorSpeciality_Speciality_SpecialityId] FOREIGN KEY ([SpecialityId]) REFERENCES [Speciality] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_DoctorSpeciality_Doctor_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctor] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_DoctorSpeciality_DoctorId] ON [DoctorSpeciality] ([SpecialityId]);
GO


COMMIT;
GO

