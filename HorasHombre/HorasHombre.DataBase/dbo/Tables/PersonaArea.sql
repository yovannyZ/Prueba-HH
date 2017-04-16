CREATE TABLE [dbo].[PersonaArea] (
    [IdArea]    INT NOT NULL,
    [IdPersona] INT NOT NULL,
    CONSTRAINT [PkPersonaArea] PRIMARY KEY CLUSTERED ([IdArea] ASC, [IdPersona] ASC),
    CONSTRAINT [Area_PersonaArea] FOREIGN KEY ([IdArea]) REFERENCES [dbo].[Area] ([IdArea]),
    CONSTRAINT [Persona_PersonaArea] FOREIGN KEY ([IdPersona]) REFERENCES [dbo].[Persona] ([IdPersona])
);



