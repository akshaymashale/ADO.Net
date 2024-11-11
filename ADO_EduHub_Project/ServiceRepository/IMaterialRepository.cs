using System.Data;

namespace ADO_EduHub_Project{
    internal interface IMaterialRepository{
        int AddCourseMaterialById(Material material);
        DataSet GetCourseMaterialById(int courseid);
        int UpdateMaterial(Material material);
    }
}