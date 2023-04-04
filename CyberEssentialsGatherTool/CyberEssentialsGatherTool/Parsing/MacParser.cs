using System.Xml;

namespace CyberEssentialsGatherTool.Parsing
{
    public class MacParser
    {
        public UserProfile ParseFile(string fileData)
        {
            UserProfile profile = new UserProfile();

            XmlDocument document = new();
            document.LoadXml(fileData);
            var plist = document["plist"];
            var categoriesArray = plist["array"];

            // Get software version information
            var applicationCategory = GetCategoryByName(categoriesArray, "SPApplicationsDataType");
            var applicationsList = GetItemsFromElement(applicationCategory);
            AddApplicationDataToProfile(profile, applicationsList);

            // Get OS information
            var osCategory = GetCategoryByName(categoriesArray, "SPSoftwareDataType");
            var osInformationList = GetItemsFromElement(osCategory)["dict"];
            AddOSDataToProfile(profile, osInformationList);

            return profile;
        }

        private XmlElement GetCategoryByName(XmlElement arrayElement, string categoryName)
        {
            foreach(XmlElement category in arrayElement.ChildNodes)
            {
                string foundCategoryName = GetCategoryName(category);
                if(foundCategoryName == categoryName) 
                {
                    return category;
                }
            }
            return null;
        }

        private string GetCategoryName(XmlElement category)
        {
            foreach (XmlElement categoryInfo in category.ChildNodes)
            {
                if (categoryInfo.InnerText == "_dataType")
                {
                    return categoryInfo.NextSibling.InnerText;
                }
            }
            return "";
        }

        private XmlElement GetItemsFromElement(XmlElement applicationCategory)
        {
            bool returnNext = false;

            foreach (XmlElement field in applicationCategory.ChildNodes)
            {
                if(returnNext)
                {
                    return field;
                }
                if (field.InnerText == "_items")
                {
                    returnNext = true;
                }

                // can be replaced with return field.NextSibling
            }
            return null;
        }

        private void AddApplicationDataToProfile(UserProfile profile, XmlElement applicationsList)
        {
            foreach(XmlElement application in applicationsList)
            {
                string name = "";
                string version = "";

                foreach(XmlElement information in application) 
                {
                    if (information.InnerText == "_name")
                    {
                        name = information.NextSibling.InnerText;
                    }
                    if (information.InnerText == "version")
                    {
                        version = information.NextSibling.InnerText;
                    }
                }

                profile.Software.Add(new SoftwareInfo { Name = name, Version = version});
            }
        }

        private void AddOSDataToProfile(UserProfile profile, XmlElement osInformationList)
        {
            foreach(XmlElement information in osInformationList.ChildNodes)
            {
                if(information.InnerText == "os_version")
                {
                    profile.OS = information.NextSibling.InnerText.Split(' ', 2).First();
                    profile.OSVersion = information.NextSibling.InnerText.Split(' ', 2).Last();
                }
                if (information.InnerText == "user_name")
                {
                    profile.Name = information.NextSibling.InnerText;
                }
            }
        }
    }
}
