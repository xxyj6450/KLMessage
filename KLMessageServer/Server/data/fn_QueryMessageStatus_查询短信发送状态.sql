SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from fn_QueryMessageStatus('','','','','','','','')
 --Select * from fn_QueryMessageStatus('','','','2013-06-5','2013-06-5','','','')
ALTER FUNCTION [dbo].[fn_QueryMessageStatus](
	@SessionID varchar(50),
	@Usercode varchar(50),
	@SerialNumber nvarchar(50),
	@Beginday datetime,
	@EndDay datetime,
	@Content varchar(500),
	@SendStatus varchar(50),
	@EchoStatus varchar(50)
)
returns @table table(
	SessionID varchar(50),
	MessageID int,
	Usercode varchar(50),
	SerialNumber varchar(50),
	SendDate datetime,
	Content varchar(500),
	SendStatus int,
	SendStatusText varchar(500),
	EchoStatus int,
	EchoStatusText varchar(500),
	SendRetValue int,
	EchoDate datetime
)
as
BEGIN
	;with cte_Notify as(
		select  a.MessageID,a.Param as SerialNumber,a.res,kl.errorText
		from t_notifyStatus a with(nolock) --outer apply dbo.SPLIT(isnull(a.Param,''),'|') s
		inner join kl_error kl on a.res=kl.errorcode
		where a.EventID=13
		--group by a.MessageID,a.Param,a.res,kl.errortext
	),
	cte_T_EchoOfMessage as (
		
		select messageid,teom.Recipient,teom.RegisterUsercode,teom.Status,(teom.MessageDate) as EchoDate
		from T_EchoOfMessage teom with(nolock)
		--group by messageid,teom.Recipient,teom.RegisterUsercode,teom.Status
		)
	insert into @table
	select  tmsl.SessionID ,tmsl.MessageID, tm.usercode,x.list as SerialNumber,tmsl.SendDate,tm.content, cn.res as SendStatus,cn.errorText as SendStatusText,
	teom.Status as EchoStatus,
	case teom.Status 
		when 1 then '接收方成功接收短信' 
		when -1 then '系统异常'
		when -92 then '号码异常,等待号码恢复'
		when -12 then '系统超时'
	end as EchoStatusText,tmsl.Status as '发送状态',teom.EchoDate
	from T_Message tm with (nolock)
	inner join T_MessageSendLog tmsl with(nolock) on tmsl.SessionID=tm.sessionid
	outer apply split(tmsl.	Recipients,';') x 
	left join cte_Notify cn on tmsl.MessageID=cn.MessageID and x.List=cn.SerialNumber
	left join cte_T_EchoOfMessage teom with(nolock) on tmsl.MessageID=teom.messageid and x.List=teom.Recipient
	where (@SessionID='' or convert(varchar(50),tm.sessionid)=@SessionID)
	and (@SerialNumber='' or x.List=@SerialNumber)
	and (@SessionID<>'' or @Beginday='' or tm.enterdate >=@Beginday)
	and (@SessionID<>'' or @EndDay='' or tm.enterdate <=@EndDay)
	and (@SendStatus='' or cn.res= case when @SendStatus='成功' then 1 end or cn.res<=case when @SendStatus='失败' then -1 end)
	and (@EchoStatus='' or teom.status= case when @EchoStatus='成功' then 1 end or teom.status<=case when @EchoStatus='失败' then -1 end)
	and (@Content='' or tm.content like '%'+@Content+'%')
	and (@Usercode='' or tm.usercode=@Usercode)
	and x.List<>''
	return
END

 