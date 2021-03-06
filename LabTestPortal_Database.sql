USE [LabTestPortal]
GO
/****** Object:  Table [dbo].[person]    Script Date: 12/19/2018 1:57:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[person](
	[person_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[state_id] [int] NOT NULL,
	[gender] [char](1) NULL,
	[dob] [datetime] NULL,
 CONSTRAINT [PK_person] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[states]    Script Date: 12/19/2018 1:57:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[states](
	[state_id] [int] IDENTITY(1,1) NOT NULL,
	[state_code] [char](2) NOT NULL,
 CONSTRAINT [PK_states] PRIMARY KEY CLUSTERED 
(
	[state_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[person]  WITH CHECK ADD  CONSTRAINT [FK_person_states] FOREIGN KEY([state_id])
REFERENCES [dbo].[states] ([state_id])
GO
ALTER TABLE [dbo].[person] CHECK CONSTRAINT [FK_person_states]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonDelete]    Script Date: 12/19/2018 1:57:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspPersonDelete]
	@person_id int
AS
BEGIN
	SET NOCOUNT ON;

    DELETE
	FROM person WITH (ROWLOCK)
	WHERE person_id = @person_id
END
GO
/****** Object:  StoredProcedure [dbo].[uspPersonGet]    Script Date: 12/19/2018 1:57:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspPersonGet]
	@person_id int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT person.*, states.state_code
	FROM person WITH (NOLOCK)
		inner join states WITH (NOLOCK)
			ON person.state_id = states.state_id
	WHERE person.person_id = @person_id
END
GO
/****** Object:  StoredProcedure [dbo].[uspPersonSearch]    Script Date: 12/19/2018 1:57:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspPersonSearch]
	@first_name varchar(50),
	@last_name varchar(50),
	@state_id int,
	@gender char(1),
	@dob datetime
AS
BEGIN
	SET NOCOUNT ON;

    SELECT *
	FROM person WITH (NOLOCK)
	WHERE (@first_name is null or first_name = @first_name)
	AND (@last_name is null or last_name = @last_name)
	AND (@state_id is null or state_id = @state_id)
	AND (@gender is null or gender = @gender)
	AND (@dob is null or dob = @dob)
END
GO
/****** Object:  StoredProcedure [dbo].[uspPersonUpsert]    Script Date: 12/19/2018 1:57:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspPersonUpsert] 
	@person_id int = 0,
	@first_name varchar(50),
	@last_name varchar(50),
	@state_id int,
	@gender char(1),
	@dob datetime
AS
BEGIN
	SET NOCOUNT ON;

    IF @person_id = 0 BEGIN
		INSERT INTO person(first_name, last_name, state_id, gender, dob)
			VALUES(@first_name, @last_name, @state_id, @gender, @dob)
		SET @person_id = SCOPE_IDENTITY()
	END
	ELSE BEGIN
		UPDATE person WITH (ROWLOCK)
		SET first_name = @first_name,
			last_name = @last_name,
			state_id = @state_id,
			gender = @gender,
			dob = @dob
		WHERE person_id = @person_id
	END

	SELECT @person_id
END
GO
/****** Object:  StoredProcedure [dbo].[uspStatesList]    Script Date: 12/19/2018 1:57:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspStatesList]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM states WITH (NOLOCK)
END
GO
