create FUNCTION fn_QueryRecieveMessage(
	@SerialNumber varchar(50),
	@Begindate varchar(30),
	@EndDate varchar(30),
	@Content varchar(200),
	@AccountID varchar(20)
)
returns table
as
return 
select trm.RegisterUsercode,trm.Caller,trm.Content,trm.Enterdate
from T_RecieveMessage trm with(nolock)
where (@SerialNumber='' or trm.Caller=@SerialNumber)
and (@Begindate='' or trm.Enterdate>=@Begindate)
and (@EndDate='' or trm.Enterdate<=@EndDate)
and (@AccountID='' or trm.RegisterUsercode=@AccountID)
and (@Content='' or trm.Content like '%'+@Content+'%')