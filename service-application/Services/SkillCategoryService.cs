using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace service_application.Services
{
    public class SkillCategoryService
    {
        private SkillsRoot _skillsRoots = new SkillsRoot();
        public SkillCategoryService()
        {
            string json = File.ReadAllText(@"C:\\Users\\ptibo\\Documents\\work\\service-application\\skill_category.json");
            _skillsRoots = JsonConvert.DeserializeObject<SkillsRoot>(json);
        }
       
        public string GetSzar()
        {
            var result = _skillsRoots.Skills[0].Name;
            return result;
        }
    }
}

public class SkillCategory
{
    public string Name { get; set; }
    public List<SkillCategory> Children { get; set; } = new List<SkillCategory>();
}

public class SkillsRoot
{
    public List<SkillCategory> Skills { get; set; } = new List<SkillCategory>();
}
