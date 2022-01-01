# CRUDWebAPICore
CRUD Operations(Insert, Update, Read and Delete) in ASP.NET Core Web API with database Stored Procedure using ADO.NET.

DON'T FORGET ABOUT THE CONNECTION STRING.

DB Migration

CREATE TABLE tbl_Employee(
Id int identity primary key,
Email nvarchar(200),
Emp_name nvarchar(200),
Designation nvarchar(200),
Created_date date default getdate()
)

CREATE PROCEDURE [dbo].[Sp_Employee]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Email nvarchar(200),
	@Emp_name nvarchar(200),
	@Designation nvarchar(200),
	@type nvarchar(50)
AS 
BEGIN
IF(@type='insert')
BEGIN
INSERT INTO tbl_Employee (Email, Emp_name, Designation) VALUES (@Email, @Emp_name, @Designation)
END
ELSE IF(@type='get')
BEGIN
SELECT * FROM tbl_Employee ORDER BY Id DESC
END
ELSE IF(@type='getId')
BEGIN
SELECT * FROM tbl_Employee where Id=@Id
END
ELSE IF(@type='update')
BEGIN
UPDATE tbl_Employee SET Email=@Email, Emp_name=@Emp_name, Designation=@Designation WHERE Id=@Id
END
ELSE IF(@type='delete')
BEGIN
DELETE FROM tbl_Employee WHERE Id=@Id
END
END

