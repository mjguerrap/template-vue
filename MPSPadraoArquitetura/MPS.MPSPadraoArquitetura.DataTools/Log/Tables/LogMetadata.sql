CREATE TABLE [Logs].[LogMetadata] (
    [Id]         BIGINT       IDENTITY (1, 1) NOT NULL,
    [AuditLogId] BIGINT       NOT NULL,
    [Key]        VARCHAR (max) NULL,
    [Value]      VARCHAR (max) NULL,
    CONSTRAINT [PK_Logs.LogMetadata] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Logs.LogMetadata_Logs.AuditLogs_AuditLogId] FOREIGN KEY ([AuditLogId]) REFERENCES [Logs].[AuditLogs] ([AuditLogId])
);


GO
CREATE NONCLUSTERED INDEX [IX_AuditLogId]
    ON [Logs].[LogMetadata]([AuditLogId] ASC);

