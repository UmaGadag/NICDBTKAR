Create database [NICDBTKar];
Go

Create Table USER_MASTER(
	ID int Identity(1,1) NOT NULL,
	UserName nVarchar(50) NOT NULL,																																																																													
	Password nVarchar(50) NOT NULL,
    PRIMARY KEY (ID));

Create Table DEPARTMENT_MASTER(
	DepartmentID int Identity(1,1) NOT NULL,
	DepartmentName Varchar(50) NOT NULL,
    PRIMARY KEY (DepartmentID)
	);

Create Table SCHEMES_MASTER(
	SchemeID int Identity(1,1) NOT NULL,
	SchemeName NVarchar(100) NOT NULL,
	DepartmentID int not null,
    PRIMARY KEY (SchemeID),
	FOREIGN KEY (DepartmentID) REFERENCES DEPARTMENT_MASTER(DepartmentID));

Create Table BENEFICIARY_DETAILS( 
    BeneficiaryID int Identity(1,1) NOT NULL,
    BeneficiaryName nVarchar(100) NULL,
	Address nvarchar(max),
	AadhaarNumber nvarchar(12),
	DepartmentID int NOT NULL,
	SchemeID int NOT NULL,
    PRIMARY KEY (BeneficiaryID),
	FOREIGN KEY (DepartmentID) REFERENCES DEPARTMENT_MASTER(DepartmentID),
	FOREIGN KEY (SchemeID) REFERENCES SCHEMES_MASTER(SchemeID)
	
);
--inserting data into master table
Insert into USER_MASTER Values
('Test','Test123');

Insert Into DEPARTMENT_MASTER VALUES
('Social Welfare Department');
Insert Into DEPARTMENT_MASTER VALUES
('Agriculture Department');

Insert into SCHEMES_MASTER VALUES
('PreMatric Scholarship','1');
Insert into SCHEMES_MASTER VALUES('Milk Subsidy','2');

--insert/Update of datarecords to table
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Uma.G
-- Create date: 8/Nov/2023
-- Description:	adding datarecords to table 
-- =============================================
create PROCEDURE sp_InsertUpdateBENEFICIARY_DETAILS
@BeneficiaryID int =Null,
@BeneficiaryName nvarchar(100),
@Address nvarchar(max),
@AadhaarNumber Nvarchar(Max),
@DepartmentName Nvarchar(100),
@SchemeName Nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @DeptID int,@SchemeID int;

	Select @DeptID=DepartmentID From DEPARTMENT_MASTER Where DepartmentName=@DepartmentName;

    Select @SchemeID=SchemeID From SCHEMES_MASTER Where SchemeName=@SchemeName;

    -- Insert statements for procedure here
	IF NOT EXISTS( SELECT BeneficiaryID FROM BENEFICIARY_DETAILS where AadhaarNumber=@AadhaarNumber AND BeneficiaryName=@BeneficiaryName) 
	BEGIN 
		INSERT INTO BENEFICIARY_DETAILS
		(
        BeneficiaryName,
	    Address,
	    AadhaarNumber,
	    DepartmentID,
	    SchemeID
		)
		VALUES
		(
		@BeneficiaryName,
		@Address,
		@AadhaarNumber,
		@DeptID,
		@SchemeID
		);
		--SET @BeneficiaryID = @@ROWCOUNT;
	END
	ELSE 
	BEGIN 
		Update BENEFICIARY_DETAILS
		SET DepartmentID=@DeptID,
		    SchemeID=@SchemeID
		Where BeneficiaryID=@BeneficiaryID;
	END
	END
-- =============================================
-- Author:	Uma.G
-- Create date: 8/Nov/2023
-- Description:	Fetching\Retriving datarecords to table Based on Name And Aadhar Number
-- =============================================
create PROCEDURE sp_BENEFICIARY_DETAILS_BNA
@search nvarchar(100) 
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT BD.BeneficiaryID,BD.BeneficiaryName,
	    BD.Address,
	    BD.AadhaarNumber,
		BD.DepartmentID,
		BD.SchemeID
	FROM BENEFICIARY_DETAILS BD
	where (AadhaarNumber=@search) OR (BeneficiaryName=@search)
	

	END
GO
