SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER function [dbo].[fn_QueryAccountInfo](
	@AccountId varchar(50),
	@ParentAccountID varchar(50),
	@AccountType varchar(50),
	@AccountStatus varchar(50)
)
returns table
as
return 
select 0 as Selected,accountID,Password,ParentAccountID,ParentAccountPassword,AccountStatus,AccountType,a.IdleState,a.ReleaseTime,
a.totalSend_CM,a.totalSend_TEL,a.TotalSend_UN,
case when isnull(a.theMonth,convert(varchar(7),getdate(),120))=convert(varchar(7),getdate(),120) then a.SendThisMonth_CM else 0 end as SendThisMonth_CM,
case when isnull(a.theMonth,convert(varchar(7),getdate(),120))=convert(varchar(7),getdate(),120) then a.SendThisMonth_TEL else 0 end as SendThisMonth_TEL,
case when isnull(a.theMonth,convert(varchar(7),getdate(),120))=convert(varchar(7),getdate(),120) then a.SendThisMonth_UN else 0 end as SendThisMonth_UN,
case when isnull(a.theDay,convert(varchar(10),getdate(),120))=convert(varchar(10),getdate(),120) then a.SendToday_CM else 0 end as SendToday_CM,
case when isnull(a.theDay,convert(varchar(10),getdate(),120))=convert(varchar(10),getdate(),120) then a.SendToday_TEL else 0 end as SendToday_TEL,
case when isnull(a.theDay,convert(varchar(10),getdate(),120))=convert(varchar(10),getdate(),120) then a.SendToday_UN else 0 end as SendToday_UN,
case when isnull(a.theHour,datepart(hour,getdate()))=datepart(hour,getdate()) then a.SendThisHour_CM else 0 end as SendThisHour_CM,
case when isnull(a.theHour,datepart(hour,getdate()))=datepart(hour,getdate()) then a.SendThisHour_TEL else 0 end as SendThisHour_TEL,
case when isnull(a.theHour,datepart(hour,getdate()))=datepart(hour,getdate()) then a.SendThisHour_UN else 0 end as SendThisHour_UN,
a.enterDate,a.Remark
from t_accountInfo a with(nolock)
where (@AccountId='' or a.accountid=@AccountId)
and (@ParentAccountID='' or a.parentAccountID=@ParentAccountID)
and (@AccountType='' or a.accountType=@AccountType)
and (@AccountStatus='' or a.accountStatus=@AccountStatus)