﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace HTNResp.DAL
{
	/// <summary>
	/// 数据访问类:PrevensionProject
	/// </summary>
	public partial class PrevensionProject
	{
		public PrevensionProject()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "PrevensionProject"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PrevensionProject");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HTNResp.Model.PrevensionProject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PrevensionProject(");
			strSql.Append("ProjectName,DangerousGroup,DecisionRule,AdaptScope,Measure,Aim,Status,EvalGuidId)");
			strSql.Append(" values (");
			strSql.Append("@ProjectName,@DangerousGroup,@DecisionRule,@AdaptScope,@Measure,@Aim,@Status,@EvalGuidId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectName", SqlDbType.NVarChar,5),
					new SqlParameter("@DangerousGroup", SqlDbType.NVarChar,10),
					new SqlParameter("@DecisionRule", SqlDbType.NVarChar,-1),
					new SqlParameter("@AdaptScope", SqlDbType.NVarChar,60),
					new SqlParameter("@Measure", SqlDbType.NVarChar,255),
					new SqlParameter("@Aim", SqlDbType.NVarChar,150),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@EvalGuidId", SqlDbType.Int,4)};
			parameters[0].Value = model.ProjectName;
			parameters[1].Value = model.DangerousGroup;
			parameters[2].Value = model.DecisionRule;
			parameters[3].Value = model.AdaptScope;
			parameters[4].Value = model.Measure;
			parameters[5].Value = model.Aim;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.EvalGuidId;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HTNResp.Model.PrevensionProject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PrevensionProject set ");
			strSql.Append("ProjectName=@ProjectName,");
			strSql.Append("DangerousGroup=@DangerousGroup,");
			strSql.Append("DecisionRule=@DecisionRule,");
			strSql.Append("AdaptScope=@AdaptScope,");
			strSql.Append("Measure=@Measure,");
			strSql.Append("Aim=@Aim,");
			strSql.Append("Status=@Status,");
			strSql.Append("EvalGuidId=@EvalGuidId");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectName", SqlDbType.NVarChar,5),
					new SqlParameter("@DangerousGroup", SqlDbType.NVarChar,10),
					new SqlParameter("@DecisionRule", SqlDbType.NVarChar,-1),
					new SqlParameter("@AdaptScope", SqlDbType.NVarChar,60),
					new SqlParameter("@Measure", SqlDbType.NVarChar,255),
					new SqlParameter("@Aim", SqlDbType.NVarChar,150),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@EvalGuidId", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProjectName;
			parameters[1].Value = model.DangerousGroup;
			parameters[2].Value = model.DecisionRule;
			parameters[3].Value = model.AdaptScope;
			parameters[4].Value = model.Measure;
			parameters[5].Value = model.Aim;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.EvalGuidId;
			parameters[8].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PrevensionProject ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PrevensionProject ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HTNResp.Model.PrevensionProject GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ProjectName,DangerousGroup,DecisionRule,AdaptScope,Measure,Aim,Status,EvalGuidId from PrevensionProject ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			HTNResp.Model.PrevensionProject model=new HTNResp.Model.PrevensionProject();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HTNResp.Model.PrevensionProject DataRowToModel(DataRow row)
		{
			HTNResp.Model.PrevensionProject model=new HTNResp.Model.PrevensionProject();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ProjectName"]!=null)
				{
					model.ProjectName=row["ProjectName"].ToString();
				}
				if(row["DangerousGroup"]!=null)
				{
					model.DangerousGroup=row["DangerousGroup"].ToString();
				}
				if(row["DecisionRule"]!=null)
				{
					model.DecisionRule=row["DecisionRule"].ToString();
				}
				if(row["AdaptScope"]!=null)
				{
					model.AdaptScope=row["AdaptScope"].ToString();
				}
				if(row["Measure"]!=null)
				{
					model.Measure=row["Measure"].ToString();
				}
				if(row["Aim"]!=null)
				{
					model.Aim=row["Aim"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["EvalGuidId"]!=null && row["EvalGuidId"].ToString()!="")
				{
					model.EvalGuidId=int.Parse(row["EvalGuidId"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ProjectName,DangerousGroup,DecisionRule,AdaptScope,Measure,Aim,Status,EvalGuidId ");
			strSql.Append(" FROM PrevensionProject ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,ProjectName,DangerousGroup,DecisionRule,AdaptScope,Measure,Aim,Status,EvalGuidId ");
			strSql.Append(" FROM PrevensionProject ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM PrevensionProject ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from PrevensionProject T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "PrevensionProject";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

