begin TRAN

declare @SendPerday_CM bigint  ,
	@SendPerHour_CM bigint  ,
	@SendPerMonth_CM bigint  ,
	@SendPerday_TEL bigint  ,
	@SendPerMonth_TEL bigint  ,
	@SendPerHour_TEL bigint  ,
	@Sendperday_UN bigint  ,
	@SendPerMonth_UN bigint  ,
	@SendperHour_UN bigint  ,
	@InvockPerSecond int  ,
	@BatchSendNumbers int ,
	@Count int,@Nettype int
select @Count=10,@Nettype=1
select @BatchSendNumbers=isnull(tal.BatchSendNumbers,1000),@InvockPerSecond=isnull(tal.InvockPerSecond,100),
			@SendPerday_CM=tal.SendPerday_CM,@SendPerHour_CM=tal.SendPerHour_CM,@SendPerMonth_CM=tal.SendPerMonth_CM,
			@SendPerday_TEL=tal.SendPerday_TEL,@SendPerMonth_TEL=tal.SendPerMonth_TEL,@SendPerHour_TEL=tal.SendPerHour_TEL,
			@Sendperday_UN=tal.Sendperday_UN,@SendPerMonth_UN=tal.SendPerMonth_UN,@SendperHour_UN=tal.SendperHour_UN
			from T_AccountLimit tal

;with cte as(
	--只取出第一条方案,方案的优先级别是,尽可能耗尽每一个号码资源,并尽可能多地耗尽资源
	select     min(a.id) as StartID,min(b.id) as EndID,min(b.id-a.id) as Distance,
	--min( dbo.fn_min(n.sendperhour,dbo.fn_min(n.sendperday,n.sendpermonth))) minSendCount,
	--min(dbo.fn_min(@Count,dbo.fn_min(n.sendperhour,dbo.fn_min(n.sendperday,n.sendpermonth)))) as SendCount,
	min(n.sendperhour) as sendperhour,min(n.sendperday) as sendperday,min(n.sendpermonth) as sendpermonth
from T_AccountInfo a inner join  T_AccountInfo b on a.id<=b.id
cross apply fn_AggregateAccount(a.id,b.id,@Nettype)  n
where n.sendperday-@count>=0
and n.sendpermonth-@count>=0
and n.sendPerhour-@count>=0
		and a.IdleState='空闲'
		and a.AccountType='访问账号'
		and a.AccountStatus='已验证'
		and b.IdleState='空闲'
		and b.AccountType='访问账号'
		and b.AccountStatus='已验证'
 group by  a.id,b.id--n.sendperhour,n.sendperday,n.sendpermonth
--order by n.sendperhour,n.sendperday,n.sendpermonth,Distance desc						--先按sendperhour,sendperday,sendpermonth升序排序,尽可能地耗尽号码资源,再按Distance(距离),尽可能大面积地消耗号码资源
)
,cte2 as (
	select top 1 startid,endid, Distance,sendperhour,sendperday, sendpermonth 
	from cte n
	order by dbo.fn_min(dbo.fn_min(n.sendperhour,n.sendperday),n.sendpermonth),Distance desc						--先按sendperhour,sendperday,sendpermonth升序排序,尽可能地耗尽号码资源,再按Distance(距离),尽可能大面积地消耗号码资源
	)
-- select * from cte2
 
select a.AccountID as AccessUsercode,a.Password as AccessPassword,a.ParentAccountID as  RegisterUserCode,a.parentaccountPassword as RegisterPassword,
		case when @nettype=0 then dbo.fn_min(@SendPerHour_TEL -a.SendThisHour_TEL, dbo.fn_min(@SendPerMonth_TEL-a.SendThisMonth_TEL,@SendPerDay_TEL-a.SendToday_TEL))
				when @Nettype=1 then dbo.fn_min(@SendPerHour_CM -a.SendThisHour_CM, dbo.fn_min(@SendPerMonth_CM -a.SendThisMonth_CM,@SendPerday_CM -a.SendToday_CM))
				when @Nettype=2 then dbo.fn_min(@SendPerHour_UN-a.SendThisHour_UN, dbo.fn_min(@SendPerMonth_UN -a.SendThisMonth_UN,@Sendperday_UN -a.SendToday_UN))
		end as SendCount,
				@InvockPerSecond as InvockPerSecond,@BatchSendNumbers as BatchSendNumbers
from T_AccountInfo a inner join cte2 b on a.id between b.StartID and b.EndID
				where a.AccountType='访问账号'
				and isnull(a.IdleState,'空闲') in('空闲','')
				and a.AccountStatus='已验证' 
				--*/