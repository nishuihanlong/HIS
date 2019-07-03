using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDcl_MedicineSource ��ժҪ˵����
	/// </summary>
	public class clsDcl_MedicineSource:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDcl_MedicineSource()
		{
			//
			// TODO: �ڴ˴����ӹ��캯���߼�
			//
		}
		
		#region ��ѯ�շ���Ŀ
		
		public long m_mthFindChargeItem(string strType,string strContent,out DataTable dt)
		{
			dt=null;
			com.digitalwave.iCare.middletier.HIS.clsMedicineSourceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsMedicineSourceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineSourceSvc));
			long lngRes= objSvc.m_mthFindChargeItem(objPrincipal,strType,strContent,out dt);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ѯ��ĿԴ
		
		public long m_mthFindChargeItemSource(out DataTable dt2)
		{
			dt2=null;
			com.digitalwave.iCare.middletier.HIS.clsMedicineSourceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsMedicineSourceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineSourceSvc));
			long lngRes= objSvc.m_lngFindAllSour(objPrincipal,out dt2);	
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		
		#region ��������
		
		public long m_mthSaveData(string strItemID,string strSourceID)
		{
			
			com.digitalwave.iCare.middletier.HIS.clsMedicineSourceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsMedicineSourceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineSourceSvc));
			long lngRes= objSvc.m_mthSaveData(objPrincipal, strItemID,strSourceID);	
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

        #region ����ҩ������
        /// <summary>
        /// ����ҩ������
        /// </summary>
        public long m_lngGetMedStoreData(string p_strWhere, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc));
            long lngRes = objSvc.m_lngGetMedStoreData(objPrincipal, p_strWhere, out p_dtbResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ������Ŀ����
        /// <summary>
        /// ������Ŀ����
        /// </summary>
        public long m_lngGetItemData(  out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc));
            long lngRes = objSvc.m_lngGetItemData(objPrincipal,  out p_dtbResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��������ҩ��ҩƷ�����嵥��������
        /// <summary>
        /// ��������ҩ��ҩƷ�����嵥��������
        /// </summary>
        public long m_lngGetMedSendItemData(string p_strRecordBeginDate, string p_strRecordEndDate, string[] p_strMedstoreIdArr, string[] p_strStatus, string p_strOrderBy, string p_strSingleItemName, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc));
            long lngRes = objSvc.m_lngGetMedSendItemData(objPrincipal, p_strRecordBeginDate,p_strRecordEndDate,p_strMedstoreIdArr,p_strStatus,p_strOrderBy,p_strSingleItemName,out p_dtbResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
	}
}