-- I KNOW THAT I NEED TO WRITE A STORE PROCEDURE BUT RESULT ARE FROM PL/SQL
CREATE VIEW V_GROUP_GRADE AS
(
	SELECT group_result.*
	,(CASE WHEN group_result.GROUP_SCORE >= 80  THEN 'A'
		   WHEN group_result.GROUP_SCORE >= 70  THEN 'B' 
		   WHEN group_result.GROUP_SCORE >= 60  THEN 'C'
		   WHEN group_result.GROUP_SCORE IS NULL  THEN NULL
		   ELSE 'F' END) AS GROUP_GRADE
	FROM 
	(
		SELECT group_score_data.GROUP_NAME
		,group_score_data.GROUP_MEMBERS
		,(CASE WHEN group_score_data.avgscorecondition1 IS NOT NULL THEN avgscorecondition1
			  WHEN group_score_data.avgscorecondition2 IS NOT NULL THEN avgscorecondition2
			  ELSE avgscorecondition1 END) AS GROUP_SCORE
		FROM 
		(
			SELECT group_raw.GROUP_NAME
			,group_raw.count_mem AS GROUP_MEMBERS
			,avg( CASE WHEN group_raw.count_mem > 2 and group_raw.row_asc != 1 and group_raw.row_desc != 1 THEN group_raw.score END) AS avgscorecondition2
			,avg( CASE WHEN group_raw.count_mem <= 2 THEN group_raw.score END) AS avgscorecondition1
			FROM 
			(
				SELECT g.GROUP_NAME ,m.*,
				row_number() over(PARTITION BY m.GROUP_ID ORDER BY m.SCORE desc) AS row_desc
				,row_number() over(PARTITION BY m.GROUP_ID ORDER BY m.SCORE asc) AS row_asc
				,count(m.id) over(PARTITION BY g.GROUP_NAME) AS count_mem
				FROM GROUPT g 
				LEFT JOIN MEMBERS m ON g.id = m.GROUP_ID 
				ORDER BY g.GROUP_NAME,m.SCORE DESC
			) group_raw
			GROUP BY group_raw.GROUP_NAME,group_raw.count_mem
		) group_score_data
		ORDER BY group_score_data.GROUP_NAME
	)group_result
)