SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_AddUserInfo]
	@Usercode varchar(50),
	@UserName varchar(50),
	@Password varchar(50),
	@CompanyNAME VARCHAR(50)='',
	@Tel varchar(50)='',
	@Email varchar(200)='',
	@Status  varchar(50)='正常',
	@DistributionMode varchar(20)='节省资源',
	@LimitPerday int =10000,
	@TotalLimit int=0,
	@isAdmin bit=0,
	@NofityNewMessage bit =0,
	@ShowEchoInfo bit=0, 
	@Remark varchar(200)=''
as
	BEGIN
		--	select * from t_User tu
		insert into t_User(usercode,password,username,companyname,email,tel,isadmin,status,limitperday,remark,totalLimit,DistributionMode,ShowEchoInfo,NofityNewMessage)
		select @Usercode,@Password,@UserName,@CompanyNAME,@Email,@Tel,@isAdmin,@Status,@LimitPerday,@Remark,@TotalLimit,@DistributionMode,@ShowEchoInfo,@NofityNewMessage
		return
	END
	
	
