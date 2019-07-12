alter proc usp_ExamCategories_Query 
@PageNumber int= null,
@PageSize int = null,
@OwnerId uniqueidentifier = null , 
@CategoryId int = null, 
@ParentId int = -1,
@EvalKind smallint = null
as
	DECLARE @FirstRow INT  = null, @LastRow INT = null
	
	if ( @PageNumber is not null) 
	begin 
		SELECT  @FirstRow   = ((@PageNumber -1)* @PageSize) + 1,
			    @LastRow    = ((@PageNumber -1)* @PageSize) + @PageSize			    
	end;	
	with CTE as
	(
		select
			ROW_NUMBER() over (order by EC.Id asc) as Number, 
			EC.Id, 
			EC.Title, 
			EC.[Description]
		from Customers C join ExamCategoriesOwners EO on C.Id =  EO.CustomerId join ExamCategories EC on EO.ExamCategoryId = EC.Id 
		where	((@OwnerId IS NULL)OR(EO.CustomerId = @OwnerId))  and 
				((@CategoryId IS NULL)OR(EC.Id = @CategoryId))  and 
				((@EvalKind IS NULL)OR(EC.InternalEvalKind = @EvalKind))  and 
				((@ParentId = -1) OR (isnull(EC.ParentId,0) = isnull(@ParentId, 0)))  		
	)	
	select * , (SELECT COUNT(*) FROM CTE) AS TotalNumber from CTE
	WHERE (@PageNumber is null ) or (Number BETWEEN @FirstRow AND @LastRow)
	order by Number
	for xml path('Category'), root('Categories'), ELEMENTS XSINIL	
	
	

