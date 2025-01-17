USE [db Trabajo Final Matricula]
GO
/****** Object:  Table [dbo].[alumno]    Script Date: 09/07/2017 6:29:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumno](
	[idalumno] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[idcurso] [int] NULL,
	[idprofesor] [int] NULL,
 CONSTRAINT [PK_alumno] PRIMARY KEY CLUSTERED 
(
	[idalumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[curso]    Script Date: 09/07/2017 6:29:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[curso](
	[idcurso] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_curso] PRIMARY KEY CLUSTERED 
(
	[idcurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[profesor]    Script Date: 09/07/2017 6:29:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profesor](
	[idprofesor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[curso] [varchar](50) NULL,
	[tipoContrato] [varchar](50) NULL,
 CONSTRAINT [PK_profesor] PRIMARY KEY CLUSTERED 
(
	[idprofesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[alumno]  WITH CHECK ADD  CONSTRAINT [FK_alumno_curso] FOREIGN KEY([idcurso])
REFERENCES [dbo].[curso] ([idcurso])
GO
ALTER TABLE [dbo].[alumno] CHECK CONSTRAINT [FK_alumno_curso]
GO
ALTER TABLE [dbo].[alumno]  WITH CHECK ADD  CONSTRAINT [FK_alumno_profesor] FOREIGN KEY([idprofesor])
REFERENCES [dbo].[profesor] ([idprofesor])
GO
ALTER TABLE [dbo].[alumno] CHECK CONSTRAINT [FK_alumno_profesor]
GO
