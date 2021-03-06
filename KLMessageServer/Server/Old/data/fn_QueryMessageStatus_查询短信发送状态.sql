SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from fn_QueryMessageStatus('6A7A18BC-2264-4D8D-B155-746AB5D79F57','','','','','','','')
 --Select * from fn_QueryMessageStatus('','','','2013-06-5','2013-06-5','','','')
ALTER FUNCTION [dbo].[fn_QueryMessageStatus](
	@SessionID varchar(50),
	@Usercode varchar(50),
	@SerialNumber varchar(250),
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
	AccessAccountID varchar(50),
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
		select  s.list as SerialNumber,a.MessageID,a.res,kl.errorText
		from t_notifyStatus a with(nolock) outer apply dbo.SPLIT(isnull(a.Param,''),'|') s
		left join kl_error kl on a.res=kl.errorcode
		where a.EventID=13
		group by s.list,a.MessageID,a.res,kl.errortext
	),
	cte_T_EchoOfMessage1 as (
		select messageid ,teom.Recipient,max(id) as id
		from T_EchoOfMessage teom with(nolock)
		group by messageid,teom.Recipient 
		),
	cte_T_EchoOfMessage as (
		
		select teom.messageid,teom.Recipient,teom.RegisterUsercode,teom.Status,max(teom.MessageDate) as EchoDate
		from T_EchoOfMessage teom with(nolock) inner join cte_T_EchoOfMessage1 b on teom.id=b.id
		group by teom.messageid,teom.Recipient,teom.RegisterUsercode,teom.Status
		)
	insert into @table
	select  tmsl.SessionID ,tmsl.MessageID, tm.usercode,tmsl.AccessUsercode, x.list as SerialNumber,tmsl.SendDate,tm.content, isnull(cn.res,1) as SendStatus,isnull(cn.errorText,'正常') as SendStatusText,
	isnull(teom.Status,1) as EchoStatus,
	case teom.Status 
		when 1 then '接收方成功接收短信' 
		when -1 then '系统异常'
		when -92 then '号码存在异常等待接收'
		when -12 then '系统超时'
		else '正常'
	end as EchoStatusText,tmsl.Status as '发送状态',isnull(teom.EchoDate,tmsl.SendDate)
	from T_Message tm with (nolock)
	left join T_MessageSendLog tmsl with(nolock) on tmsl.SessionID=tm.sessionid
	outer apply split(isnull(tmsl.	Recipients,''),';') x 
	left join cte_Notify cn on tmsl.MessageID=cn.MessageID and x.List=cn.SerialNumber
	left join cte_T_EchoOfMessage teom with(nolock) on tmsl.MessageID=teom.messageid and x.List=teom.Recipient
	where (@SessionID='' or convert(varchar(50),tm.sessionid)=@SessionID)
	and (@SerialNumber='' or exists(select 1 from split(@SerialNumber,',') y where  x.List=y.list))
	and (@SessionID<>'' or @Beginday='' or tm.enterdate >=@Beginday)
	and (@SessionID<>'' or @EndDay='' or tm.enterdate <=@EndDay)
	and (@SendStatus='' or cn.res= case when @SendStatus='成功' then 1 end or cn.res<=case when @SendStatus='失败' then -1 end)
	and (@EchoStatus='' or teom.status= case when @EchoStatus='成功' then 1 end or teom.status<=case when @EchoStatus='失败' then -1 end)
	and (@Content='' or tm.content like '%'+@Content+'%')
	and (@Usercode='' or tm.usercode=@Usercode)
	and x.List<>''
	return
END

 