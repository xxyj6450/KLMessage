SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[fn_QueryUserInfo](
	@Usercode varchar(50),
	@UserName varchar(50),
	@CompanyName varchar(50),
	@Status varchar(50),
	@Tel varchar(50),
	@Email varchar(50)
)
returns  table 
as 
return 
select 0 as Selected ,usercode,password,username,companyname,email,tel,isadmin,status, TotalLimit ,LimitPerday,TotalSend,
case when isnull(TotalLimit,0)>0 then isnull(TotalLimit,0)-isnull(TotalSend,0) else 0 end as CreditLeft,
case when today=convert(varchar(10),getdate(),120) then  SendToday else 0 end as SendToday,
case when thismonth=convert(varchar(7),getdate(),120) then  SendThismonth else 0 end as SendThismonth,Remark,isnull(DistributionMode,'节省资源') as DistributionMode
from t_User tu with(nolock)
where (@Usercode='' or tu.usercode=@Usercode)
and (@UserName='' or tu.username like '%'+@UserName+'%')
and (@CompanyName='' or tu.companyname='%'+@CompanyName+'%')
and (@Tel='' or tu.tel='%'+@Tel+'%')
and (@status='' or tu.status=@Status)