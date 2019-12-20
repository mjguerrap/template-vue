CREATE TABLE [Logs].[AuditLogs] (
    [AuditLogId]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [UserName]     VARCHAR (25)   NULL,
    [EventDateUTC] DATETIME2(2)   NOT NULL,
    [EventType]    INT           NOT NULL,
    [TypeFullName] VARCHAR (256) NOT NULL,
    [RecordId]     VARCHAR (256) NOT NULL,
    CONSTRAINT [PK_Logs.AuditLogs] PRIMARY KEY CLUSTERED ([AuditLogId] ASC)
);

