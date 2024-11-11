using System.Data;

namespace ADO_EduHub_Project{
    internal interface IEnquiryRepository{
        int AddEnquiry(Enquiry enquiry);
        DataSet ViewEnquiryByCourseId(int courseid);
        DataSet ViewEnquiryByEnquiryID(int enquiryId);

        // int updateEnquiryByEnquiryID(Enquiry enquiry);
        // DataSet getEnquiryByUserId(int userId);
        //    DataSet getAllEnquiry();
    }
}