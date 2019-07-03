using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
//using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll
using com.digitalwave.iCare.ValueObject;	//iCareData.dll
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS
{
	#region �����շѺ��������ɱ������������
	/// <summary>	
	/// �����շѺ��������ɱ������������
	/// Create ��ΰ�� by 2005-09-13
	/// </summary>
	public class clsOutPatient: com.digitalwave.GUI_Base.clsController_Base	//GUI_Base.dll
	{
		#region ���캯��
		public clsOutPatient()
		{
			m_objManage = new clsDomainControlOutPatient();
			
		}
		#endregion
		
		#region ����
		/// <summary>
		/// DomainControl����
		/// </summary>
		private clsDomainControlOutPatient m_objManage = null;
		
		/// <summary>
		/// frm�������
		/// </summary>
		private com.digitalwave.iCare.gui.HIS.frmOutPatient m_objViewer ;

		#endregion

		#region ���ô������override Set_GUI_Apperance ʵ��
		
		/// <summary>
		/// ���ô������
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			// TODO:  ���� Set_GUI_Apperance ʵ��
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmOutPatient)frmMDI_Child_Base_in;
		}
		#endregion

		#region ����ʱ��ؼ��ĳ�ʼ��		
		/// <summary>
		/// ����ʱ��ؼ��ĳ�ʼ��		
		/// </summary>
		public void m_mthFrmInit()
		{
			DateTime dtm = this.m_objManage.m_dtmGetServerDate();
			this.m_objViewer.m_dateTimePickerbegin.Value = Convert.ToDateTime(dtm.Year.ToString()+"-"+dtm.Month.ToString()+"-"+"01");;
			this.m_objViewer.m_dateTimePickerEnd.Value = dtm;
			m_mthButtonClickToStatistic();
		}
		#endregion

		#region ͳ�Ʋ���
		/// <summary>
		/// ͳ�Ʋ���
		/// </summary>
		public void m_mthButtonClickToStatistic()
		{
			DataTable dtbStatistic;
			string dtmStart = this.m_objViewer.m_dateTimePickerbegin.Value.ToShortDateString();
			string dtmEnd = this.m_objViewer.m_dateTimePickerEnd.Value.ToShortDateString();
			long lngRes = this.m_objManage.m_lngGetStatiticsData(dtmStart, dtmEnd, out dtbStatistic);
			if(lngRes<0)
			{
				return ;
			}
			else
			{
				CrystalDecisions.CrystalReports.Engine.ReportDocument rpt =new CrystalDecisions.CrystalReports.Engine.ReportDocument();
				rpt.Load("Report\\CrystalReportOutPatient.rpt");
//				HISMedTypeManage.Rpt.CrystalReportOutPatient rpt = new HISMedTypeManage.Rpt.CrystalReportOutPatient();
				((TextObject)rpt.ReportDefinition.ReportObjects["Text7"]).Text = this.m_objViewer.m_dateTimePickerbegin.Value.ToShortDateString();
				((TextObject)rpt.ReportDefinition.ReportObjects["Text8"]).Text = this.m_objViewer.m_dateTimePickerEnd.Value.ToShortDateString();

				if(dtbStatistic.Rows.Count>0)
				{
					double totalMoney = 0;
					for(int i1=0;i1<dtbStatistic.Rows.Count;i1++)
					{
						totalMoney += Convert.ToDouble(dtbStatistic.Rows[i1]["TOTALMONEY"].ToString().Trim());
						
					}
					((TextObject)rpt.ReportDefinition.ReportObjects["Text13"]).Text = totalMoney.ToString();
				}
				else
				{
					MessageBox.Show("��ͳ�����ݣ�");					
					return ;
				}
				//((TextObject)rpt.ReportDefinition.ReportObjects["Text13"]).Text = 
				rpt.SetDataSource(dtbStatistic);
				rpt.Refresh();
				this.m_objViewer.m_crystalReportViewer1.ReportSource = rpt;
			}
		}
		#endregion

	}
	#endregion
}