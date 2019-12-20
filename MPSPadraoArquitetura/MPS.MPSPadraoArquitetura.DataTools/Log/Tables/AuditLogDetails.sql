CREATE TABLE [Logs].[AuditLogDetails] (
    [Id]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [PropertyName]  VARCHAR (256) NOT NULL,
    [OriginalValue] VARCHAR (500)  NULL,
    [NewValue]      VARCHAR (500)  NULL,
    [AuditLogId]    BIGINT        NOT NULL,
    CONSTRAINT [PK_Logs.AuditLogDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Logs.AuditLogDetails_Logs.AuditLogs_AuditLogId] FOREIGN KEY ([AuditLogId]) REFERENCES [Logs].[AuditLogs] ([AuditLogId])
);


GO
CREATE NONCLUSTERED INDEX [IX_AuditLogId]
    ON [Logs].[AuditLogDetails]([AuditLogId] ASC);

