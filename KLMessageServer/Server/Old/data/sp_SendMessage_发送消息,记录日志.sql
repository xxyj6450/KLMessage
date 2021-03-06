SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_SendMessage]
	@Usercode varchar(50),
	@RegisterUsercode varchar(50),
	@AccessUsercode varchar(50),
	@Recipients varchar(max),
	@RecipientsCount int=0,
	@SessionID varchar(50),
	@ConnID bigint,
	@Nettype int,
	@MessageID int=0 output
as
	BEGIN
		set NOCOUNT ON
		insert into T_MessageSendLog(SessionID,RegisterUsercode,AccessUsercode,usercode,ConnID,Recipients,NetType,RecipientsCount)
		select @SessionID,@RegisterUsercode,@AccessUsercode,@Usercode ,@ConnID,@Recipients,@Nettype,@RecipientsCount
		set @MessageID=@@identity
		--初始化用户数据
		update tu
			set tu.today=convert(varchar(10),getdate(),120),
			tu.SendToday= case  when isnull(tu.today,'')<>convert(varchar(10),getdate(),120) then 0 else isnull(tu.SendToday,0) end,
			tu.thismonth=convert(varchar(7),getdate(),120),
			tu.SendThisMonth=case when  isnull(tu.thismonth,'')<>convert(varchar(7),getdate(),120) then 0 else isnull(tu.SendThisMonth,0) end
		from t_User tu
		--初始化账户数据
		update tu
			set tu.theDay=convert(varchar(10),getdate(),120),
			tu.SendToday_CM= case when  isnull(tu.theDay,'')<>convert(varchar(10),getdate(),120) then 0 else isnull(tu.SendToday_CM,0) end,
			tu.SendToday_TEL= case when  isnull(tu.theDay,'')<>convert(varchar(10),getdate(),120) then 0 else isnull(tu.SendToday_TEL,0) end,
			tu.SendToday_UN= case when  isnull(tu.theDay,'')<>convert(varchar(10),getdate(),120) then 0 else isnull(tu.SendToday_UN,0) end,
			tu.theMonth=convert(varchar(7),getdate(),120),
			tu.SendThisMonth_CM=case when  isnull(tu.theMonth,'')<>convert(varchar(7),getdate(),120) then 0 else isnull(tu.SendThisMonth_CM,0) end,
			tu.SendThisMonth_TEL=case when  isnull(tu.theMonth,'')<>convert(varchar(7),getdate(),120) then 0 else isnull(tu.SendThisMonth_TEL,0) end,
			tu.SendThisMonth_UN=case when  isnull(tu.theMonth,'')<>convert(varchar(7),getdate(),120) then 0 else isnull(tu.SendThisMonth_UN,0) end,
			tu.theHour=datepart(hour,getdate()),
			tu.SendThisHour_CM=case when  isnull(tu.theHour,'')<>datepart(hour,getdate()) then 0 else isnull(tu.SendThisHour_CM,0) end,
			tu.SendThisHour_TEL=case when  isnull(tu.theHour,'')<>datepart(hour,getdate()) then 0 else isnull(tu.SendThisHour_TEL,0) end,
			tu.SendThisHour_UN=case when  isnull(tu.theHour,'')<>datepart(hour,getdate()) then 0 else isnull(tu.SendThisHour_UN,0) end
		from T_AccountInfo  tu
	END
	 
	 
 