namespace ManpBLL
{
    public class RoleService
    {
        public string RoleSel()
        {
            ManpDAL.RoleManager roleManager = new ManpDAL.RoleManager();
            return roleManager.RoleSel();
        }
        public int AddRole(string name, string content, string Expower)
        {
            ManpDAL.RoleManager roleManager = new ManpDAL.RoleManager();
            return roleManager.AddRole(name, content, Expower);
        }
        public int Edit(string id, string name, string content, string Expower)
        {
            ManpDAL.RoleManager roleManager = new ManpDAL.RoleManager();
            return roleManager.Edit(id, name, content, Expower);
        }
        public string RoleMenu()
        {
            ManpDAL.RoleManager roleManager = new ManpDAL.RoleManager();
            return roleManager.RoleMenu();
        }
        public int RoleDel(string arrid)
        {
            ManpDAL.RoleManager roleManager = new ManpDAL.RoleManager();
            return roleManager.RoleDel(arrid);
        }
    }
}
