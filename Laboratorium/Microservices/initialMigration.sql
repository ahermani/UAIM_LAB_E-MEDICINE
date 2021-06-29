
BEGIN TRANSACTION;
GO

CREATE TABLE [Certification] (
    [Id] int NOT NULL IDENTITY,
    [GrantedAt] datetime2 NOT NULL,
    [Type] int NOT NULL,
    CONSTRAINT [PK_Certification] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ExaminationRoom] (
    [Id] int NOT NULL IDENTITY,
    [Number] nvarchar(max) NULL,
    CONSTRAINT [PK_ExaminationRoom] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ExaminationRoomCertification] (
    [CertificationId] int NOT NULL,
    [ExaminationRoomId] int NOT NULL,
    CONSTRAINT [PK_ExaminationRoomCertification] PRIMARY KEY ([CertificationId], [ExaminationRoomId]),
    CONSTRAINT [FK_ExaminationRoomCertification_Certification_CertificationId] FOREIGN KEY ([CertificationId]) REFERENCES [Certification] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ExaminationRoomCertification_ExaminationRoom_ExaminationRoomId] FOREIGN KEY ([ExaminationRoomId]) REFERENCES [ExaminationRoom] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ExaminationRoomCertification_ExaminationRoomId] ON [ExaminationRoomCertification] ([ExaminationRoomId]);
GO


COMMIT;
GO

